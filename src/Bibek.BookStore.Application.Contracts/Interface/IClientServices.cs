
using Bibek.BookStore.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bibek.BookStore.Interface
{
    public  interface IClientServices
    {
        Task<IActionResult> GetListAsync();
        Task<IActionResult> GetByIdAsync(Guid id);
        Task<IActionResult> CreateAsync(ClientDTO client);
        Task<IActionResult> UpdateAsync(ClientDTO client);
        Task<IActionResult> DeleteAsync(Guid Id);
    }
}
