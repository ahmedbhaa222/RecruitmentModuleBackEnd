using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitmentModule.Core.Domain.Models
{
    [Table("JobCategories")]
    public class JobCategory
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
    }
}
