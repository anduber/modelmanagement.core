using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.Models;
using System.Linq;

namespace ModelManagement.Core.Business.Business.Query.AppService
{
    public class UserJobQueryService : QueryAppService
    {
        public UserJobQueryService()
        {

        }

        public QueryResult ListJobPost(string userId, QueryParamArg queryParamArg)
        {
            return ModelManagementContext()
                    .JobPosts.Where(t =>
                            t.UserId == userId &&
                            (string.IsNullOrEmpty(queryParamArg.SearchText) ||
                                t.JobTitle.Contains(queryParamArg.SearchText) ||
                                t.JobDescription.Contains(queryParamArg.SearchText))
                             ).QueryResultList<JobPostListModel>(queryParamArg);
        }

        public QueryResult ListOpenJobPost(JobPostQueryParamArg jobPostQueryParamArg, QueryParamArg queryParamArg)
        {
            return ModelManagementContext().JobPosts
                                    .Where(t =>
                                            t.IsActive == "Y" &&
                                                (string.IsNullOrEmpty(queryParamArg.SearchText) ||
                                                  t.JobTitle.Contains(queryParamArg.SearchText) ||
                                                  t.JobDescription.Contains(queryParamArg.SearchText))
                                              ).QueryResultList<JobPostListModel>(queryParamArg);
        }

        public QueryResult ListUserJobApplications(string userId,QueryParamArg queryParamArg)
        {
            return ModelManagementContext().JobApplications
                                    .Where(t => t.ApplyingUserId == userId)
                                    .QueryResultList<JobApplicationListModel>(queryParamArg);
        }
    }
}
