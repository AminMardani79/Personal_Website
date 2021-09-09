using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContactMessage
    {
        public int MessageId { get; set; }
        public string MessageName { get; set; }
        public string MessageEmail { get; set; }
        public string MessageNumber { get; set; }
        public string MessageTitle { get; set; }
        public string MessageDescription { get; set; }

    }
}
