using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BannerImage
    {
        [Key]
        public int BannerId { get; set; }
        [Required,MaxLength(100)]
        public string BannerTitle { get; set; }
        [Required,MaxLength(100)]
        public string FullName { get; set; }
        [Required,MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(200)]
        public string ResumeLink { get; set; }
        [MaxLength(200)]
        public string Image { get; set; }
    }
}
