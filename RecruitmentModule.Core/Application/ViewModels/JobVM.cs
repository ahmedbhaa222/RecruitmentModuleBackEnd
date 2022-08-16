using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Application.ViewModels
{
    public class JobVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int MaximumApplications { get; set; }
        public JobCategoryVM Category { get; set; }
        public virtual List<JobSkillVM> Skills { get; set; }
        public virtual List<JobResponsibilityVM> Responsibilities { get; set; }
    }
}
