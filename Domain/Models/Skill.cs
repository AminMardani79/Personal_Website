using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(250, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string SkillDescription { get; set; }
        public IEnumerable<SkillDetail> SkillDetails { get; set; }

    }
}
