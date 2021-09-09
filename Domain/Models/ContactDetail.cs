using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContactDetail
    {
        public int ContactId { get; set; }
        public string ContactDescription { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }

    }
}
