using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.MajorViewModel
{
    public class CreateMajorViewModel
    {
        public int MajorId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(40, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MajorTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(40, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MajorSubTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MajorStart { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MajorEnd { get; set; }
    }
}
