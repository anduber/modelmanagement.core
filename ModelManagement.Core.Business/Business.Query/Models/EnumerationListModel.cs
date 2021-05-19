using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class EnumerationListModel:QueryDataResultModel
    {
        public string EnumerationId { get; set; }
        public string EnumerationTypeId { get; set; }
        public string Description { get; set; }
        public string EnumCode { get; set; }
        public string SequenceId { get; set; }
        public string IsActive { get; set; }
    }
}
