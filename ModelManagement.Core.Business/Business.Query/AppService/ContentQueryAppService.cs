using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
using ModelManagement.Core.Business.Business.Query.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModelManagement.Core.Business.Business.Query.AppService
{
    public class ContentQueryAppService : QueryAppService
    {
        public ContentQueryAppService()
        {

        }

        public QueryResult ListUserContent(string userId, QueryParamArg queryParamArg)
        {
            //var queryContext = ModelManagementContext();
            //var userContents = queryContext.Contents.Where(t => t.ContentUserId == userId).OrderBy(o => o.LastUpdatedStamp).ToList<ContentListModel>();
            //var contentIds = userContents.Select(s => s.ContentId);
            //var contentData = queryContext.ContentDatas.Where(t => contentIds.Contains(t.ContentId)).ToList();
            //foreach (var content in userContents)
            //{
            //    content.Data = contentData.FirstOrDefault(t => t.ContentId == content.ContentId)?.Data;
            //}
            return
                ModelManagementContext()
                    .Contents.Where(t => t.ContentUserId == userId)
                    .OrderBy(o => o.LastUpdatedStamp)
                    .QueryResultList<ContentListModel>();
            //return Utility.QuerySuccessResult(userContents);
        }

        public QueryResult EditUserContent(string contentUserId, string contentTypeId)
        {
            var queryContext = ModelManagementContext();
            var result = queryContext.Contents.Where(t => t.ContentUserId == contentUserId && t.ContentTypeId == contentTypeId).Get<ContentListModel>();
            if (result != null)
                result.Data = queryContext.ContentDatas.FirstOrDefault(t => t.ContentId == result.ContentId)?.Data;
            return Utility.QuerySuccessResult(result);
        }

        public QueryResult ListUsersContent(string contentTypeId, List<string> userIds)
        {
            var queryContext = ModelManagementContext();
            var userContents = queryContext.Contents
                            .Where(t => 
                                        t.ContentTypeId == contentTypeId && userIds.Contains(t.ContentUserId))
                                            .ToList<ContentListModel>();
            var contentIds = userContents.Select(s => s.ContentId);
            var contentDatas = queryContext.ContentDatas.Where(t => contentIds.Contains(t.ContentId));
            foreach (var content in userContents)
            {
                content.Data = contentDatas.FirstOrDefault(t => t.ContentId == content.ContentId)?.Data;
            }
            return Utility.QuerySuccessResult(userContents);
        }

    }
}
