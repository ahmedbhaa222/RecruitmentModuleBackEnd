using RecruitmentModule.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Domain.IRepository
{
    public interface IApplicantRepository
    {
        int Add(ApplicantAddVM applicantAddVM);
        int ApplicantCount(int jobId);
    }
}
