using System;
using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class PersonalInformationQueryModel
    {
        public string PersonId { get; set; }
        public string UserNumber { get; set; }
        public string UserName { get; set; }
        public string PrimaryCategoryTypeId { get; set; }
        public EntityDescription PrimaryCategoryType { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string MaritialStatusEnumId { get; set; }
        public string NationalityEnumId { get; set; }
        public string ProfilePicUrl { get; set; }
        public string ProfilePicFileUploadId { get; set; }
        public string StatusId { get; set; }
        public EntityDescription Status { get; set; }
        public int Age { get; set; }
    }
}
