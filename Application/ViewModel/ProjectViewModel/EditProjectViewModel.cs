﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.ProjectViewModel
{
    public class EditProjectViewModel
    {
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(20, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectSubTitle { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(250, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectDescription { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string ProjectImage { get; set; }
        [Required(ErrorMessage = "این رشته نباید خالی باشد")]
        [MaxLength(100, ErrorMessage = "طول این رشته بیش از حد مجاز است")]
        public string DownloadLink { get; set; }

        public int CategoryId { get; set; }
    }
}
