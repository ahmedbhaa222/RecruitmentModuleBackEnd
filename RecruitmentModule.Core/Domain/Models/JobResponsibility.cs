using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentModule.Core.Domain.Models
{
    [Table("JobResponsibilities")]
    public class JobResponsibility
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
