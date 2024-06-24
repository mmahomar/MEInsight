using MEInsight.Entities.Core;
using MEInsight.Entities.Programs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Reference
{
    [Table("RefOrganizationType")]
    public class RefOrganizationType
    {
        public RefOrganizationType()
        {
            Organizations = new HashSet<Organization>();
            Programs = new HashSet<Program>();
        }
        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Organization Type Id")]
        public int RefOrganizationTypeId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "Organization Type Name")]
        public string? RefOrganizationTypeName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "Organization Type Code")]
        public string Code { get; set; } = null!;

        public OrganizationTypeData? RefOrganizationTypeJSON { get; set; }
        public class OrganizationTypeData
        {
            public List<Language> RefOrganizationTypeJSON { get; } = new();
        }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Program> Programs { get; set; }
    }
}
