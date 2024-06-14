using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Core
{
    [Table("EducationCenterPeriod")]
    public class EducationCenterPeriod : BaseEntity
    {
        public EducationCenterPeriod()
        {
            EducationCenterEnrollments = new HashSet<EducationCenterEnrollment>();
            EducationCenterClassrooms = new HashSet<EducationCenterClassroom>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "EducationCenter Period")]
        [Column(Order = 0)]
        public int EducationCenterPeriodId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "Period name")]
        [Column(Order = 1)]
        public string PeriodName { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Column(Order = 2)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [Column(Order = 3)]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<EducationCenterEnrollment> EducationCenterEnrollments { get; set; }
        public virtual ICollection<EducationCenterClassroom> EducationCenterClassrooms { get; set; }

    }
}
