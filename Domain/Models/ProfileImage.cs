using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProfileImage
    {
        [Key]
        public int ProfileId { get; set; }
        [Required,MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(200)]
        public string Image { get; set; } 

    }
}
