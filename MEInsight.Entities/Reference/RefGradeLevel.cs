using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEInsight.Entities.Programs;
using MEInsight.Entities.Core;

namespace MEInsight.Entities.Reference
{
    [Table("RefGradeLevel")]
    public class RefGradeLevel
    {
        public RefGradeLevel()
        {
            SchoolEnrollments = new HashSet<EducationCenterEnrollment>();
            SchoolClassrooms = new HashSet<EducationCenterClassroom>();
            //TLMMaterials = new HashSet<TLMMaterial>();
            Groups = new HashSet<Group>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Grade Level Id")]
        [Column(Order = 0)]
        public int RefGradeLevelId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "Grade Level Code")]
        [Column(Order = 1)]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "Grade Level")]
        [Column(Order = 2)]
        public string GradeLevel { get; set; } = null!;

        [MaxLength(10)]
        [Display(Name = "Grade Id")]
        [Column(Order = 3)]
        public string? GradeLevelId { get; set; }

        public virtual ICollection<EducationCenterEnrollment> SchoolEnrollments { get; set; }
        public virtual ICollection<EducationCenterClassroom> SchoolClassrooms { get; set; }
        //public virtual ICollection<TLMMaterial> TLMMaterials { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
