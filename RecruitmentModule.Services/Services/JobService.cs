using RecruitmentModule.Core.Application.IServices;
using RecruitmentModule.Core.Application.ViewModels;
using RecruitmentModule.Core.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitmentModule.Services.Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public ResponseVM<string> Add(JobAddVM job)
        {
            if(job.ValidTo < job.ValidFrom)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Valid From Must Be Befor Valid To"
                };
            }
            var result = _jobRepository.Add(job);
            if(result > 0)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "Added Successfully"
                };
            }
            else
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Message = "Some Thing Went Wrong"
                };
            }
        }

        public ResponseVM<string> Delete(int jobId)
        {
            // This Is A Soft Delete
            var result = _jobRepository.Delete(jobId);
            if (result > 0)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "Removed Successfully"
                };
            }
            else
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Message = "Some Thing Went Wrong"
                };
            }
        }

        public ResponseVM<string> Edit(JobEditVM job)
        {
            if (job.ValidTo < job.ValidFrom)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Valid From Must Be Befor Valid To"
                };
            }
            var result = _jobRepository.Edit(job);
            if (result > 0)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = true,
                    Data = null,
                    Message = "Updated Successfully"
                };
            }
            else
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Message = "Some Thing Went Wrong"
                };
            }
        }

        public ResponseVM<JobVM> GetById(int id)
        {
            var job = _jobRepository.GeById(id);
            if(job == null)
            {
                return new ResponseVM<JobVM>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Job NotFound"
                };
            }
            var jobVM = new JobVM()
            {
                Id = job.Id,
                Name = job.Name,
                Description = job.Description,
                CategoryId = job.CategoryId,
                MaximumApplications = job.MaximumApplications,
                ValidFrom = job.ValidFrom,
                ValidTo = job.ValidTo,
                Category = new JobCategoryVM()
                {
                    Name = job.Category.Name,
                    Id = job.Category.Id,
                },
                Responsibilities = job.Responsibilities.Select((j =>
                        new JobResponsibilityVM()
                        {
                            Name = j.Name,
                            Id = j.Id,
                        })).ToList(),

                Skills = job.Skills.Select((j =>
                        new JobSkillVM()
                        {
                            Name = j.Name,
                            Id = j.Id,
                        })).ToList(),
            };

            return new ResponseVM<JobVM>()
            {
                Data = jobVM,
                IsSuccess = true,
            };
        }

        public PagedResponseVM<List<JobListVM>> GeManyPaged(int pageNumber = 1, int take = 3, string jobTitle = null)
        {
            var jobs = _jobRepository.GeManyPaged( pageNumber, take , jobTitle );

            var jobsVM = jobs.Select(j => new JobListVM()
            {
                Id = j.Id,
                Name = j.Name,
                Description = j.Description,
                CategoryName = j.Category.Name,
                MaximumApplications = j.MaximumApplications,
                ValidFrom = j.ValidFrom,
                ValidTo = j.ValidTo,
            }).ToList();
            var totalRecords = _jobRepository.Count(jobTitle);
            return new PagedResponseVM<List<JobListVM>>(jobsVM, pageNumber, take, totalRecords);
        }

        public ResponseVM<List<JobListVM>> GetAllAvailble()
        {
            var jobs = _jobRepository.GetAllAvailble();

            var jobsVM = jobs.Select(j => new JobListVM()
            {
                Id = j.Id,
                Name = j.Name,
                Description = j.Description,
                CategoryName = j.Category.Name,
                MaximumApplications = j.MaximumApplications,
                ValidFrom = j.ValidFrom,
                ValidTo = j.ValidTo,
            }).ToList();
            return new ResponseVM<List<JobListVM>>()
            {
                IsSuccess = false,
                Data = jobsVM
            };
         
        }
        public ResponseVM<List<JobCategoryVM>> GetJobCategories()
        {
            var categories = _jobRepository.GetJobCategories();

            var categoriesVM = categories.Select(j => new JobCategoryVM()
            {
                Id = j.Id,
                Name = j.Name     
            }).ToList();

            return new ResponseVM<List<JobCategoryVM>>()
            {
                Data = categoriesVM,
                IsSuccess = true,
            };
        }

    }
}
