using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.UserViewModel
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "شماره موبایل را وارد کنید")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string PhoneNumber { get; set; }
        [MaxLength(150, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "تکرار رمز عبور اشتباه میباشد")]
        [MaxLength(150, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string LastPassword { get; set; }
        public bool HasAccess { get; set; }
    }
}