using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.QueryModel;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using System;
using System.Linq;
using ModelManagement.Core.Business.Business.Query.Models;

namespace ModelManagement.Core.Business.Business.Query.AppService
{
    public class UserQueryAppService : QueryAppService
    {
        public UserQueryAppService()
        {

        }

        public PersonalInfoEditModel EditPersonalInfo(string personId)
        {
            var personalInfo = ModelManagementContext().PersonalInformations.Where(t => t.PersonId == personId).Get<PersonalInfoEditModel>();
            if (string.IsNullOrEmpty(personalInfo.CityGeoId)) return personalInfo;
            {
                var geoAssoc = ModelManagementContext().GeoAssoces.FirstOrDefault(t => t.GeoIdTo == personalInfo.CityGeoId && (t.GeoAssocTypeId == Utility.GeoTypes.City || t.GeoAssocTypeId == Utility.GeoTypes.Regions));
                personalInfo.CountryGeoId = geoAssoc?.GeoId;
            }
            return personalInfo;
        }


        public QueryResult ListModelslInfo(ListModelsQueryParam queryParam)
        {
            var personalInfo = ListPersonalInfos(queryParam).ToList().AsQueryable();
            return Utility.QuerySuccessResult(personalInfo.Paginate(t => t.FirstName, queryParam.Pagination).ToList<ModelsInfoListModel>(), personalInfo.Count());
        }

        public QueryResult GetListPersonalInfo(ListModelsQueryParam queryParam)
        {
            var searchText = queryParam.SearchText?.Trim();
            var personalInfos = ModelManagementContext().PersonalInformations
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
            return
                Utility.QuerySuccessResult(
                    personalInfos.Paginate(t => t.FirstName, queryParam.Pagination)
                        .ToList()
                        .AsQueryable()
                        .ToList<PersonalInfoListModel>(), personalInfos.Count());
        }

        private IQueryable<PersonalInformation> ListPersonalInfos(ListModelsQueryParam queryParam)
        {
            var birthDateFromAge = DateTime.Now.AddYears(-queryParam.AgeFrom.Value);
            var birthDateThruAge = DateTime.Now.AddYears(-(queryParam.ThruAge.Value + 1));
            return ModelManagementContext().PersonalInformations
                                        .Where(t =>
                                                (string.IsNullOrEmpty(queryParam.Status) || t.PersonId_User.StatusId == queryParam.Status) &&
                                                (string.IsNullOrEmpty(queryParam.Sex) || t.Sex == queryParam.Sex) &&
                                                (string.IsNullOrEmpty(queryParam.Complextion) || t.PhysicalInformation_PersonId.Complexion == queryParam.Complextion) &&
                                                (string.IsNullOrEmpty(queryParam.CategoryTypeId) || t.Categories_PersonId.Any(c => c.CategoryTypeId == queryParam.CategoryTypeId)) &&
                                                (string.IsNullOrEmpty(queryParam.HeightEnumId) || t.PhysicalInformation_PersonId.HeightEnumId == queryParam.HeightEnumId) &&
                                                (queryParam.HeightFrom == null || t.PhysicalInformation_PersonId.Height >= queryParam.HeightFrom) &&
                                                (queryParam.HeightThru == null || t.PhysicalInformation_PersonId.Height <= queryParam.HeightThru) &&
                                                (string.IsNullOrEmpty(queryParam.WeightEnumId) || t.PhysicalInformation_PersonId.WeightEnumId == queryParam.WeightEnumId) &&
                                                (queryParam.WeightFrom == null || t.PhysicalInformation_PersonId.Weight >= queryParam.WeightFrom) &&
                                                (queryParam.WeightThru == null || t.PhysicalInformation_PersonId.Weight <= queryParam.WeightThru) &&

                                                (queryParam.IsActive == null || (queryParam.IsActive.Value ?
                                                t.PersonId_User.UserApplId_UserAppls.Any(p => p.FromDate <= DateTime.Now && p.ThruDate >= DateTime.Now)
                                                : false)) &&
                                                (queryParam.AgeFrom == 0 ||
                                                    (t.DateOfBirth.Value.Year <= birthDateFromAge.Year &&
                                                        (birthDateFromAge.Year - t.DateOfBirth.Value.Year > 0 ? true :
                                                            t.DateOfBirth.Value.Month <= birthDateFromAge.Month)
                                                        )
                                                ) &&
                                                (queryParam.ThruAge == 0 ||
                                                    (t.DateOfBirth.Value.Year >= birthDateThruAge.Year &&
                                                        (t.DateOfBirth.Value.Year - birthDateThruAge.Year > 0 ? true :
                                                            t.DateOfBirth.Value.Month > birthDateThruAge.Month)
                                                        )
                                                )


                                        ); ;
        }

        internal QueryResult CheckUserName(string userName, string primaryEmail)
        {
            var userFound = ModelManagementContext().UserLogins.FirstOrDefault(t => t.UserName == userName.Trim()) != null;
            var emailFound =
                ModelManagementContext().Users.FirstOrDefault(t => t.PrimaryEmail == primaryEmail.Trim()) != null;
            if (!emailFound && !userFound) return Utility.QuerySuccessResult(true);
            var result = "";
            result += userFound ? " The user name already exists! \n" : "";
            result += emailFound ? " The email already exists! " : "";
            return Utility.QuerySuccessResult(result);
        }

        public QueryResult ListPersonUplodables(string personId, string fileTypeId, string fileUploadId)
        {
            var result = ModelManagementContext().Uploadables.Where(t =>
                    (string.IsNullOrEmpty(fileUploadId) || t.FileUploadId == fileUploadId) &&
                    (string.IsNullOrEmpty(personId) || t.PersonId == personId) &&
                    (string.IsNullOrEmpty(fileTypeId) || t.FileTypeId == fileTypeId)
                    ).ToList<UplodableListModel>();
            return Utility.QuerySuccessResult(result);
        }

        public QueryResult EditPhysicalInfo(string personId)
        {
            return
                ModelManagementContext()
                    .PhysicalInformations.Where(t => t.PersonId == personId)
                    .QueryResultGet<PhysicalInformationEditModel>();
        }

        public QueryResult ListPersonContactInfo(string personId, QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .ContactInformations.Where(t => t.PersonId == personId)
                    .QueryResultList<ContactInformationListModel>(queryParamArg);
        }

        public QueryResult ListJobPost(string userId, QueryParamArg queryParamArg)
        {
            return ModelManagementContext().JobPosts.Where(t => t.UserId == userId && t.IsActive == "Y").QueryResultList<JobPostListModel>(queryParamArg);
        }

        public QueryResult ListJobOffer(string jobPostId, QueryParamArg queryParamArg)
        {
            return ModelManagementContext().JobOffers.Where(t => t.JobPostId == jobPostId).QueryResultList<JobOfferListModel>(queryParamArg);
        }
    }
}
