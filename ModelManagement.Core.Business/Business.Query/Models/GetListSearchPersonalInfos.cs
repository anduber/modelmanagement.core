using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class GetListSearchPersonalInfos
    {
        public List<PersonalInformationQueryModel> PersonalInfos { get; set; }
        public int TotalCount { get; set; }
    }
}
