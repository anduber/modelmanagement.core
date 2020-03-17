using System;

namespace ModelManagement.Core.Business.Business.Command.CommandArgs
{
    public class PersonalInformationArg
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string MaritialStatusEnumId { get; set; }
        public string GeoId { get; set; }
        public string OfferTypeId { get; set; }
        public string ProfilePicPath { get; set; }
    }
}
