using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CategoryProject
    {
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectCategory")]
        public int CategoryId { get; set; }
        public Project Project { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
    }
}
