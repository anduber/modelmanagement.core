using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;
using ModelManagement.Core.Business.Business.Model.QueryModel;
using ModelManagement.Core.Business.Business.Query;
using ModelManagement.Core.Business.Business.Query.Models;


namespace ModelManagement.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class QueryGeneratorController : ApiController
    {
        private ModelManagementQueryServices modelManagementQueryServices;
        public QueryGeneratorController()
        {
            modelManagementQueryServices = new ModelManagementQueryServices();
        }

        #region UserQueries
        [HttpPost, Route("USRQRY_ListPersonalInformation")]
        public List<PersonalInformationQueryModel> ListPersonalInformation(QueryCommandBase queryParam)
        {
            return modelManagementQueryServices.ListPersonalInformation(queryParam);
        }
        [HttpPost, Route("USRQRY_ListSearchPersonalInfos")]
        public GetListSearchPersonalInfos ListSearchPersonalInfos(ListPersonalInfoQueryParam queryParam)
        {
            return modelManagementQueryServices.ListSearchPersonalInfos(queryParam);
        }
        [HttpGet, Route("USRQRY_EditPersonalInformation/{personId}")]
        public PersonalInfoEditModel EditPersonalInformation(string personId)
        {
            return modelManagementQueryServices.EditPersonalInformation(personId);
        }
        [HttpPost, Route("USRQRY_GetListModelsInfo")]
        public GetModelsInfoListModel GetListModelsInfo(ListModelsQueryParam queryParam)
        {
            return modelManagementQueryServices.GetListModelsInfo(queryParam);
        }
        [HttpPost, Route("USRQRY_ListUser")]
        public List<UserQueryModel> ListUser(QueryCommandBase queryParam)
        {
            return modelManagementQueryServices.ListUser(queryParam);
        }
        [HttpGet, Route("USRQRY_EditUser/{personId}")]
        public UserQueryModel EditUser(string personId)
        {
            return modelManagementQueryServices.EditUser(personId);
        }
        [HttpGet, Route("USRQRY_EditPhysicalInformation/{personId}")]
        public PhysicalInformationEditModel EditPhysicalInformation(string personId)
        {
            return modelManagementQueryServices.EditPhysicalInformation(personId);
        }
        [HttpPost, Route("USRQRY_GetPersonalInfoList")]
        public GetPersonalInfoListModel GetListPersonalInfo(ListPersonalInfoQueryParam queryParam)
        {
            return modelManagementQueryServices.GetListPersonalInfo(queryParam);
        }

        [HttpPost, Route("EditPersonalInfoQuery")]
        public QueryResult EditPersonalInfoQuery(EditPersonalInfoQuery query)
        {
            return InvokeQuery(query);
        }

        [HttpPost, Route("ListPersonalInfoQuery")]
        public QueryResult ListPersonalInfoQuery(ListModelslInfoQuery query)
        {
            return InvokeQuery(query);
        }
        [HttpPost, Route("CheckUserNameQuery")]
        public QueryResult CheckUserNameQuery(CheckUserNameQuery query)
        {
            return InvokeQuery(query);
        }

        [HttpPost, Route("ListPersonUplodablesQuery")]
        public QueryResult ListPersonUplodablesQuery(ListPersonUplodablesQuery query)
        {
            return InvokeQuery(query);
        }

        #endregion

        #region CommonQueries
        //[HttpGet, Route("COMMQRY_LookupAllEnumeration")]
        //public List<KeyDescription> LookupAllEnumeration()
        //{
        //    return modelManagementQueryServices.LookupAllEnumeration();
        //}

       
        //[HttpGet, Route("COMMQRY_LookupAllFileTypes")]
        //public List<KeyDescription> LookupAllFileTypes()
        //{
        //    return modelManagementQueryServices.LookupAllFileTypes();
        //}
        //[HttpGet, Route("COMMQRY_LookupFileTypesByParent/{parentTypeId}")]
        //public List<KeyDescription> LookupFileTypesByParent(string parentTypeId)
        //{
        //    return modelManagementQueryServices.LookupFileTypesByParent(parentTypeId);
        //}
        //[HttpGet, Route("COMMQRY_LookupRoleTypes")]
        //public List<KeyDescription> LookupRoleTypes()
        //{
        //    return modelManagementQueryServices.LookupRoleTypes();
        //}

        //[HttpGet, Route("COMMQRY_LookupStatusTypes")]
        //public List<KeyDescription> LookupStatusTypes()
        //{
        //    return modelManagementQueryServices.LookupStatusTypes();
        //}
        
        //[HttpPost, Route("ListGeos")]
        //public QueryResult ListGeos(ListGeos listGeos)
        //{
        //    return InvokeQuery(listGeos);
        //}

        //[HttpPost, Route("LookupCategoryType")]
        //public QueryResult LookupCategoryType(LookupCategoryType query)
        //{
        //    return InvokeQuery(query);
        //}

        //[HttpPost, Route("LookupEnum")]
        //public QueryResult LookupEnum(LookupEnum query)
        //{
        //    return InvokeQuery(query);
        //}

        #endregion

        //#region CategoryQuery
        //[HttpGet, Route("CATGQRY_ListCategory/{personId}")]
        //public List<CategoryQueryModel> ListCategory(string personId)
        //{
        //    return modelManagementQueryServices.ListCategory(personId);
        //}
        //[HttpGet, Route("CATGQRY_EditCategory/{categoryId}")]
        //public CategoryQueryModel EditCategory(string categoryId)
        //{
        //    return modelManagementQueryServices.EditCategory(categoryId);
        //}
        //#endregion

        //#region ContactQuery
        //[HttpGet, Route("CONTACTQRY_ListContactInformation/{personId}")]
        //public List<ContactInformationListModel> ListContactInformation(string personId)
        //{
        //    return modelManagementQueryServices.ListContactInformation(personId);
        //}
        //[HttpGet, Route("CONTACTQRY_EditContactInformation/{contactInfoId}")]
        //public ContactInformationListModel EditContactInformation(string contactInfoId)
        //{
        //    return modelManagementQueryServices.EditContactInformation(contactInfoId);
        //}
        //#endregion


        private QueryResult InvokeQuery(IQuery query)
        {
            return modelManagementQueryServices.InvokeQuery(query);
        }
    }
}
