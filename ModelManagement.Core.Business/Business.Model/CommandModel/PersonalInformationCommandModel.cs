using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class PersonalInformationCommandModel
    {
        public PersonalInformationCommandModel()
        {
            CategoryArgs = new List<CategoryArgModel>();
        }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string MaritialStatusEnumId { get; set; }
        public string NationalityEnumId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicPath { get; set; }
        public string PrimaryCategoryTypeId { get; set; }
        public string UserLoginId { get; set; }
        public List<CategoryArgModel> CategoryArgs { get; set; }
    }
}
