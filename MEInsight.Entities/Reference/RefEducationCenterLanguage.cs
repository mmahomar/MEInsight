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
    [Table("RefEducationCenterLanguage")]
    public class RefEducationCenterLanguage
    {
        public RefEducationCenterLanguage()
        {
            EducationCenters = new HashSet<EducationCenter>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EducationCenter Language Id")]
        [Column(Order = 0)]
        public int RefEducationCenterLanguageId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "EducationCenter Language Code")]
        [Column(Order = 1)]
        public string EducationCenterLanguageCode { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "EducationCenter Language")]
        [Column(Order = 2)]
        public string EducationCenterLanguage { get; set; } = null!;

        public virtual ICollection<EducationCenter> EducationCenters { get; set; }
    }
}
