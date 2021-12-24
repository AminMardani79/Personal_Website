using Application.Interface;
using Application.Services;
using Data.Repository;
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
            service.AddScoped<ICategoryProjectRepository,CategoryProjectRepository>();
            service.AddScoped<IUserRepository,UserRepository>();
            service.AddScoped<IAccountRepository,AccountRepository>();
            service.AddScoped<IMessagesCountRepository,MessagesCountRepository>();

            // Services
            service.AddScoped<IAboutService, AboutService>();
            service.AddScoped<IContactDetailService, ContactDetailService>();
            service.AddScoped<IContactMessageService, ContactMessageService>();
            service.AddScoped<IDoWorkService, DoWorkService>();
            service.AddScoped<IExperienceService, ExperienceService>();
            service.AddScoped<IMajorService, MajorService>();
            service.AddScoped<IProjectService, ProjectService>();
            service.AddScoped<IProjectCategoryService, ProjectCategoryService>();
            service.AddScoped<ISkillDetailService, SkillDetailService>();
            service.AddScoped<ISkillService, SkillService>();
            service.AddScoped<ICategoryProjectService, CategoryProjectService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<IMessagesCountService, MessagesCountService>();
        }
    }
}