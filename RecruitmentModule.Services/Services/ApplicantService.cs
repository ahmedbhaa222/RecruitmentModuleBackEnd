using RecruitmentModule.Core.Application.IServices;
using RecruitmentModule.Core.Application.ViewModels;
using RecruitmentModule.Core.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Services.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IJobRepository _jobRepository;

        public ApplicantService(IApplicantRepository applicantRepository,IJobRepository jobRepository)
        {
            _applicantRepository = applicantRepository;
            _jobRepository = jobRepository;

        }
        public ResponseVM<string> Add(ApplicantAddVM applicantAddVM)
        {
            var job = _jobRepository.GeById(applicantAddVM.JobId);
            if(job == null)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Message = "Invalid Job"
                };
            }
            if(job.ValidFrom > DateTime.Now || job.ValidTo < DateTime.Now)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Message = "This Job Is Expired"
                };
            }
            if(_applicantRepository.ApplicantCount(job.Id) >= job.MaximumApplications)
            {
                return new ResponseVM<string>()
                {
                    IsSuccess = false,
                    Message = "Maximum Application Received!"
                };

            }
            var result = _applicantRepository.Add(applicantAddVM);
            if (result > 0)
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
    }
}
