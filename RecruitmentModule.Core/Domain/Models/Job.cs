using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentModule.Core.Domain.Models
{
    [Table("Job")]
    public class Job
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int MaximumApplications { get; set; }
        public bool IsDeleted { get; set; } // For Soft Delete
        public  JobCategory Category { get; set; }
        public virtual IList<JobSkill> Skills { get; set; }
        public virtual IList<JobResponsibility> Responsibilities { get; set; }

    }
}
