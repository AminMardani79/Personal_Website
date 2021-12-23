using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.DoWorkViewModel
{
    public class DoWorkViewModel
    {
        public int DoWorkId { get; set; }
        public string DoWorkTitle { get; set; }
        public string DoWorkIcon { get; set; }
        public string DoWorkDesc { get; set; } 

    }
}
