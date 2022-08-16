using Microsoft.EntityFrameworkCore;
using RecruitmentModule.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentModule.Infrastrcuture
{
    public class RecruitmentContext :DbContext
    {
        #region DBSets
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<JobResponsibility> JobResponsibilities { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
        public DbSet<Applicant> Applicants { get; set; }


        #endregion
        public RecruitmentContext(DbContextOptions<RecruitmentContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobCategory>().HasData(
                new JobCategory { 
                    Id = 1,
                    Name = "Officials and Managers"
                }, new JobCategory
                {
                    Id = 2,
                    Name = "Professionals"
                },
                new JobCategory
                {
                    Id = 3,
                    Name = "Technicians"
                },
                new JobCategory
                {
                    Id = 4,
                    Name = "Sales Workers"
                });
        }

    }
}
