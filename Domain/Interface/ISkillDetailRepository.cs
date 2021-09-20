﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ISkillDetailRepository
    {
        Task<IEnumerable<SkillDetail>> GetSkillDetailsList(string search);
        Task<SkillDetail> GetSkillDetailById(int skillDetailId); 
        void CreateSkillDetail(SkillDetail skillDetail);
        void DeleteSkillDetail(SkillDetail skillDetail);
        void UpdateSkillDetail(SkillDetail skillDetail);
        void Save();
    }
}
