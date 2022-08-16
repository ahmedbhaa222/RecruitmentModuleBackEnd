using RecruitmentModule.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Application.IServices
{
    public interface IApplicantService
    {
        ResponseVM<string> Add(ApplicantAddVM applicantAddVM);

    }
}
