﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEInsight.Entities.Core;

namespace MEInsight.Entities.Reference
{
    [Table("RefLocationType")]
    public class RefLocationType
    {
        public RefLocationType()
        {
            Locations = new HashSet<RefLocation>();
        }

        [Key]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Location Type Id")]
        [Column(Order = 0)]
        public int RefLocationTypeId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(25)]
        [Display(Name = "Location Type Code")]
        [Column(Order = 1)]
        public string Code { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [MaxLength(150)]
        [Display(Name = "Location Type")]
        [Column(Order = 2)]
        public string LocationType { get; set; } = null!;

        [Required(ErrorMessage = "The {0} field is required.")]
        [Display(Name = "Location Level")]
        [Column(Order = 3)]
        public int LocationLevel { get; set; }

        public LocationTypeLanguage? RefLocationTypeJSON { get; set; }
        public class LocationTypeLanguage
        {
            public List<Language> RefLocationTypeJSON { get; } = new();
        }
        public virtual ICollection<RefLocation> Locations { get; set; }
    }
}
