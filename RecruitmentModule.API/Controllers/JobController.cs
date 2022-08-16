using Microsoft.AspNetCore.Mvc;
using RecruitmentModule.Core.Application.IServices;
using RecruitmentModule.Core.Application.ViewModels;

namespace RecruitmentModule.API.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [Route("GetMany")]
        [HttpGet]
        public IActionResult GetMany(int pageNumber = 1, int take = 3, string jobTitle = null)
        {
           return Ok(_jobService.GeManyPaged(pageNumber, take, jobTitle));
        }

        [Route("GetAllAvailble")]
        [HttpGet]
        public IActionResult GetAllAvailble()
        {
            return Ok(_jobService.GetAllAvailble());
        }

        [Route("GetCategories")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_jobService.GetJobCategories());
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
           return Ok(_jobService.GetById(id));
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(JobAddVM jobAddVM)
        {
            return Ok(_jobService.Add(jobAddVM));
        }

        [Route("Edit")]
        [HttpPut]
        public IActionResult Edit(JobEditVM jobEditVM)
        {
            return Ok(_jobService.Edit(jobEditVM));
        }
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(int jobId)
        {
            return Ok(_jobService.Delete(jobId));
        }

    }
}
