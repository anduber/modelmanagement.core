using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.AppService;
using ModelManagement.Core.Business.Business.Query.Models;

namespace ModelManagement.Core.Business.Business.Query
{
    public class ListUserJobPostQuery : QueryCommandBase, IQuery
    {
        public string UserId { get; set; }
        public string StatusId { get; set; }

        public QueryResult Execute()
        {
            return new UserJobQueryService().ListJobPost(UserId, StatusId, QueryParamArg);
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

    public class ListJobApplicationQuery : QueryCommandBase, IQuery
    {
        public string JobPostId { get; set; }
        public string ApplyingUserId { get; set; }
        public string StatusId { get; set; }

        public QueryResult Execute()
        {
            return new UserJobQueryService().ListJobApplication(JobPostId, ApplyingUserId, StatusId, QueryParamArg);
        }
    }

    public class EditJobPostQuery : QueryCommandBase, IQuery
    {
        public string JobPostId { get; set; }

        public QueryResult Execute()
        {
            return new UserJobQueryService().EditJobPost(JobPostId);
        }
    }
}
