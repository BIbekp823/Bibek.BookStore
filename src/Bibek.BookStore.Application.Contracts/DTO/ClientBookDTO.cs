using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibek.BookStore.DTO
{
    public  class ClientBookDTO
    {
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
