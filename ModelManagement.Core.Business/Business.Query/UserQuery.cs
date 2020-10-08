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

    public class CheckUserPhoneQuery:QueryCommandBase,IQuery
    {
        public string PrimaryPhoneNumber { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().CheckUserPhone(PrimaryPhoneNumber);
        }
    }

    public class CheckUserPhoneExistsQuery : QueryCommandBase, IQuery
    {
        public string PrimaryPhoneNumber { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().CheckUserPhoneExists(PrimaryPhoneNumber);
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



    public class ListJobOfferQuery : QueryCommandBase, IQuery
    {
        public string JobPostId { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().ListJobOffer(JobPostId, QueryParamArg);
        }
    }

    public class ListModelsQuery : QueryCommandBase, IQuery
    {
        public ListModelsQueryParamArg ListModelsQueryParamArg { get; set; }

        public ListModelsQuery()
        {
            ListModelsQueryParamArg = new ListModelsQueryParamArg();
        }
        public QueryResult Execute()
        {
            return new UserQueryAppService().ListModels(ListModelsQueryParamArg, QueryParamArg);
        }
    }

    public class CheckUserVerificationCodeQuery:QueryCommandBase,IQuery
    {
        public string PhoneNumber { get; set; }
        public string VerificationCode { get; set; }
        public QueryResult Execute()
        {
            return new UserQueryAppService().CheckUserVerificationCode(PhoneNumber,VerificationCode);
        }
    }


}
