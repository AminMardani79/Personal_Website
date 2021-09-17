using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProjectCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string CategoryTitle { get; set; }
        public IEnumerable<Project> Projects { get; set; }

    }
}
