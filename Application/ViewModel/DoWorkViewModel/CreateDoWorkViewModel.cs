﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.DoWorkViewModel
{
    public class CreateDoWorkViewModel
    {
        public int DoWorkId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(30, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string DoWorkTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string DoWorkDesc { get; set; }
        public string DoWorkIcon { set; get; }
    }
}
