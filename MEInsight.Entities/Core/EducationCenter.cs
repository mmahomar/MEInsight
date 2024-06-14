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
    [Table("School")]
    public class EducationCenter
    {
        public EducationCenter()
        {
            SchoolEnrollments = new HashSet<EducationCenterEnrollment>();
            SchoolClassrooms = new HashSet<EducationCenterClassroom>();
        }
        [Key]
        public Guid OrganizationId { get; set; }

        [StringLength(100)]
        [Display(Name = "School Code")]
        [Column(Order = 1)]
        [Remote(action: "VerifySchoolCode", controller: "RemoteValidations", HttpMethod = "POST", ErrorMessage = "This Code already exists.", AdditionalFields = "SchoolCodeInitialValue")]
        public string? Code { get; set; }

        [Display(Name = "School Type")]
        [Column(Order = 2)]
        public int? RefSchoolTypeId { get; set; }

        [Display(Name = "School Location")]
        [Column(Order = 3)]
        public int? RefSchoolLocationId { get; set; }

        [Display(Name = "School Language")]
        [Column(Order = 4)]
        public int? RefSchoolLanguageId { get; set; }

        [Display(Name = "School Administration Type")]
        [Column(Order = 5)]
        public int? RefSchoolAdministrationTypeId { get; set; }

        [Display(Name = "Partner")]
        [Column(Order = 6)]
        public Guid? PartnerId { get; set; }

        [Display(Name = "Is Cluster Center?")]
        [Column(Order = 7)]
        public bool? IsClusterCenter { get; set; }

        [Display(Name = "School Cluster")]
        [Column(Order = 8)]
        public int? RefSchoolClusterId { get; set; }

        [Display(Name = "School Status")]
        [Column(Order = 9)]
        public int? RefSchoolStatusId { get; set; }

        [StringLength(150)]
        [Display(Name = "HeadTeacher")]
        [Column(Order = 10)]
        public string? HeadTeacher { get; set; }

        [ForeignKey("RefSchoolTypeId")]
        [Display(Name = "School Type")]
        public virtual RefEducationCenterType? SchoolTypes { get; set; }

        [ForeignKey("RefSchoolLocationId")]
        [Display(Name = "School Location")]
        public virtual RefEducationCenterLocation? SchoolLocations { get; set; }

        [ForeignKey("RefSchoolLanguageId")]
        [Display(Name = "School Language")]
        public virtual RefEducationCenterLanguage? SchoolLanguages { get; set; }

        [ForeignKey("RefSchoolAdministrationTypeId")]
        [Display(Name = "School Administration Type")]
        public virtual RefEducationCenterAdministrationType? SchoolAdministrationTypes { get; set; }

        [ForeignKey("RefSchoolClusterId")]
        [Display(Name = "School Cluster")]
        public virtual RefEducationCenterCluster? SchoolClusters { get; set; }

        [ForeignKey("RefSchoolStatusId")]
        [Display(Name = "Status")]
        public virtual RefEducationCenterStatus? SchoolStatus { get; set; }

        [ForeignKey("OrganizationId")]
        [Display(Name = "Organizations")]
        public virtual Organization? Organizations { get; set; }
        public virtual ICollection<EducationCenterEnrollment> SchoolEnrollments { get; set; }

        public virtual ICollection<EducationCenterClassroom> SchoolClassrooms { get; set; }

    }
}
