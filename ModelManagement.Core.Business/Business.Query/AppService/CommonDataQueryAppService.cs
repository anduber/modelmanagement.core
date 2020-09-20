using System.Collections.Generic;
using System.Linq;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.Models;


namespace ModelManagement.Core.Business.Business.Query.AppService
{
    public class CommonDataQueryAppService : QueryAppService
    {
        public CommonDataQueryAppService()
        {

        }

        public List<GeoListModel> ListGeos(string geoTypeId)
        {
            var geos = ModelManagementContext().Geos.Where(t => t.GeoTypeId == geoTypeId).OrderBy(o => o.GeoName);
            return geos.ToList<GeoListModel>();
        }

        public List<GeoListModel> ListGeosFromAssoc(string geoId)
        {
            var geos = ModelManagementContext().GeoAssoces.Where(t => t.GeoId == geoId).Select(v => v.GeoIdTo_Geo).OrderBy(o => o.GeoName);
            return geos.ToList<GeoListModel>();
        }

        public List<GeoListModel> ListGeoToAssoc(string geoIdTo)
        {
            var geoId = ModelManagementContext().GeoAssoces.FirstOrDefault(t => t.GeoIdTo == geoIdTo)?.GeoId;
            return ListGeosFromAssoc(geoId);
        }

        public QueryResult LookupEnumByType(string enumTypeId,QueryParamArg queryParamArg)
        {
            queryParamArg.SetDefaultSortColumn("SequenceId");
            var enums =
                ModelManagementContext()
                    .Enumerations.Where(t => t.EnumerationTypeId == enumTypeId);
            return enums.QueryResultList<KeyDescription>(queryParamArg);
        }

        public List<KeyDescriptionId> LookupCategoryType()
        {
            var categoryTypes = ModelManagementContext().CategoryTypes.OrderBy(o => o.Description);
            return categoryTypes.ToLookUpKeyDescId();
        }

        public QueryResult LookupCategoryType(QueryParamArg queryParamArg)
        {
            var categoryTypes = ModelManagementContext()
                .CategoryTypes.Where(t=>t.IsActive=="Y")
                .GroupBy(g => g.ParentTypeId).ToList()
                .Select(s => new CategoryTypeLookupModel
                {
                    CategoryTypeParent = s.FirstOrDefault(t=>t.CategoryTypeId==s.Key)?.Description,
                    CategoryTypes = s.AsQueryable().Where(t=>t.CategoryTypeId!=s.Key).ToLookUp()
                }).ToList();
            return Utility.QuerySuccessResult(categoryTypes);
        }

        public QueryResult LookupOffersQuery()
        {
            var offerTypes = ModelManagementContext().OfferTypes.Where(t=>t.IsActive=="Y").OrderBy(o => o.Sequence).ToList<OfferListModel>();
            //var offerItemTypes = ModelManagementContext().OfferItemTypes.Where(t=>t.IsActive=="Y").ToList<OfferItemTypeListModel>();
            //foreach (var offerType in offerTypes)
            //{
            //    SetOfferTypes(offerItemTypes, offerType.OfferItemTypes);
            //}
            return Utility.QuerySuccessResult(offerTypes);
        }

        private static void SetOfferTypes(IEnumerable<OfferItemTypeListModel> mainOffers, ICollection<OfferItemTypeListModel> types)
        {
            foreach (var main in mainOffers)
            {
                var x = types.FirstOrDefault(t => t.OfferItemTypeId == main.OfferItemTypeId);
                if (x == null)
                {
                    types.Add(main);
                }
                else
                {
                    x.IsAssigned = true;
                }
            }
        }

        public QueryResult LookupContactMechType(QueryParamArg queryParamArg)
        {
            return ModelManagementContext().ContactMechTypes.Where(t => t.IsActive == "Y").QueryResultList<KeyDescription>(queryParamArg);
        }

        public QueryResult ListOfferType(QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .OfferTypes.Where(
                        t =>
                            string.IsNullOrEmpty(queryParamArg.SearchText) ||
                            t.Description.Contains(queryParamArg.SearchText) ||
                            t.Sequence.Contains(queryParamArg.SearchText) ||
                            t.LongDescription.Contains(queryParamArg.SearchText))
                    .QueryResultList<OfferTypeListModel>(queryParamArg);
        }

        public QueryResult ListOfferItemType(string offertypeId, QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .OfferItemTypes.Where(
                        t =>
                            (string.IsNullOrEmpty(offertypeId) ||
                             t.OfferItemTypeId_OfferType.Any(l => l.OfferTypeId == offertypeId)) &&
                            (string.IsNullOrEmpty(queryParamArg.SearchText) ||
                             t.Description.Contains(queryParamArg.SearchText) ||
                             t.Sequence.Contains(queryParamArg.SearchText)))
                    .QueryResultList<OfferItemTypeListModel>(queryParamArg);
        }
    }
}
