using ModelManagement.Core.Business.Business.Model.Utils;
using System;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Business.Business.Query.AppService;
using ModelManagement.Core.Business.Business.Helpers;

namespace ModelManagement.Core.Business.Business.Query
{
    public class UserQuery
    {

    }

    public class EditPersonalInfoQuery : QueryCommandBase, IQuery
    {
        public string PersonId { get; set; }
        public QueryResult Execute()
        {
            return Utility.QuerySuccessResult(new UserQueryAppService().EditPersonalInfo(PersonId));
        }
    }

    public class ListModelslInfoQuery : QueryCommandBase, IQuery
    {
        public ListModelsQueryParam ModelsQueryParam { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().ListModelslInfo(ModelsQueryParam);
        }
    }

    public class ListPersonalInfoQuery:QueryCommandBase,IQuery
    {
        public ListModelsQueryParam ModelsQueryParam { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().GetListPersonalInfo(ModelsQueryParam);
        }
    }

    public class CheckUserNameQuery:QueryCommandBase,IQuery
    {
        public string UserName { get; set; }
        public string PrimaryEmail { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().CheckUserName(UserName,PrimaryEmail);
        }
    }

    public class ListPersonUplodablesQuery : QueryCommandBase, IQuery
    {
        public string PersonId { get; set; }
        public string FileTypeId { get; set; }
        public string FileUploadId { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().ListPersonUplodables(PersonId, FileTypeId, FileUploadId);
        }
    }

    public class EditPhysicalInfoQuery : QueryCommandBase,IQuery
    {
        public string PersonId { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().EditPhysicalInfo(PersonId);
        }
    }

    public class ListPersonContactInfoQuery:QueryCommandBase,IQuery
    {
        public string PersonId { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().ListPersonContactInfo(PersonId, QueryParamArg);
        }
    }

    public class ListJobPostQuery : QueryCommandBase, IQuery
    {
        public string UserId { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().ListJobPost(UserId, QueryParamArg);
        }
    }

    public class ListJobOfferQuery : QueryCommandBase, IQuery
    {
        public string JobPostId { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().ListJobOffer(JobPostId, QueryParamArg);
        }
    }


}
