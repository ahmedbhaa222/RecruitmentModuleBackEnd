using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentModule.Core.Application.ViewModels
{
    public class JobListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int MaximumApplications { get; set; }

    }
}
