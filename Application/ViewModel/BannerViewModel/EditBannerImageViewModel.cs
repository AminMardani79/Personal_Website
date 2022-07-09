using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.BannerViewModel
{
    public class EditBannerImageViewModel
    {
        public int BannerId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد"), MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string BannerTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد"), MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string FullName { get; set; }
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ResumeLink { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد"), MaxLength(500, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string Description { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(200, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string BannerImage { get; set; }
        public IFormFile File { get; set; }
    }
}