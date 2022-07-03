using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.ProfileViewModel
{
    public class EditProfileViewModel
    {
        public int ProfileId { get; set; } 
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(200, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProfileImage { get; set; }
        public IFormFile File { get; set; }
    }
}
