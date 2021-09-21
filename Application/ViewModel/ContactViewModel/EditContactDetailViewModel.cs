using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.ContactViewModel
{
    public class EditContactDetailViewModel
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(150, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ContactDescription { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(40, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ContactEmail { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string Telegram { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string Instagram { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string LinkdIn { get; set; }
    }
}
