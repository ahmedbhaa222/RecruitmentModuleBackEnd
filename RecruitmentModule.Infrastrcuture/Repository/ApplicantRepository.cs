using RecruitmentModule.Core.Application.ViewModels;
using RecruitmentModule.Core.Domain.IRepository;
using RecruitmentModule.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitmentModule.Infrastrcuture.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly RecruitmentContext _recruitmentContext;
        public ApplicantRepository(RecruitmentContext recruitmentContext)
        {
            _recruitmentContext = recruitmentContext;
        }

        public int Add(ApplicantAddVM applicantAddVM)
        {
            // AddEntity
            var applicant = new Applicant()
            {
                Name = applicantAddVM.Name,
                Email = applicantAddVM.Email,
                JobId = applicantAddVM.JobId,
                MobileNumber = applicantAddVM.MobileNumber,
            };
            _recruitmentContext.Applicants.Add(applicant);
            return _recruitmentContext.SaveChanges();
        }

        public int ApplicantCount(int jobId)
        {
           return _recruitmentContext.Applicants.Where(a => a.JobId == jobId).Count();
        }
    }
}
