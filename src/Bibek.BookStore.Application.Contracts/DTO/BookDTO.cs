using Bibek.BookStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Bibek.BookStore.DTO
{
    public class BookDTO :EntityDto<Guid>
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public DateTime IssueDate { get; set; }
        public Guid ClientId { get; set; }

        //public Client Client { get; set; }
    }
}
