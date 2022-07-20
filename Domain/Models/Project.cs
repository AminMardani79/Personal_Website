using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectSubTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(250, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectDescription { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectImage { get; set; }
        [MaxLength(200, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string DownloadLink { get; set; }
        [MaxLength(200, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string SiteUrl { get; set; }

        public IEnumerable<CategoryProject> CategoryProjects { get; set; }

    }
}