using System;
using System.Collections.Generic;
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
            return !string.IsNullOrEmpty(GeoTypeId)
                ? Utility.QuerySuccessResult(queryService.ListGeos(GeoTypeId))
                : Utility.QuerySuccessResult(!string.IsNullOrEmpty(GeoIdTo)
                    ? queryService.ListGeoToAssoc(GeoIdTo)
                    : queryService.ListGeosFromAssoc(GeoId));
        }
    }

    public class LookupEnum : QueryCommandBase, IQuery
    {
        public string EnumTypeId { get; set; }
        public QueryResult Execute()
        {
            return new CommonDataQueryAppService().LookupEnumByType(EnumTypeId, QueryParamArg);
        }
    }

    public class ListEnumQuery:QueryCommandBase,IQuery
    {
        public string EnumTypeId { get; set; }
        public List<string> EnumTypeIds { get; set; }

        public ListEnumQuery()
        {
            EnumTypeIds = new List<string>();
        }

        public QueryResult Execute()
        {
            return new CommonDataQueryAppService().ListEnum(EnumTypeId,EnumTypeIds, QueryParamArg);
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

    public class ListStatusItemQuery:QueryCommandBase,IQuery
    {
        public string StatusTypeId { get; set; }
        public QueryResult Execute()
        {
            QueryParamArg.SetDefaultSortColumn("SequenceId");
            return new CommonDataQueryAppService().ListStatusItem(StatusTypeId,QueryParamArg);
        }
    }
}
