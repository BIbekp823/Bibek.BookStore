using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Bibek.BookStore.Model
{
    public  class Book : AggregateRoot<Guid>
    {
        
            public string? Name { get; set; }
            public string? Author { get; set; }
            public DateTime IssueDate { get; set; }
            public Guid ClientId { get; set; }
            // Foreign key for Client
            
            //public Client Client { get; set; }

    }
}
