using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [DataType(DataType.Password)]
        [MaxLength(40, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string Password { get; set; }
    }
}
