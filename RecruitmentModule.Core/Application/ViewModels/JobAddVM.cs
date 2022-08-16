using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecruitmentModule.Core.Application.ViewModels
{
    public class JobAddVM
    {
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int MaximumApplications { get; set; }
        public virtual List<JobSkillVM> Skills { get; set; }
        public virtual List<JobResponsibilityVM> Responsibilities { get; set; }
    }
}
