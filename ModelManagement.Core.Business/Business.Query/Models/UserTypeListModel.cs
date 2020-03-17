namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class UserTypeListModel
    {
        public string UserTypeId { get; set; }
        public string Description { get; set; }
        public int? ValidNoOfDays { get; set; }
        public double? FeeAmount { get; set; }
        public string LongDescription { get; set; }
    }
}
