using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Data.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Query.Models;

namespace ModelManagement.Core.Business.Business.Query
{
    public class ModelManagementQuery
    {
        private ModelManagementContext _context;
        public ModelManagementQuery(ModelManagementContext context)
        {
            this._context = context;
        }

        #region UserQuery
        public List<PersonalInformationQueryModel> ListPersonalInformation(QueryCommandBase queryParam)
        {
            var personalInfos = _context.PersonalInformations.Where(t =>
                (t.PersonId_User.StatusId != null)
                );
            if (string.IsNullOrEmpty(queryParam.SearchText))
                return personalInfos.Paginate(t => t.PersonId, queryParam.Pagination)
                    .ToList().AsQueryable()
                    .ToList<PersonalInformationQueryModel>();
            {
                string searchTextLower = queryParam.SearchText.ToLower();
                return personalInfos.Where(t =>
                    t.PersonId_User.UserNumber.ToLower().Contains(searchTextLower)
                    )
                    .Paginate(t => t.PersonId, queryParam.Pagination)
                    .ToList<PersonalInformationQueryModel>();
            }
        }

        public GetListSearchPersonalInfos ListSearchPersonalInfos(ListPersonalInfoQueryParam queryParam)
        {
            var birthDateFromAge = DateTime.Now.AddYears(-queryParam.AgeFrom);
            var birthDateThruAge = DateTime.Now.AddYears(-(queryParam.ThruAge + 1));

            var personalInfos = _context.PersonalInformations.Where(t => t.PersonId_User.StatusId != null &&
                                                                         (queryParam.AgeFrom == 0 ||
                                                                          (t.DateOfBirth.Value.Year <=
                                                                           birthDateFromAge.Year &&
                                                                           (
                                                                               birthDateFromAge.Year -
                                                                               t.DateOfBirth.Value.Year > 0 ||
                                                                               t.DateOfBirth.Value.Month <=
                                                                               birthDateFromAge.Month
                                                                               )
                                                                              )
                                                                             )
                                                                         &&
                                                                         (queryParam.ThruAge == 0 ||
                                                                          (t.DateOfBirth.Value.Year >=
                                                                           birthDateThruAge.Year &&
                                                                           (
                                                                               t.DateOfBirth.Value.Year -
                                                                               birthDateThruAge.Year > 0 ||
                                                                               t.DateOfBirth.Value.Month >
                                                                               birthDateThruAge.Month
                                                                               )
                                                                              )
                                                                             )
                                                                         &&
                                                                         (string.IsNullOrEmpty(queryParam.Sex) ||
                                                                          t.Sex == queryParam.Sex) &&
                                                                         (string.IsNullOrEmpty(queryParam.FirstName) ||
                                                                          t.FirstName.ToLower()
                                                                              .Contains(queryParam.FirstName.ToLower())) &&
                                                                         (string.IsNullOrEmpty(queryParam.Complexion) ||
                                                                          t.PhysicalInformation_PersonId.Complexion ==
                                                                          queryParam.Complexion) &&
                                                                         (string.IsNullOrEmpty(queryParam.UserNumber) ||
                                                                          t.PersonId_User.UserNumber.ToLower()
                                                                              .Contains(queryParam.UserNumber.ToLower())) &&
                                                                         (queryParam.CategoryTypeIds.Count == 0 ||
                                                                          t.Categories_PersonId
                                                                              .Any(l =>
                                                                                  queryParam.CategoryTypeIds.Contains(
                                                                                      l.CategoryTypeId))) &&
                                                                         (queryParam.HeightFrom == null || (
                                                                             t.PhysicalInformation_PersonId.Height >=
                                                                             queryParam.HeightFrom &&
                                                                             t.PhysicalInformation_PersonId.HeightEnumId ==
                                                                             queryParam.HeightUom
                                                                             )
                                                                             ) &&
                                                                         (queryParam.HeightThru == null || (
                                                                             t.PhysicalInformation_PersonId.Height <=
                                                                             queryParam.HeightThru &&
                                                                             t.PhysicalInformation_PersonId.HeightEnumId ==
                                                                             queryParam.HeightUom)
                                                                             ));
            return new GetListSearchPersonalInfos()
            {
                PersonalInfos = personalInfos.Paginate(t => t.PersonId_User.UserNumber, queryParam.Pagination.Page, queryParam.Pagination.PageSize).OrderBy(t => t.FirstName).ToList().AsQueryable().ToList<PersonalInformationQueryModel>(),
                TotalCount = personalInfos.Count()
            };
        }

        public PersonalInfoEditModel EditPersonalInformation(string personId)
        {
            var personalInfo = _context.PersonalInformations.Where(t => t.PersonId == personId).Get<PersonalInfoEditModel>();
            //if (!string.IsNullOrEmpty(personalInfo.ProfilePic))
            //{
            //    personalInfo.Path = new UtilityMethods().ConvertImageToByteArray(personalInfo.ProfilePic);

            //}
            return personalInfo;
        }

        public GetModelsInfoListModel GetListModelsInfo(ListModelsQueryParam queryParam)
        {
            var birthDateFromAge = DateTime.Now.AddYears(-queryParam.AgeFrom.Value);
            var birthDateThruAge = DateTime.Now.AddYears(-(queryParam.ThruAge.Value + 1));

            var modelsInfo = _context.PersonalInformations
                                        .Where(t =>
                                               
                                                (string.IsNullOrEmpty(queryParam.Sex) || t.Sex == queryParam.Sex) &&
                                                (string.IsNullOrEmpty(queryParam.Complextion) || t.PhysicalInformation_PersonId.Complexion == queryParam.Complextion) &&
                                                (string.IsNullOrEmpty(queryParam.CategoryTypeId) || t.Categories_PersonId.Any(c => c.CategoryTypeId == queryParam.CategoryTypeId)) &&
                                                (string.IsNullOrEmpty(queryParam.HeightEnumId) || t.PhysicalInformation_PersonId.HeightEnumId == queryParam.HeightEnumId) &&
                                                (queryParam.HeightFrom == null || t.PhysicalInformation_PersonId.Height >= queryParam.HeightFrom) &&
                                                (queryParam.HeightThru == null || t.PhysicalInformation_PersonId.Height <= queryParam.HeightThru) &&
                                                (string.IsNullOrEmpty(queryParam.WeightEnumId) || t.PhysicalInformation_PersonId.WeightEnumId == queryParam.WeightEnumId) &&
                                                (queryParam.WeightFrom == null || t.PhysicalInformation_PersonId.Weight >= queryParam.WeightFrom) &&
                                                (queryParam.WeightThru == null || t.PhysicalInformation_PersonId.Weight <= queryParam.WeightThru) &&
                                                (queryParam.AgeFrom == 0 ||
                                                    (t.DateOfBirth.Value.Year <= birthDateFromAge.Year &&
                                                        (birthDateFromAge.Year - t.DateOfBirth.Value.Year > 0 || t.DateOfBirth.Value.Month <= birthDateFromAge.Month)
                                                        )
                                                ) &&
                                                (queryParam.ThruAge == 0 ||
                                                    (t.DateOfBirth.Value.Year >= birthDateThruAge.Year &&
                                                        (t.DateOfBirth.Value.Year - birthDateThruAge.Year > 0 || t.DateOfBirth.Value.Month > birthDateThruAge.Month)
                                                        )
                                                )


                                        );

            return new GetModelsInfoListModel
            {
                ModelList = modelsInfo.Paginate(t => t.FirstName, queryParam.Pagination).ToList().AsQueryable().ToList<ModelsInfoListModel>(),
                TotalCount = modelsInfo.Count()
            };
        }


        public List<UserQueryModel> ListUser(QueryCommandBase queryParam)
        {
            var users = _context.Users;
            if (string.IsNullOrEmpty(queryParam.SearchText))
            {
                return users.Paginate(t => t.PersonId, queryParam.Pagination)
                            .ToList<UserQueryModel>();
            }

            else
            {
                string searchTextToLower = queryParam.SearchText.ToLower();
                return users.Where(t => 
                                        t.UserNumber.ToLower().Contains(searchTextToLower)
                                        )
                                        .Paginate(t => t.PersonId, queryParam.Pagination)
                                        .ToList<UserQueryModel>();
            }


        }

        public UserQueryModel EditUser(string personId)
        {
            return _context.Users.Where(t => t.PersonId == personId).Get<UserQueryModel>();
        }

        public PhysicalInformationEditModel EditPhysicalInformation(string personId)
        {
            return _context.PhysicalInformations.Where(t => t.PersonId == personId).Get<PhysicalInformationEditModel>();
        }

        public GetPersonalInfoListModel GetListPersonalInfo(ListPersonalInfoQueryParam queryParam)
        {
            var searchText = queryParam.SearchText?.Trim();
            var personalInfos = _context.PersonalInformations
                                        .Where(t =>
                                                (string.IsNullOrEmpty(searchText) ||
                                                    (
                                                        t.FirstName.Contains(searchText) ||
                                                        t.LastName.Contains(searchText) ||
                                                        t.FatherName.Contains(searchText) ||
                                                        t.PersonId_User.UserNumber.Contains(searchText)
                                                    )) &&
                                                    (string.IsNullOrEmpty(queryParam.Sex) || t.Sex == queryParam.Sex)

                                        );
            return new GetPersonalInfoListModel
            {
                PersonalInfoList = personalInfos.Paginate(t => t.FirstName, queryParam.Pagination).ToList().AsQueryable().ToList<PersonalInfoListModel>(),
                TotalCount = personalInfos.Count()
            };
        }
        #endregion

        #region CommonQuery
        public List<KeyDescription> LookupAllEnumeration()
        {
            var enumerations = _context.Enumerations.OrderBy(t => t.Description);
            return enumerations.ToLookUp();
        }



        public List<KeyDescription> LookupAllFileTypes()
        {
            var fileTypes = _context.FileTypes.OrderBy(t => t.Description);
            return fileTypes.ToLookUp();
        }

        public List<KeyDescription> LookupFileTypesByParent(string parentTypeId)
        {
            var fileTypes = _context.FileTypes.Where(t => t.ParentFileTypeId == parentTypeId);
            return fileTypes.ToLookUp();
        }

        public List<KeyDescription> LookupRoleTypes()
        {
            var roleTypes = _context.RoleTypes.OrderBy(t => t.Description);
            return roleTypes.ToLookUp();
        }

        public List<KeyDescription> LookupStatusTypes()
        {
            //return _context.StatusTypes.ToLookUp();
            return new List<KeyDescription>();
        }

        #endregion

        #region CategoryQuery
        public List<CategoryQueryModel> ListCategory(string personId)
        {
            return _context.Categories.Where(t => t.PersonId == personId).ToList<CategoryQueryModel>();
        }

        public CategoryQueryModel EditCategory(string categoryId)
        {
            return _context.Categories.Where(t => t.CategoryTypeId == categoryId).Get<CategoryQueryModel>();
        }
        #endregion

        #region ContactQuery
        public List<ContactInformationListModel> ListContactInformation(string personId)
        {
            return _context.ContactInformations.Where(t => t.PersonId == personId).ToList<ContactInformationListModel>();
        }

        public ContactInformationListModel EditContactInformation(string contactInfoId)
        {
            return null;
            //return _context.ContactInformations.Where(t => t.ContactInfoId == contactInfoId).Get<ContactInformationQueryModel>();
        }
        #endregion

       
    }
    
}
