using MEInsight.Entities.Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEInsight.Entities.Core;

namespace MEInsight.Entities.Reference
{
    [Table("RefProgramType")]
    public class RefProgramType
    {
        public RefProgramType()
        {
            Programs = new HashSet<Program>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Program Type Id")]
        public int RefProgramTypeId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "Program Type Code")]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "Program Type")]
        public string ProgramType { get; set; } = null!;

        public ProgramTypeData? RefProgramTypeJSON { get; set; }
        public class ProgramTypeData
        {
            public List<Language> RefProgramTypeJSON { get; } = new();
        }

        public virtual ICollection<Program> Programs { get; set; }
    }
}
