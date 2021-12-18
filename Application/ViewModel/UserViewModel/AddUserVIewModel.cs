using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.UserViewModel
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "شماره موبایل را وارد کنید")]
        [MaxLength(50, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [MaxLength(150, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "تکرار رمز عبور را وارد کنید")]
        [Compare(nameof(Password),ErrorMessage ="تکرار رمز عبور اشتباه میباشد")]
        [MaxLength(150, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ConfirmPassword { get; set; }
        public bool HasAccess { get; set; }

    }
}