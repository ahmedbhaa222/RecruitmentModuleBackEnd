using RecruitmentModule.Core.Application.ViewModels;
using RecruitmentModule.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Domain.IRepository
{
    public interface IJobRepository
    {
        List<Job> GeManyPaged(int pageNumber=1 , int take =3 , string jobTitle = null);
        int Count(string jobTitle = null);

        List<JobCategory> GetJobCategories();
        List<Job> GetAllAvailble();
        Job GeById(int id);
        int Add(JobAddVM job);
        int Edit(JobEditVM job);
        int Delete(int jobId);
    }
}
