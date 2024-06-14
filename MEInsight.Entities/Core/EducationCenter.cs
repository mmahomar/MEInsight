using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEInsight.Entities.Reference;

namespace MEInsight.Entities.Core
{
    [Table("EducationCenter")]
    public class EducationCenter
    {
        public EducationCenter()
        {
            EducationCenterEnrollments = new HashSet<EducationCenterEnrollment>();
            EducationCenterClassrooms = new HashSet<EducationCenterClassroom>();
        }
        [Key]
        public Guid OrganizationId { get; set; }

        [StringLength(100)]
        [Display(Name = "EducationCenter Code")]
        [Column(Order = 1)]
        [Remote(action: "VerifySchoolCode", controller: "RemoteValidations", HttpMethod = "POST", ErrorMessage = "This Code already exists.", AdditionalFields = "SchoolCodeInitialValue")]
        public string? Code { get; set; }

        [Display(Name = "EducationCenter Type")]
        [Column(Order = 2)]
        public int? RefEducationCenterTypeId { get; set; }

        [Display(Name = "EducationCenter Location")]
        [Column(Order = 3)]
        public int? RefEducationCenterLocationId { get; set; }

        [Display(Name = "EducationCenter Language")]
        [Column(Order = 4)]
        public int? RefEducationCenterLanguageId { get; set; }

        [Display(Name = "EducationCenter Administration Type")]
        [Column(Order = 5)]
        public int? RefEducationCenterAdministrationTypeId { get; set; }

        [Display(Name = "Partner")]
        [Column(Order = 6)]
        public Guid? PartnerId { get; set; }

        [Display(Name = "Is Cluster Center?")]
        [Column(Order = 7)]
        public bool? IsClusterCenter { get; set; }

        [Display(Name = "EducationCenter Cluster")]
        [Column(Order = 8)]
        public int? RefEducationCenterClusterId { get; set; }

        [Display(Name = "EducationCenter Status")]
        [Column(Order = 9)]
        public int? RefEducationCenterStatusId { get; set; }

        [StringLength(150)]
        [Display(Name = "HeadTeacher")]
        [Column(Order = 10)]
        public string? HeadTeacher { get; set; }

        [ForeignKey("RefEducationCenterTypeId")]
        [Display(Name = "EducationCenter Type")]
        public virtual RefEducationCenterType? EducationCenterTypes { get; set; }

        [ForeignKey("RefEducationCenterLocationId")]
        [Display(Name = "EducationCenter Location")]
        public virtual RefEducationCenterLocation? EducationCenterLocations { get; set; }

        [ForeignKey("RefEducationCenterLanguageId")]
        [Display(Name = "EducationCenter Language")]
        public virtual RefEducationCenterLanguage? EducationCenterLanguages { get; set; }

        [ForeignKey("RefEducationCenterAdministrationTypeId")]
        [Display(Name = "EducationCenter Administration Type")]
        public virtual RefEducationCenterAdministrationType? EducationCenterAdministrationTypes { get; set; }

        [ForeignKey("RefEducationCenterClusterId")]
        [Display(Name = "EducationCenter Cluster")]
        public virtual RefEducationCenterCluster? EducationCenterClusters { get; set; }

        [ForeignKey("RefEducationCenterStatusId")]
        [Display(Name = "Status")]
        public virtual RefEducationCenterStatus? EducationCenterStatus { get; set; }

        [ForeignKey("OrganizationId")]
        [Display(Name = "Organizations")]
        public virtual Organization? Organizations { get; set; }
        public virtual ICollection<EducationCenterEnrollment> EducationCenterEnrollments { get; set; }

        public virtual ICollection<EducationCenterClassroom> EducationCenterClassrooms { get; set; }

    }
}
