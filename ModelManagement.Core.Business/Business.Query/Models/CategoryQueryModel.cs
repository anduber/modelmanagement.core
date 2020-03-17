using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class CategoryQueryModel
    {
        public string PersonId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryTypeId { get; set; }
        public EntityDescription CategoryType { get; set; }
    }

    
}
