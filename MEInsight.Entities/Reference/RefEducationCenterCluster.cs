using MEInsight.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MEInsight.Entities.Reference
{
    [Table("RefEducationCenterCluster")]
    [Index("RefLocationId", Name = "IX_RefSchoolCluster_RefLocationId")]
    public class RefEducationCenterCluster
    {
        public RefEducationCenterCluster()
        {
            EducationCenters = new HashSet<EducationCenter>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "EducationCenter Cluster Id")]
        [Column(Order = 0)]
        public int RefEducationCenterClusterId { get; set; }

        [MaxLength(25)]
        [Display(Name = "EducationCenter Cluster Code")]
        [Column(Order = 1)]
        public string? Code { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "EducationCenter Cluster")]
        [Column(Order = 2)]
        public string EducationCenterCluster { get; set; } = null!;

        [Display(Name = "Location")]
        [Column(Order = 3)]
        public string? RefLocationId { get; set; }

        [ForeignKey("RefLocationId")]
        [Display(Name = "Location")]
        public virtual RefLocation? Locations { get; set; }

        public virtual ICollection<EducationCenter> EducationCenters { get; set; }
    }
}
