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
    [Table("RefEducationCenterLocation")]
    public class RefEducationCenterLocation
    {
        public RefEducationCenterLocation()
        {
            EducationCenters = new HashSet<EducationCenter>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EducationCenter Location Id")]
        [Column(Order = 0)]
        public int RefEducationCenterLocationId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "EducationCenter Location Code")]
        [Column(Order = 1)]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "EducationCenter Location")]
        [Column(Order = 2)]
        public string EducationCenterLocation { get; set; } = null!;

        public virtual ICollection<EducationCenter> EducationCenters { get; set; }
    }
}
