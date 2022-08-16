using RecruitmentModule.Core.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Application.IServices
{
    public interface IJobService
    {
        PagedResponseVM<List<JobListVM>> GeManyPaged(int pageNumber = 1, int take = 3, string jobTitle = null);
        ResponseVM<List<JobCategoryVM>> GetJobCategories();
        ResponseVM<JobVM> GetById(int id);
        ResponseVM<List<JobListVM>> GetAllAvailble();
        ResponseVM<string> Add(JobAddVM job);
        ResponseVM<string> Edit(JobEditVM job);
        ResponseVM<string> Delete(int jobId);
    }
}
