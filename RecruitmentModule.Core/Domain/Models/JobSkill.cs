using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentModule.Core.Domain.Models
{
    public class JobSkill
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}
