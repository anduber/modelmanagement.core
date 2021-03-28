using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
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
            personalInfo.Age = personalInfo.DateOfBirth == null
                ? 0
                : DateConverter.CalculateAge(personalInfo.DateOfBirth.Value);
            //if (string.IsNullOrEmpty(personalInfo.CityGeoId)) return personalInfo;
            //{
            //    var geoAssoc =
            //        ModelManagementContext()
            //            .GeoAssoces.FirstOrDefault(
            //                t =>
            //                    t.GeoIdTo == personalInfo.CityGeoId &&
            //                    (t.GeoAssocTypeId == Utility.GeoTypes.City ||
            //                     t.GeoAssocTypeId == Utility.GeoTypes.Regions));
            //    personalInfo.CountryGeoId = geoAssoc?.GeoId;
            //}

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
                    (string.IsNullOrEmpty(queryParam.Complextion) ||
                     t.PersonId_PhysicalInformation.Complexion == queryParam.Complextion) &&
                    (string.IsNullOrEmpty(queryParam.CategoryTypeId) ||
                     t.Categories_PersonId.Any(c => c.CategoryTypeId == queryParam.CategoryTypeId)) &&
                    (string.IsNullOrEmpty(queryParam.HeightEnumId) ||
                     t.PersonId_PhysicalInformation.HeightEnumId == queryParam.HeightEnumId) &&
                    (queryParam.HeightFrom == null || t.PersonId_PhysicalInformation.Height >= queryParam.HeightFrom) &&
                    (queryParam.HeightThru == null || t.PersonId_PhysicalInformation.Height <= queryParam.HeightThru) &&
                    (string.IsNullOrEmpty(queryParam.WeightEnumId) ||
                     t.PersonId_PhysicalInformation.WeightEnumId == queryParam.WeightEnumId) &&
                    (queryParam.WeightFrom == null || t.PersonId_PhysicalInformation.Weight >= queryParam.WeightFrom) &&
                    (queryParam.WeightThru == null || t.PersonId_PhysicalInformation.Weight <= queryParam.WeightThru) &&

                    (queryParam.IsActive == null ||
                     (queryParam.IsActive.Value &&
                      t.PersonId_User.UserApplId_UserAppls.Any(
                          p => p.FromDate <= DateTime.Now && p.ThruDate >= DateTime.Now))) &&
                    (queryParam.AgeFrom == 0 ||
                     (t.DateOfBirth.Value.Year <= birthDateFromAge.Year &&
                      (birthDateFromAge.Year - t.DateOfBirth.Value.Year > 0
                          ? true
                          : t.DateOfBirth.Value.Month <= birthDateFromAge.Month)
                         )
                        ) &&
                    (queryParam.ThruAge == 0 ||
                     (t.DateOfBirth.Value.Year >= birthDateThruAge.Year &&
                      (t.DateOfBirth.Value.Year - birthDateThruAge.Year > 0
                          ? true
                          : t.DateOfBirth.Value.Month > birthDateThruAge.Month)
                         )
                        )


                );
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

        public QueryResult CheckUserPhone(string phoneNumber)
        {
            var userFound = ModelManagementContext().Users.FirstOrDefault(t => t.PrimaryPhoneNumber == phoneNumber);
            if (userFound == null)
                return new QueryResult { IsSuccess = false, ErrorMessage = "Your phone number is not registered!" };
            return userFound.IsUserActivated == "Y"
                ? new QueryResult { IsSuccess = false, ErrorMessage = "Your account is already activated!" }
                : Utility.QuerySuccessResult(true);
        }

        public QueryResult CheckUserPhoneExists(string phoneNumber,string email)
        {
            var userPhone = ModelManagementContext().Users.FirstOrDefault(t => t.PrimaryPhoneNumber == phoneNumber);
            if (userPhone != null)
                return new QueryResult {IsSuccess = false, ErrorMessage = "The phone number already exists!"};
            var userEmail = ModelManagementContext().Users.FirstOrDefault(t => t.PrimaryEmail == email);
            return userEmail != null
                ? new QueryResult {IsSuccess = false, ErrorMessage = "The email already exists!"}
                : Utility.QuerySuccessResult(true);
        }

        public QueryResult ListPersonUplodables(string personId, string fileTypeId, string fileUploadId)
        {
            var result =
                ModelManagementContext()
                    .Uploadables.Where(
                        t =>
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
            var result =
                ModelManagementContext()
                    .ContactMechTypes.Where(t => t.IsActive == "Y")
                    .GroupBy(g => g.ContactMechTypeId)
                    .ToList()
                    .Select(s => new ContactInformationListModel
                    {
                        PersonId = personId,
                        ContactMechTypeId = s.Key,
                        ContactMechType = s.FirstOrDefault()?.Description,
                        ContactUrl =
                            s.FirstOrDefault()?
                                .ContactInformations.FirstOrDefault(t => t.PersonId == personId)?
                                .ContactUrl
                    }).ToList();
            return Utility.QuerySuccessResult(result);
        }

        public QueryResult ListJobOffer(string jobPostId,string statusId,QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .JobOffers.Where(
                        t =>
                            (string.IsNullOrEmpty(jobPostId) || t.JobPostId == jobPostId) &&
                            (string.IsNullOrEmpty(statusId) || t.StatusId == statusId))
                    .QueryResultList<JobOfferListModel>(queryParamArg);
        }

        public QueryResult EditJobOffer(string jobOfferId, string jobPostId,string offeredUserId)
        {
            return
                ModelManagementContext()
                    .JobOffers.Where(
                        t =>
                            (string.IsNullOrEmpty(jobOfferId) || t.JobPostId == jobPostId) &&
                            (string.IsNullOrEmpty(jobPostId) || t.JobPostId == jobPostId) &&
                            (string.IsNullOrEmpty(offeredUserId) || t.OfferedUserId == offeredUserId)
                    ).QueryResultGet<JobOfferListModel>();
        }

        public QueryResult ListModels(ListModelsQueryParamArg listModelsQueryParamArg, QueryParamArg queryParamArg)
        {
            var birthDateFromAge = DateTime.Now.AddYears(-listModelsQueryParamArg.AgeFrom);
            var birthDateThruAge = DateTime.Now.AddYears(-(listModelsQueryParamArg.ThruAge + 1));

            var result =
                ModelManagementContext()
                    .Users.Where(
                        t =>
                            t.IsUserActivated == "Y" && t.StatusId == Utility.StatusEnabled &&
                            t.UserRoleId_UserRoles.Any(l => l.RoleTypeId == Utility.RoleTypeModel) &&
                            (string.IsNullOrEmpty(listModelsQueryParamArg.Sex) ||
                             t.PersonId_PersonalInformation.Sex == listModelsQueryParamArg.Sex) &&
                            (listModelsQueryParamArg.CategoryTypeIds.Count == 0 ||
                             t.PersonId_PersonalInformation.Categories_PersonId.Any(
                                 c => listModelsQueryParamArg.CategoryTypeIds.Contains(c.CategoryTypeId))
                                ) &&
                            (listModelsQueryParamArg.HeightFrom == null ||
                             t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Height >=
                             listModelsQueryParamArg.HeightFrom) &&
                            (listModelsQueryParamArg.HeightThru == null ||
                             t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Height <=
                             listModelsQueryParamArg.HeightThru) &&
                            (string.IsNullOrEmpty(listModelsQueryParamArg.CategoryTypeId) ||
                             t.PersonId_PersonalInformation.Categories_PersonId
                                 .Any(c => c.CategoryTypeId == listModelsQueryParamArg.CategoryTypeId)
                                ) &&
                            (listModelsQueryParamArg.AgeFrom == 0 ||
                             (t.PersonId_PersonalInformation.DateOfBirth.Value.Year <= birthDateFromAge.Year &&
                              (birthDateFromAge.Year - t.PersonId_PersonalInformation.DateOfBirth.Value.Year > 0 ||
                               t.PersonId_PersonalInformation.DateOfBirth.Value.Month <= birthDateFromAge.Month)
                                 )) &&
                            (listModelsQueryParamArg.ThruAge == 0 ||
                             (t.PersonId_PersonalInformation.DateOfBirth.Value.Year >= birthDateThruAge.Year &&
                              (t.PersonId_PersonalInformation.DateOfBirth.Value.Year - birthDateThruAge.Year > 0 ||
                               t.PersonId_PersonalInformation.DateOfBirth.Value.Month > birthDateThruAge.Month)
                                 )) &&
                            (string.IsNullOrEmpty(listModelsQueryParamArg.Complexion) ||
                             t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Complexion ==
                             listModelsQueryParamArg.Complexion) &&
                            (string.IsNullOrEmpty(listModelsQueryParamArg.CountryGeoId) ||
                             t.PersonId_PersonalInformation.CountryGeoId == listModelsQueryParamArg.CountryGeoId) &&
                            (string.IsNullOrEmpty(listModelsQueryParamArg.CityGeoId) ||
                             t.PersonId_PersonalInformation.CityGeoId == listModelsQueryParamArg.CityGeoId) &&
                            (listModelsQueryParamArg.BmiFrom == null ||
                             t.PersonId_PersonalInformation.PersonId_PhysicalInformation.BmI >=
                             listModelsQueryParamArg.BmiFrom) &&
                            (listModelsQueryParamArg.BmiThru == null ||
                             t.PersonId_PersonalInformation.PersonId_PhysicalInformation.BmI <=
                             listModelsQueryParamArg.BmiThru) &&
                            (listModelsQueryParamArg.WeightFrom == null ||
                             t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Weight >=
                             listModelsQueryParamArg.WeightFrom) &&
                            (listModelsQueryParamArg.WeightThru == null ||
                             t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Weight <=
                             listModelsQueryParamArg.WeightThru) &&
                            (listModelsQueryParamArg.SelectedCities.Count == 0 ||
                             listModelsQueryParamArg.SelectedCities.Contains(t.PersonId_PersonalInformation.CityGeoId)) &&
                            (string.IsNullOrEmpty(listModelsQueryParamArg.ExperienceId) ||
                             t.PersonId_PersonalInformation.ExperienceEnumId == listModelsQueryParamArg.ExperienceId)
                    );
            return result.QueryResultList<ModelListModel>(queryParamArg);
        }

        public QueryResult CheckUserVerificationCode(string phoneNumber,string verificationCode)
        {
            var result =
                ModelManagementContext()
                    .Users.FirstOrDefault(
                        t => t.PrimaryPhoneNumber == phoneNumber && t.VerificationCode == verificationCode);
            return result == null
                ? Utility.QueryErrorResult("Invalid verification code.")
                : Utility.QuerySuccessResult(true);
        }

        public QueryResult LookupSkillType()
        {
            return ModelManagementContext().SkillTypes.QueryResultList<KeyDescription>();
        }

        public QueryResult ListSkill(string personId,QueryParamArg queryParamArg)
        {
            return
                ModelManagementContext()
                    .Skills.Where(t => t.PersonId == personId)
                    .QueryResultList<SkillListModel>(queryParamArg);
        }
    }
}
