using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ApplicationContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
        public DbSet<CategoryProject> CategoryProjects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillDetail> SkillDetails { get; set; }
        public DbSet<Admin> Admins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }

            #region ManyToMany

            modelBuilder.Entity<CategoryProject>()
        .HasKey(bc => new { bc.CategoryId, bc.ProjectId });
            modelBuilder.Entity<CategoryProject>()
                .HasOne(bc => bc.Project)
                .WithMany(b => b.CategoryProjects)
                .HasForeignKey(bc => bc.ProjectId);
            modelBuilder.Entity<CategoryProject>()
                .HasOne(bc => bc.ProjectCategory)
                .WithMany(c => c.CategoryProjects)
                .HasForeignKey(bc => bc.CategoryId);

            #endregion

            #region QueryFilters

            modelBuilder.Entity<ProjectCategory>().HasQueryFilter(p => p.IsCategoryDelete == false);

            #endregion
        }
    }
}
