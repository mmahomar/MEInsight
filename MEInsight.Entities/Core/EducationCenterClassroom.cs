using MEInsight.Entities.Reference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Core
{
    [Table("EducationCenterClassroom")]
    public class EducationCenterClassroom : BaseEntity
    {
        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EducationCenter Classroom")]
        [Column(Order = 0)]
        public Guid EducationCenterClassroomId { get; set; }

        // TODO Add Period

        [Required(ErrorMessage = "The {0} field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Registration Date")]
        [Column(Order = 1)]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Organization")]
        [Column(Order = 2)]
        public Guid OrganizationId { get; set; }

        [Display(Name = "EducationCenter Period")]
        [Column(Order = 3)]
        public int EducationCenterPeriodId { get; set; }

        [Display(Name = "Grade Level")]
        [Column(Order = 4)]
        public int RefGradeLevelId { get; set; }

        [Display(Name = "Classrooms")]
        [Column(Order = 5)]
        public int? Classrooms { get; set; }

        [Display(Name = "Classes")]
        [Column(Order = 6)]
        public int? Classes { get; set; }

        [ForeignKey("EducationCenterPeriodId")]
        [Display(Name = "EducationCenter Period")]
        public virtual EducationCenterPeriod EducationCenterPeriods { get; set; } = null!;

        [ForeignKey("OrganizationId")]
        [Display(Name = "School")]
        public virtual EducationCenter EducationCenters { get; set; } = null!;

        [ForeignKey("RefGradeLevelId")]
        [Display(Name = "Grade Level")]
        public virtual RefGradeLevel GradeLevels { get; set; } = null!;

    }
}
