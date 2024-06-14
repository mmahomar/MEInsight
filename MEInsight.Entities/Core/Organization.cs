using MEInsight.Entities.Reference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MEInsight.Entities.Core
{
    [Table("Organization")]
    public class Organization:BaseEntity
    {
        public Organization()
        {
            Participants = new HashSet<Participant>();
            Organizations = new HashSet<Organization>();
            //Groups = new HashSet<Group>();
            //TLMDistributionsFrom = new HashSet<TLMDistribution>();
            //TLMDistributionsTo = new HashSet<TLMDistribution>();
            //Users = new HashSet<ApplicationUser>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public Guid OrganizationId { get; set; }
        public string? Code { get; set; }
        public string? OrganizationName { get; set; }

        public int? RefOrganizationTypeId { get; set; }

        [ForeignKey("RefOrganizationTypeId")]
        public virtual RefOrganizationType? OrganizationTypes { get; set; } = null!;
        public Guid? ParentOrganizationId { get; set; }

        [ForeignKey("ParentOrganizationId")]
        [Display(Name = "Parent Organization")]
        public virtual Organization? ParentOrganizations { get; set; }
        public string? RefLocationId { get; set; }

        [ForeignKey("RefLocationId")]
        [Display(Name = "Location")]
        public virtual RefLocation? Locations { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public bool IsOrganizationUnit { get; set; } = false;
        public string? Address { get; set; }
        public OrganizationData? Data { get; set; }
        public class OrganizationData
        {
            public string? Description { get; set; }
            public OrganizationContact? Contacts { get; set; }
            public class OrganizationContact
            {
                public string? Phone { get; set; }
                public string? Contact { get; set; }
                
            }
            public List<Language> Languages { get; } = new();
        }
       

        //public Language? Languages { get; set; }

        //public AdditionalData? AdditionalInfo { get; set; }

        //public class AdditionalData
        //{
        //    //Custom JSON object
        //}


        public DateOnly RegistrationDate { get; set; }

        public ICollection<Organization> Organizations { get; set; }
        public ICollection<Participant> Participants { get; set; }


    }


}
