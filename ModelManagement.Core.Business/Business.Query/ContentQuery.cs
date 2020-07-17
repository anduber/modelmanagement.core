using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.AppService;
using System;
using System.Collections.Generic;

namespace ModelManagement.Core.Business.Business.Query
{
    public class ListUserContentQuery : QueryCommandBase, IQuery
    {
        public string UserId { get; set; }
        public QueryResult Execute()
        {
            return new ContentQueryAppService().ListUserContent(UserId, QueryParamArg);
        }
    }

    public class EditUserContentQuery : QueryCommandBase, IQuery
    {
        public string ContentUserId { get; set; }
        public string ContentTypeId { get; set; }
        public QueryResult Execute()
        {
            return new ContentQueryAppService().EditUserContent(ContentUserId, ContentTypeId);
        }
    }

    public class ListUsersContentQuery : QueryCommandBase, IQuery
    {
        public string ContentTypeId { get; set; }
        public List<string> UserIds { get; set; }

        public ListUsersContentQuery()
        {
            UserIds = new List<string>();
        }
        public QueryResult Execute()
        {
            return new ContentQueryAppService().ListUsersContent(ContentTypeId, UserIds);
        }
    }
}
