using Bibek.BookStore.DTO;
using Bibek.BookStore.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bibek.BookStore.Interface
{
    public  interface IBookAppService
    {
        Task<List<Book>> GetClientBooksAsync();
        //Task<IActionResult> GetByIdAsync(Guid id);
        //Task<IActionResult> CreateAsync(BookDTO input);
        //Task<IActionResult> UpdateAsync(BookDTO book);
        //Task<IActionResult> DeleteAsync(Guid Id);
        //Task<IActionResult> CreateAsync(BookDTO input);

        Task<IActionResult> CreateBookAsync(BookDTO input);
        Task<IActionResult> UpdateBookAsync( Guid Id,BookDTO input);
        Task DeleteBookAsync(Guid id);
        Task<IActionResult> GetByIdAsync(Guid id);

    }
}
