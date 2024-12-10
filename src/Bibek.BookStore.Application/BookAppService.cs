using Bibek.BookStore.DTO;
using Bibek.BookStore.Interface;
using Bibek.BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;



namespace Bibek.BookStore
{
    public class BookAppService : ApplicationService, IBookAppService
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<Client, Guid> _clientRepository;

        public BookAppService(IRepository<Book, Guid> bookRepository, IRepository<Client, Guid> clientRepository)
        {
            _bookRepository = bookRepository;
            _clientRepository = clientRepository;
        }
        [HttpGet("client-books")] // Endpoint for getting client-book data
        public async Task<List<Book>> GetClientBooksAsync()
        {
            // Manually join Book and Client using LINQ
            var booksWithClients = from book in await _bookRepository.GetListAsync()
                                   join client in await _clientRepository.GetListAsync()
                                   on book.ClientId equals client.Id into clientGroup
                                   from client in clientGroup.DefaultIfEmpty() // Left join ensures no null exception
                                   select new Book
                                   {
                                       Name = book.Name,
                                       Author = book.Author,
                                       IssueDate = book.IssueDate,
                                       ClientId = client.Id
                                      
                                   };

            return booksWithClients.ToList();
        }
        [HttpPost("client-books")]
        public async Task<IActionResult> CreateBookAsync(BookDTO input)
        {
            try
            {
                var clientBookDto = ObjectMapper.Map<BookDTO, Book>(input);
                // Insert the book entity into the repository
                var createdBook = await _bookRepository.InsertAsync(clientBookDto);
                return new OkObjectResult(clientBookDto);
            }
            catch (Exception ex)
            {
                // Log error (optional) and return an appropriate response
                return new ObjectResult($"Error occurred: {ex.Message}");
            }
        }
        [HttpPut("client-books/{id}")]
        public async Task<IActionResult> UpdateBookAsync(Guid Id, BookDTO input)
        {
            try
            {
                var bookObject = await this._bookRepository.FindAsync(input.Id);
                if (bookObject != null)
                {
                    ObjectMapper.Map<BookDTO, Book>(input, bookObject);
                    var clientBookdObject = await this._bookRepository.UpdateAsync(bookObject);
                    return new OkObjectResult(clientBookdObject);
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            catch (Exception ex)
            {
                // Log error (optional) and return an appropriate response
                return new ObjectResult($"Error occurred: {ex.Message}");
            }
        }
        [HttpDelete("client-books/{id}")]
        public async Task DeleteBookAsync(Guid id)
        {
            await _bookRepository.DeleteAsync(id);
        }
        [HttpGet("client-books/{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var bookObj = await _bookRepository.GetAsync(id);
            return new ObjectResult(bookObj);
        }
    }
}
