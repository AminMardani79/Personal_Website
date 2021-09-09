using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ApplicationContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<DoWork> DoWorks { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategorys { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillDetail> SkillDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
