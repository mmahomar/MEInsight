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
    [Table("RefDisabilityType")]
    public class RefDisabilityType
    {
        public RefDisabilityType()
        {
            Participants = new HashSet<Participant>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Disability Type Id")]
        [Column(Order = 0)]
        public int RefDisabilityTypeId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "Disability Type Code")]
        [Column(Order = 1)]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "Disability Type")]
        [Column(Order = 2)]
        public string DisabilityType { get; set; } = null!;

        public DisabilityData? Data { get; set; }
        public class DisabilityData
        {
            public List<Language> DisabilityLanguages { get; } = new();
        }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
