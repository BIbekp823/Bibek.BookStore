using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Bibek.BookStore.Model
{
    public  class Client : AggregateRoot<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        // Navigation property for related books
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
