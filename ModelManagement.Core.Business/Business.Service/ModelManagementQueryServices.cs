using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
using ModelManagement.Core.Data.Data.Context;
using System;
using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Query.Models;

namespace ModelManagement.Core.Business.Business.Service
{
    public class ModelManagementQueryServices
    {
        private ModelManagementContext _context;
        private ModelManagementQuery _query;
        public ModelManagementQueryServices()
        {
            _context = new ModelManagementContext();
            _query = new ModelManagementQuery(this._context);

        }

        static ModelManagementQueryServices()
        {
            BootStrapper.Start();
        }

        public QueryResult InvokeQuery(IQuery query)
        {
            try
            {
                return query.Execute();
            }
            catch (Exception e)
            {
                return Utility.QueryErrorResult(e.Message);
            }
        }

        #region UserQueries
        public List<PersonalInformationQueryModel> ListPersonalInformation(QueryCommandBase queryParam)
        {
            return _query.ListPersonalInformation(queryParam);
        }

        public GetListSearchPersonalInfos ListSearchPersonalInfos(ListPersonalInfoQueryParam queryParam)
        {
            return _query.ListSearchPersonalInfos(queryParam);
        }

        public PersonalInfoEditModel EditPersonalInformation(string personId)
        {
            return _query.EditPersonalInformation(personId);
        }

        public GetModelsInfoListModel GetListModelsInfo(ListModelsQueryParam queryParam)
        {
            return _query.GetListModelsInfo(queryParam);
        }

        public List<UserQueryModel> ListUser(QueryCommandBase queryParam)
        {
            return _query.ListUser(queryParam);
        }

        public UserQueryModel EditUser(string personId)
        {
            return _query.EditUser(personId);
        }

        public PhysicalInformationEditModel EditPhysicalInformation(string personId)
        {
            return _query.EditPhysicalInformation(personId);
        }

        public GetPersonalInfoListModel GetListPersonalInfo(ListPersonalInfoQueryParam queryParam)
        {
            return _query.GetListPersonalInfo(queryParam);
        }

        #endregion


        #region CommonQueries
        public List<KeyDescription> LookupAllEnumeration()
        {
            return _query.LookupAllEnumeration();
        }




        public List<KeyDescription> LookupAllFileTypes()
        {
            return _query.LookupAllFileTypes();
        }
        public List<KeyDescription> LookupFileTypesByParent(string parentTypeId)
        {
            return _query.LookupFileTypesByParent(parentTypeId);
        }

        public List<KeyDescription> LookupRoleTypes()
        {
            return _query.LookupRoleTypes();
        }

        public List<KeyDescription> LookupStatusTypes()
        {
            return _query.LookupStatusTypes();
        }


       


        #endregion

        #region CategoryQuery
        public List<CategoryQueryModel> ListCategory(string personId)
        {
            return _query.ListCategory(personId);
        }

        public CategoryQueryModel EditCategory(string categoryId)
        {
            return _query.EditCategory(categoryId);
        }
        #endregion

        #region ContactQuery
        public List<ContactInformationListModel> ListContactInformation(string personId)
        {
            return _query.ListContactInformation(personId);
        }

        public ContactInformationListModel EditContactInformation(string contactInfoId)
        {
            return _query.EditContactInformation(contactInfoId);
        }
        #endregion
    }
}
