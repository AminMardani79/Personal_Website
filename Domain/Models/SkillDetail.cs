using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SkillDetail
    {
        public int SkillDetailId { get; set; }
        public int SkillId { get; set; }
        public string SkillTitle { get; set; }
        public int SkillPercent { get; set; }
    }
}
