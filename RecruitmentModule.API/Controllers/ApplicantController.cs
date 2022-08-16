using Microsoft.AspNetCore.Mvc;
using RecruitmentModule.Core.Application.IServices;
using RecruitmentModule.Core.Application.ViewModels;

namespace RecruitmentModule.API.Controllers
{
    [Route("api/applicant")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(ApplicantAddVM applicantAddVM)
        {
            return Ok(_applicantService.Add(applicantAddVM));
        }
    }
}