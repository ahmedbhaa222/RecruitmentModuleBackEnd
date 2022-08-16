
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentModule.Core.Domain.Models
{
    [Table("Applicants")]
    public class Applicant
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(20)]
        public string MobileNumber { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
