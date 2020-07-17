using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.AppService;
using ModelManagement.Core.Business.Business.Query.Models;

namespace ModelManagement.Core.Business.Business.Query
{
    public class ListUserJobPostQuery : QueryCommandBase, IQuery
    {
        public string UserId { get; set; }

        public QueryResult Execute()
        {
            return new UserJobQueryService().ListJobPost(UserId, QueryParamArg);
        }
    }

    public class ListOpenJobPostQuery : QueryCommandBase, IQuery
    {
        public JobPostQueryParamArg JobPostQueryParamArg { get; set; }

        public ListOpenJobPostQuery()
        {
            JobPostQueryParamArg = new JobPostQueryParamArg();
        }
        public QueryResult Execute()
        {
            return new UserJobQueryService().ListOpenJobPost(JobPostQueryParamArg, QueryParamArg);
        }
    }

    public class ListUserJobApplicationsCommand : QueryCommandBase, IQuery
    {
        public string UserId { get; set; }
        public QueryResult Execute()
        {
            return new UserJobQueryService().ListUserJobApplications(UserId, QueryParamArg);
        }
    }
}
