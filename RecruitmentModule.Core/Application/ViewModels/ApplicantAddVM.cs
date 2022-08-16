using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RecruitmentModule.Core.Application.ViewModels
{
    public class ApplicantAddVM
    {
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public string MobileNumber { get; set; }
        public int JobId { get; set; }
    }
}
