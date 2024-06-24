using MEInsight.Entities.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEInsight.Entities.Reference
{
    [Table("RefLocation")]
    public class RefLocation
    {
        public RefLocation()
        {
            Locations = new HashSet<RefLocation>();
            Organizations = new HashSet<Organization>();
            Participants = new HashSet<Participant>();
            SchoolClusters = new HashSet<RefEducationCenterCluster>();
        }

        public string RefLocationId { get; set; } = null!;

        public string? LocationName { get; set; } = null!;

        public int RefLocationTypeId { get; set; }

        public string? ParentLocationId { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        // Navigation properties
        [ForeignKey("RefLocationTypeId")]
        [Display(Name = "Location Type")]
        public virtual RefLocationType? LocationTypes { get; set; } = null!;

        [ForeignKey("ParentLocationId")]
        [Display(Name = "Parent Location")]
        public virtual RefLocation? ParentLocations { get; set; }

        public LocationData? Data { get; set; }
        public class LocationData
        {
            public List<Language> LocationLanguages { get; } = new();
        }

        //TODO
        // Add LocationReference

        public virtual ICollection<RefLocation> Locations { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
        public virtual ICollection<RefEducationCenterCluster> SchoolClusters { get; set; }
    }



    //public class RefLocation
    //{
    //    public RefLocation()
    //    {

    //    }
    //    public string RefLocationId { get; set; }

    //    public string LocationName { get; set; }

    //    public string RefLocationTypeId { get; set; }

    //}
}
