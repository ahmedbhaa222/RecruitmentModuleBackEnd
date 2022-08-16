using Microsoft.EntityFrameworkCore;
using RecruitmentModule.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentModule.Persistance
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
        }

    }
}
