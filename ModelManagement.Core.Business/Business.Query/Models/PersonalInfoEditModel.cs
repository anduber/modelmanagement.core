using System;
using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class PersonalInfoEditModel
    {
        public string PersonId { get; set; }
        public string UserNumber { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public byte[] ProfilePic { get; set; }
        public string ProfilePicFileId { get; set; }
        public string GeoId { get; set; }
        public string CountryGeoId { get; set; }
        public string CityGeoId { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public int Age { get; set; }
        public List<KeyDescription> Categories { get; set; }
    }
}
