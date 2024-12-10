
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.DependencyInjection;
using AutoMapper.Internal.Mappers;
using Volo.Abp.Application.Services;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.ObjectMapping;
using Bibek.BookStore.Interface;
using Bibek.BookStore.Model;
using Bibek.BookStore.DTO;

namespace Bibek.BookStore
{
    public  class ClientServices: ApplicationService , IClientServices,ITransientDependency
    {
        private readonly IRepository<Client, Guid > _clientRepository;
        public ClientServices(IRepository<Client, Guid> clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<IActionResult> CreateAsync(ClientDTO client)
        {
            try
            {
                var clientMappedObject = ObjectMapper.Map<ClientDTO, Client>(client);
                var clientObject = await this._clientRepository.InsertAsync(clientMappedObject);
                return new OkObjectResult(clientObject);
            }
            catch (Exception ex)
            {
                return new OkResult();
            }
        }
        public  async Task<IActionResult> DeleteAsync(Guid Id)
        {
            await this._clientRepository.DeleteAsync(Id);
           return new OkResult();
        }
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var clientObj = await this._clientRepository.GetAsync(id);
            return new ObjectResult(clientObj);
        }
        public async Task<IActionResult> GetListAsync()
        {
            var clientList = await this._clientRepository.GetListAsync();
            return new ObjectResult(clientList);
        }
        public async Task<IActionResult> UpdateAsync(ClientDTO client)
        {
            try
            {
                var clientObject = await this._clientRepository.FindAsync(client.Id);
                if (clientObject != null)
                {
                    ObjectMapper.Map<ClientDTO, Client>(client, clientObject);
                    var clientReturnedObject = await this._clientRepository.UpdateAsync(clientObject);

                    return new OkObjectResult(clientReturnedObject);
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
