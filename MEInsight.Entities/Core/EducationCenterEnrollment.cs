﻿using MEInsight.Entities.Reference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Core
{
    [Table("EducationCenterEnrollment")]
    public class EducationCenterEnrollment : BaseEntity
    {
        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EducationCenter Enrollment")]
        [Column(Order = 0)]
        public Guid EducationCenterEnrollmentId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Registration Date")]
        [Column(Order = 1)]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Organization")]
        [Column(Order = 2)]
        public Guid? OrganizationId { get; set; }

        [Display(Name = "EducationCenter Period")]
        [Column(Order = 3)]
        public int EducationCenterPeriodId { get; set; }

        [Display(Name = "Participant Type")]
        [Column(Order = 4)]
        public int RefParticipantTypeId { get; set; }

        [Display(Name = "Grade Level")]
        [Column(Order = 5)]
        public int RefGradeLevelId { get; set; }

        [Display(Name = "Male")]
        [Column(Order = 6)]
        public int? Male { get; set; }

        [Display(Name = "Female")]
        [Column(Order = 7)]
        public int? Female { get; set; }

        [Display(Name = "Disabled Male")]
        [Column(Order = 8)]
        public int? DisabledMale { get; set; }

        [Display(Name = "Disabled Female")]
        [Column(Order = 9)]
        public int? DisabledFemale { get; set; }

        [ForeignKey("OrganizationId")]
        [Display(Name = "EducationCenter")]
        public virtual EducationCenter? EducationCenters { get; set; }

        [ForeignKey("SchoolPeriodId")]
        [Display(Name = "School Period")]
        public virtual EducationCenterPeriod EducationCenterPeriods { get; set; } = null!;

        [ForeignKey("RefParticipantTypeId")]
        [Display(Name = "Participant Type")]
        public virtual RefParticipantType ParticipantTypes { get; set; } = null!;

        [ForeignKey("RefGradeLevelId")]
        [Display(Name = "Grade Level")]
        public virtual RefGradeLevel GradeLevels { get; set; } = null!;

    }
}
