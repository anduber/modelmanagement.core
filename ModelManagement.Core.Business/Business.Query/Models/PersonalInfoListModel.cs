using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class PersonalInfoListModel
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string UserNumber { get; set; }
        public string UserName { get; set; }
        public string PrimaryEmail { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }

    public class GetPersonalInfoListModel:EntityCount
    {
        public List<PersonalInfoListModel> PersonalInfoList { get; set; }
    }


}
