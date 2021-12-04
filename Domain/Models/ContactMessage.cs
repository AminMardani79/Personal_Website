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
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserNumber { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(30, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MessageTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(500, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string MessageDescription { get; set; }
        public bool IsShowing { get; set; } = false;

    }
}
