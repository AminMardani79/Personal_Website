using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.ContactViewModel
{
    public class ContactMessageViewModel
    {
        
        public int MessageId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserNumber { get; set; }
        public string MessageTitle { get; set; }
        public string MessageDesc { get; set; }
    }
}
