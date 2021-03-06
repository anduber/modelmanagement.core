﻿using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Geo:Entity
    {
        public Geo()
        {
            GeoId_GeoAssoc = new List<GeoAssoc>();
            GeoIdTo_GeoAssoc = new List<GeoAssoc>();
            PersonId_PersonalInformation = new List<PersonalInformation>();
            Geo_JobPostAgentLocations = new List<JobPost>();
            Geo_JobPostJobLocationGeoes = new List<JobPost>();
            Country_PersonGeoId_PersonalInformation = new List<PersonalInformation>();
            City_PersonGeoId_PersonalInformation = new List<PersonalInformation>();
        }
        public string GeoId { get; set; }
        public string GeoTypeId { get; set; }
        public string GeoName { get; set; }
        public string GeoCode { get; set; }
        public string DialingCode { get; set; }
        public virtual GeoType GeoTypeId_GeoType { get; set; }
        public virtual List<GeoAssoc> GeoId_GeoAssoc { get; set; }
        public virtual List<GeoAssoc> GeoIdTo_GeoAssoc { get; set; }
        public virtual List<PersonalInformation> PersonId_PersonalInformation { get; set; }
        public virtual List<JobPost> Geo_JobPostJobLocationGeoes { get; set; }
        public virtual List<JobPost> Geo_JobPostAgentLocations { get; set; }
        public virtual List<PersonalInformation> Country_PersonGeoId_PersonalInformation { get; set; }
        public virtual List<PersonalInformation> City_PersonGeoId_PersonalInformation { get; set; }
    }
}
