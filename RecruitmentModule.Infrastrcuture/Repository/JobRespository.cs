using Microsoft.EntityFrameworkCore;
using RecruitmentModule.Core.Application.ViewModels;
using RecruitmentModule.Core.Domain.IRepository;
using RecruitmentModule.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitmentModule.Infrastrcuture.Repository
{
    public class JobRespository : IJobRepository
    {
        private readonly RecruitmentContext _recruitmentContext;
        public JobRespository(RecruitmentContext recruitmentContext)
        {
            _recruitmentContext = recruitmentContext;
        }
        public int Add(JobAddVM jobAddVM)
        {

            // AddEntity
            var job = new Job()
            {
                Name = jobAddVM.Name,
                Description = jobAddVM.Description,
                CategoryId = jobAddVM.CategoryId,
                ValidFrom = jobAddVM.ValidFrom,
                ValidTo = jobAddVM.ValidTo,
                MaximumApplications = jobAddVM.MaximumApplications,

                Skills = jobAddVM.Skills.Select(j =>
                new JobSkill()
                {
                    Name = j.Name
                }).ToList(),

                Responsibilities = jobAddVM.Responsibilities.Select(j =>
                new JobResponsibility()
                {
                    Name = j.Name
                }).ToList()

            };
            _recruitmentContext.Jobs.Add(job);
            return _recruitmentContext.SaveChanges();
        }

        public int Edit(JobEditVM jobEditVM)
        {
            var job = _recruitmentContext
                    .Jobs
                    .Include(j=>j.Skills)
                    .Include(j => j.Responsibilities)
                    .FirstOrDefault(j => j.Id == jobEditVM.Id);
            if (job == null)
            {
                return 0;
            }
            
            using (var transaction = _recruitmentContext.Database.BeginTransaction())
            {
                try
                {
                    // delete all children
                    _recruitmentContext.JobResponsibilities.RemoveRange(job.Responsibilities);

                    _recruitmentContext.JobSkills.RemoveRange(job.Skills);

                    //update Entity
                    _recruitmentContext.Entry(job).CurrentValues.SetValues(jobEditVM);

                    // add new Children
                    _recruitmentContext.JobSkills.AddRange(
                        jobEditVM.Skills.Select( j=>
                        new JobSkill()
                        {
                            Name = j.Name,
                            JobId = job.Id,
                        }));

                    _recruitmentContext.JobResponsibilities.AddRange(
                        jobEditVM.Responsibilities.Select(j =>
                        new JobResponsibility()
                        {
                            Name = j.Name,
                            JobId = job.Id,
                        }));

                    var result = _recruitmentContext.SaveChanges();

                    transaction.Commit();
                    return result;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Job GeById(int id)
        {
            return _recruitmentContext
                    .Jobs
                    .Include(j=>j.Category)
                    .Include(j => j.Skills)
                    .Include(j => j.Responsibilities)
                    .FirstOrDefault(j => j.Id == id && !j.IsDeleted);
        }

        public List<JobCategory> GetJobCategories()
        {
            return _recruitmentContext
                     .JobCategories
                     .ToList();
        }

        public List<Job> GeManyPaged(int pageNumber = 1, int take = 3, string jobTitle = null)
        {
           var skip = (pageNumber - 1) * take;
           return _recruitmentContext
                    .Jobs
                    .Include(j => j.Category)
                    .Include(j => j.Skills)
                    .Include(j => j.Responsibilities)
                    .Where(j => !j.IsDeleted && (jobTitle == null || j.Name.Contains(jobTitle)))
                    .Skip(skip)
                    .Take(take)
                    .ToList();
        }
        public List<Job> GetAllAvailble()
        {
            return _recruitmentContext
                     .Jobs
                     .Include(j => j.Category)
                     .Include(j => j.Skills)
                     .Include(j => j.Responsibilities)
                     .Where(j => !j.IsDeleted && j.ValidFrom <= DateTime.Today && j.ValidTo >= DateTime.Today)
                     .ToList();
        }

        public int Delete(int jobId)
        {
            var job = _recruitmentContext
                    .Jobs
                    .Include(j => j.Skills)
                    .Include(j => j.Responsibilities)
                    .FirstOrDefault(j => j.Id == jobId);
            if(job != null)
            {
                job.IsDeleted = true;
                return _recruitmentContext.SaveChanges();
            }
            return 0;
        }

        public int Count( string jobTitle = null)
        {
            return _recruitmentContext
                  .Jobs
                  .Where(j => !j.IsDeleted && (jobTitle == null || j.Name.Contains(jobTitle)))
                  .Count();
        }
    }
}
