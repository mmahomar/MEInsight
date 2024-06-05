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
    public class Participant : BaseEntity
    {
        public Participant()
        {
            
        }
        [Key]
        public Guid ParticipantId { get; set; }

        public DateOnly RegistrationDate { get; set; }

        public Guid? OrganizationId { get; set; }

        public int RefParticipantTypeId { get; set; }

       public string? ParticipantCode { get; set; } = null!;

         public string? FirstName { get; set; } = null!;

       
        public string? MiddleName { get; set; }

      
        public string? LastName { get; set; } = null!;

        public string? NameFirst
        {
            get
            {
                return string.Concat(FirstName, " ", MiddleName ?? "", " ", LastName);
            }
        }

        public string? Name
        {
            get
            {
                return string.Concat(LastName, ", ", FirstName, MiddleName == null ? "" : " " + MiddleName);
            }
        }

        public string? NameId
        {
            get
            {
                return string.Concat(LastName, ", ", FirstName, MiddleName == null ? "" : " " + MiddleName, " (", ParticipantCode, ")");
            }
        }

        public int? RefSexId { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Age { get; set; }

        public bool? Disability { get; set; }

        public int? RefDisabilityTypeId { get; set; }

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? Facebook { get; set; }

        public string? InstantMessenger { get; set; }

        public string? RefLocationId { get; set; }

        public string? Address { get; set; }

        public virtual Organization? Organizations { get; set; }

       // [ForeignKey("RefParticipantTypeId")]
       // public virtual RefParticipantType? ParticipantTypes { get; set; }

        //[ForeignKey("RefParticipantCohortId")]
        //public virtual RefParticipantCohort? ParticipantCohorts { get; set; }

        //[ForeignKey("RefSexId")]
        //public virtual RefSex? Sex { get; set; }

        //[ForeignKey("RefDisabilityTypeId")]
        //public virtual RefDisabilityType? DisabilityTypes { get; set; }

        [ForeignKey("RefLocationId")]
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
