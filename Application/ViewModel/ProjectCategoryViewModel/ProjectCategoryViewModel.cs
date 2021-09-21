﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.ProjectCategoryViewModel
{
    public class ProjectCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public bool IsCategoryDelete { get; set; }
    }
}
