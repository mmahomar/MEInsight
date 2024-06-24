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
    [Table("RefSex")]
    public class RefSex
    {
        public RefSex()
        {
            Participants = new HashSet<Participant>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Sex Id")]
        [Column(Order = 0)]
        public int RefSexId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(50)]
        [Display(Name = "Sex")]
        [Column(Order = 1)]
        public string Sex { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(1)]
        [Display(Name = "Sex")]
        [Column(Order = 2)]
        public string SexId { get; set; } = null!;

        public RefSexData? RefSexJSON { get; set; }
        public class RefSexData
        {
            public List<Language> RefSexJSON { get; } = new();
        }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}
