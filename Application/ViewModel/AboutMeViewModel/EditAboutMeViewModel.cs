using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.AboutMeViewModel
{
    public class EditAboutMeViewModel
    {
        public int AboutMeId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(150, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string AboutMeDes { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(300, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string AboutMeContext { get; set; }
        [Required]
        public int CustomerCount { get; set; }
        [Required]
        public int ProjectsCount { get; set; }
    }
}
