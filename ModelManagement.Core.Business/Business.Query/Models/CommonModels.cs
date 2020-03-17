using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class OfferListModel:QueryEntity
    {
        public string OfferTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int? ValidNoOfDays { get; set; }
        public decimal? FeeAmount { get; set; }
        public List<OfferItemTypeListModel> OfferItemTypes { get; set; }
    }

    public class OfferTypeListModel:OfferTypeMainModel
    {
       
    }
    public class OfferTypeEditModel : OfferTypeMainModel
    {

    }
    public class OfferTypeMainModel: QueryEntity
    {
        public string OfferTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int? ValidNoOfDays { get; set; }
        public decimal? FeeAmount { get; set; } 
    }

    public class OfferItemTypeListModel:QueryEntity
    {
        public string OfferItemTypeId { get; set; }
        public string Sequence { get; set; }
        public string Description { get; set; }
        public bool IsAssigned { get; set; }
    }

    public class CategoryTypeLookupModel
    {
        public string CategoryTypeParent { get; set; }
        public List<KeyDescription> CategoryTypes { get; set; }
    }
}
