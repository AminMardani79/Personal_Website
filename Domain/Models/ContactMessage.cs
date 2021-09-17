using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ContactMessage
    {
        [Key]
        public int MessageId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MessageName { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MessageEmail { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MessageNumber { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(30, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MessageTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(500, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MessageDescription { get; set; }

    }
}
