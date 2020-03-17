using System;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.AppService;
using ModelManagement.Core.Data.Data.Context;

namespace ModelManagement.Core.Business.Business.Query
{
    public class CommonDataQuery
    {
        private ModelManagementContext _context;

        public CommonDataQuery(ModelManagementContext context)
        {
            _context = context;
        }
    }

    public class ListGeos : QueryCommandBase, IQuery
    {
        public string GeoTypeId { get; set; }
        public string GeoId { get; set; }
        public string GeoIdTo { get; set; }
        public QueryResult Execute()
        {
            var queryService = new CommonDataQueryAppService();
            if (!string.IsNullOrEmpty(GeoTypeId))
            {
                return Utility.QuerySuccessResult(queryService.ListGeos(GeoTypeId));
            }
            else if (!string.IsNullOrEmpty(GeoIdTo))
            {
                return Utility.QuerySuccessResult(queryService.ListGeoToAssoc(GeoIdTo));
            }
            else
            {
                return Utility.QuerySuccessResult(queryService.ListGeosFromAssoc(GeoId));
            }
        }
    }

    public class LookupEnum : QueryCommandBase, IQuery
    {
        public string EnumTypeId { get; set; }
        public QueryResult Execute()
        {
            return Utility.QuerySuccessResult(new CommonDataQueryAppService().LookupEnumByType(EnumTypeId));
        }
    }

    public class LookupCategoryType:QueryCommandBase,IQuery
    {
        public QueryResult Execute()
        {
            return Utility.QuerySuccessResult(new CommonDataQueryAppService().LookupCategoryType());
        }
    }

    public class LookupCategoryTypeQuery:QueryCommandBase,IQuery
    {
        public QueryResult Execute()
        {
            return new CommonDataQueryAppService().LookupCategoryType(QueryParamArg);
        }
    }

    public class LookupOffersQuery:QueryCommandBase,IQuery
    {
        public QueryResult Execute()
        {
            return new CommonDataQueryAppService().LookupOffersQuery();
        }
    }

    public class LookupContactMechTypeQuery:QueryCommandBase,IQuery
    {
        public QueryResult Execute()
        {
            return new CommonDataQueryAppService().LookupContactMechType(QueryParamArg);
        }
    }

    public class ListOfferTypeQuery : QueryCommandBase, IQuery
    {
        public QueryResult Execute()
        {
            QueryParamArg.SetDefaultSortColumn();
            return new CommonDataQueryAppService().ListOfferType(QueryParamArg);
        }
    }

    public class ListOfferItemTypeQuery : QueryCommandBase, IQuery
    {
        public string OfferTypeId { get; set; }
        public QueryResult Execute()
        {
            QueryParamArg.SetDefaultSortColumn();
            return new CommonDataQueryAppService().ListOfferItemType(OfferTypeId, QueryParamArg);
        }
    }
}
