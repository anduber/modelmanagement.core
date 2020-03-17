using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Model.QueryModel
{
    public class ContactInformationListModel
    {
        public string ContactInfoId { get; set; }
        public string ContactMechTypeId { get; set; }
        public EntityDescription ContactMechType { get; set; }
        public string PersonId { get; set; }
        public string ContactUrl { get; set; }
    }
}
