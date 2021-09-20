﻿using Data.Repository;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            // Repositories
            service.AddScoped<IAboutRepository,AboutRepository>();
            service.AddScoped<IContactDetailRepository,ContactDetailRepository>();
            service.AddScoped<IContactMessageRepository,ContactMessageRepository>();
            service.AddScoped<IDoWorkRepository,DoWorkRepository>();
            service.AddScoped<IExperienceRepository,ExperienceRepository>();
            service.AddScoped<IMajorRepository,MajorRepository>();
            service.AddScoped<IProjectRepository,ProjectRepository>();
            service.AddScoped<IProjectCategoryRepository,ProjectCategoryRepository>();
            service.AddScoped<ISkillDetailRepository,SkillDetailRepository>();
            service.AddScoped<ISkillRepository,SkillRepository>();
        }
    }
}