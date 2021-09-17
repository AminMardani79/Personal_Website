using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SkillDetail
    {
        [Key]
        public int SkillDetailId { get; set; }
        public int SkillId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string SkillTitle { get; set; }
        [Required]
        public int SkillPercent { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}
