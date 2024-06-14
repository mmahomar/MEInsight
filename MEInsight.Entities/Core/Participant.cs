using MEInsight.Entities.Reference;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MEInsight.Entities.Core
{
    [Table("Participant")]
    public class Participant : BaseEntity
    {
        public Participant()
        {
            
        }
        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ParticipantId")]
        public Guid ParticipantId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Registration Date")]
        [DataType(DataType.Date)]
        public DateOnly RegistrationDate { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Organization")]
        public Guid? OrganizationId { get; set; }
        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Participant Type")]
        public int RefParticipantTypeId { get; set; }

        [Display(Name = "Participant Cohort")]
        public int? RefParticipantCohortId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100)]
        //[Display(Name = "Participant Code")]
        public string? Code { get; set; } = null!;
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(35)]
        [Display(Name = "First name")]
        public string? FirstName { get; set; } = null!;

        [StringLength(35)]
        [Display(Name = "Middle name")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(35)]
        [Display(Name = "Surname/Last name")]
        public string? LastName { get; set; } = null!;
        [Display(Name = "Name")]
        public string? NameFirst
        {
            get
            {
                return string.Concat(FirstName, " ", MiddleName ?? "", " ", LastName);
            }
        }
        [Display(Name = "Name")]
        public string? Name
        {
            get
            {
                return string.Concat(LastName, ", ", FirstName, MiddleName == null ? "" : " " + MiddleName);
            }
        }
        [Display(Name = "Name")]
        public string? NameId
        {
            get
            {
                return string.Concat(LastName, ", ", FirstName, MiddleName == null ? "" : " " + MiddleName, " (", Code, ")");
            }
        }
        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Sex")]
        public int? RefSexId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Age")]
        public int? Age { get; set; }
        [Display(Name = "Has Disability?")]
        public bool? Disability { get; set; }
        [Display(Name = "Disability Type")]
        public int? RefDisabilityTypeId { get; set; }
        [StringLength(20)]
        [Display(Name = "Phone")]
        public string? Phone { get; set; }
        [StringLength(20)]
        [Display(Name = "Mobile")]
        public string? Mobile { get; set; }
        [StringLength(320)]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [StringLength(200)]
        [Display(Name = "Facebook")]
        public string? Facebook { get; set; }
        [StringLength(200)]
        [Display(Name = "Instant Messenger")]
        public string? InstantMessenger { get; set; }
        [Display(Name = "Location")]
        public string? RefLocationId { get; set; }

        public string? Address { get; set; }
        [ForeignKey("OrganizationId")]
        [Display(Name = "Organization")]
        public virtual Organization? Organizations { get; set; }

        [ForeignKey("RefParticipantTypeId")]
        [Display(Name = "Participant Type")]
        public virtual RefParticipantType? ParticipantTypes { get; set; }

        [ForeignKey("RefParticipantCohortId")]
        [Display(Name = "Participant Cohort")]
        public virtual RefParticipantCohort? ParticipantCohorts { get; set; }

        [ForeignKey("RefSexId")]
        [Display(Name = "Sex")]
        public virtual RefSex? Sex { get; set; }

        [ForeignKey("RefDisabilityTypeId")]
        [Display(Name = "Disability Type")]
        public virtual RefDisabilityType? DisabilityTypes { get; set; }

        [ForeignKey("RefLocationId")]
        [Display(Name = "Location")]
        public virtual RefLocation? Locations { get; set; }

        //[InverseProperty("Participants")]
        //public virtual ICollection<GroupEnrollment> GroupEnrollments { get; set; }

        [IgnoreDataMember]
        public string? AdditionalData { get; set; }

        [Display(Name = "JSON Object data")]
        [NotMapped]
        public object? Data
        {
            get { return (AdditionalData == null) ? null : JsonSerializer.Deserialize(AdditionalData, typeof(object)); }
            set { AdditionalData = JsonSerializer.Serialize(value); }
        }

    }
}
