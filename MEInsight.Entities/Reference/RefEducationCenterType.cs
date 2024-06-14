using MEInsight.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Reference
{
    [Table("RefEducationCenterType")]
    public class RefEducationCenterType
    {
        public RefEducationCenterType()
        {
            EducationCenters = new HashSet<EducationCenter>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EducationCenter Type Id")]
        [Column(Order = 0)]
        public int RefEducationCenterTypeId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "EducationCenter Type Code")]
        [Column(Order = 1)]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "EducationCenter Type")]
        [Column(Order = 2)]
        public string EducationCenterType { get; set; } = null!;

        public virtual ICollection<EducationCenter> EducationCenters { get; set; }
    }
}
