﻿using MEInsight.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Reference
{
    [Table("RefEducationCenterAdministrationType")]
    public class RefEducationCenterAdministrationType
    {
        public RefEducationCenterAdministrationType()
        {
            EducationCenters = new HashSet<EducationCenter>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Education Center Administration Type Id")]
        [Column(Order = 0)]
        public int RefEducationCenterAdministrationTypeId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "Education Center Administration Type Code")]
        [Column(Order = 1)]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "Education Center Administration Type")]
        [Column(Order = 2)]
        public string EducationCenterAdministrationType { get; set; } = null!;
        public virtual ICollection<EducationCenter> EducationCenters { get; set; }
    }
}
