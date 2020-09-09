using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Data.Data.Model;
using System.Linq;
using ModelManagement.Core.Business.Business.Query.Models;

namespace ModelManagement.Core.Business.Business.Query.EntityProfile
{
    public class ModelMappingProfile : BaseProfile
    {
        protected override void CreateMappings()
        {
            #region Description
            MapDesc<CategoryType>(t => t.Description);
            MapDesc<ContactMechType>(t => t.Description);
            MapDesc<FileType>(t => t.Description);
            MapDesc<StatusItem>(t => t.Description);
            MapDesc<RoleType>(t => t.Description);
            MapDesc<UserLogin>(t => t.User_PersonId.PersonId_PersonalInformation.FirstName);
            MapDesc<User>(t => t.Description);
            #endregion

            #region KeyDescriptions
            MapKeyDesc<ContactMechType>(t => t.ContactMechTypeId, t => t.Description);
            MapKeyDesc<Enumeration>(t => t.EnumerationId, t => t.Description);
            MapKeyDesc<FileType>(t => t.FileTypeId, t => t.Description);
            MapKeyDesc<RoleType>(t => t.RoleTypeId, t => t.Description);
            MapKeyDesc<StatusItem>(t => t.StatusId, t => t.Description);
            MapKeyDesc<CategoryType>(t => t.CategoryTypeId, t => t.Description);
            MapKeyDesc<Category>(t => t.CategoryTypeId, t => t.CategoryTypeId_CategoryType.Description);
            #endregion

            CreateMap<PersonalInformation, PersonalInformationQueryModel>()
                .ForMember(t => t.UserNumber, opt => opt.MapFrom(t => t.PersonId_User.UserNumber))
                //.ForMember(t => t.UserName, opt => opt.MapFrom(t => t.PersonId_User.UserName))
                //.ForMember(t => t.PrimaryCategoryType, opt => opt.MapFrom(t => t.CategoryType_PrimaryCategoryTypeId))
                .ForMember(t => t.StatusId, opt => opt.MapFrom(t => t.PersonId_User.StatusId))
                .ForMember(t => t.Status, opt => opt.MapFrom(t => t.PersonId_User.StatusId_StatusItem))
                //.ForMember(t => t.Age, opt => opt.MapFrom(t => t.DateOfBirth == null ? 0 : DateConverter.CalculateAge(t.DateOfBirth.Value)))

                //.ForMember(t => t.ProfilePicUrl, opt => opt.MapFrom(t => t.Uploadables_PersonId.FirstOrDefault(x => x.FileTypeId == "PROFILE_PIC") == null ? "" :
                //                                                                                    t.Uploadables_PersonId.FirstOrDefault(x => x.FileTypeId == "PROFILE_PIC")
                //                                                                                    .FileName))
                .ForMember(t => t.ProfilePicFileUploadId,
                    opt =>
                        opt.MapFrom(
                            t =>
                                t.Uploadables_PersonId.FirstOrDefault(x => x.FileTypeId == "PROFILE_PIC") == null
                                    ? ""
                                    : t.Uploadables_PersonId.FirstOrDefault(x => x.FileTypeId == "PROFILE_PIC")
                                        .FileUploadId))

                ;

            CreateMap<PersonalInformation, PersonalInfoListModel>()
                //  .ForMember(t => t.UserName, opt => opt.MapFrom(t => t.PersonId_User.UserName))
                .ForMember(t => t.UserNumber, opt => opt.MapFrom(t => t.PersonId_User.UserNumber))
                .ForMember(t => t.StatusId, opt => opt.MapFrom(t => t.PersonId_User.StatusId))
                .ForMember(t => t.Status, opt => opt.MapFrom(t => t.PersonId_User.StatusId_StatusItem.Description))
                //.ForMember(t => t.Age, opt => opt.MapFrom(t => t.DateOfBirth == null ? 0 : DateConverter.CalculateAge(t.DateOfBirth.Value)))
                .ForMember(t => t.Height, opt => opt.MapFrom(t => t.PersonId_PhysicalInformation.Height))
                .ForMember(t => t.Weight, opt => opt.MapFrom(t => t.PersonId_PhysicalInformation.Weight))

                ;

            CreateMap<PersonalInformation, PersonalInfoEditModel>()
                // .ForMember(t => t.UserName, opt => opt.MapFrom(t => t.PersonId_User.UserName))
                .ForMember(t => t.UserNumber, opt => opt.MapFrom(t => t.PersonId_User.UserNumber))
                .ForMember(t => t.UserName, opt => opt.MapFrom(t => t.UserLoginId_UserLogin.UserName))
                .ForMember(t => t.StatusId, opt => opt.MapFrom(t => t.PersonId_User.StatusId))
                .ForMember(t => t.Status, opt => opt.MapFrom(t => t.PersonId_User.StatusId_StatusItem.Description))
                .ForMember(t => t.Categories, opt => opt.MapFrom(t => t.Categories_PersonId))
                .ForMember(t => t.PrimaryEmail, opt => opt.MapFrom(t => t.PersonId_User.PrimaryEmail))
                .ForMember(t => t.PrimaryPhoneNumber, opt => opt.MapFrom(t => t.PersonId_User.PrimaryPhoneNumber))
                //.ForMember(t => t.CountryGeoId,
                //    opt => opt.MapFrom(t => t.GeoId_Geo.GeoTypeId == Utility.GeoTypes.Country ? t.GeoId : null))
                //.ForMember(t => t.CityGeoId,
                //    opt => opt.MapFrom(t => t.GeoId_Geo.GeoTypeId == Utility.GeoTypes.City ? t.GeoId : null))
                //.ForMember(t => t.ProfilePic,
                //    opt =>
                //        opt.MapFrom(
                //            t =>
                //                t.Uploadables_PersonId.FirstOrDefault(x => x.FileTypeId == Utility.FileTypeProfilePic) ==
                //                null
                //                    ? null
                //                    : t.Uploadables_PersonId.FirstOrDefault(
                //                        x => x.FileTypeId == Utility.FileTypeProfilePic)
                //                        .FileData))
                //.ForMember(t => t.ProfilePicFileId,
                //    opt =>
                //        opt.MapFrom(
                //            t =>
                //                t.Uploadables_PersonId.FirstOrDefault(x => x.FileTypeId == Utility.FileTypeProfilePic) ==
                //                null
                //                    ? null
                //                    : t.Uploadables_PersonId.FirstOrDefault(
                //                        x => x.FileTypeId == Utility.FileTypeProfilePic)
                //                        .FileUploadId))
                ;

            CreateMap<PersonalInformation, ModelsInfoListModel>()
                //.ForMember(t => t.Age,
                //    opt => opt.MapFrom(t => t.DateOfBirth == null ? 0 : DateConverter.CalculateAge(t.DateOfBirth.Value)))
                //.ForMember(t => t.Height, opt => opt.MapFrom(t => t.PhysicalInformation_PersonId.Height))
                //.ForMember(t => t.HeightUom,
                //    opt => opt.MapFrom(t => t.PhysicalInformation_PersonId.HeightEnumId_Enumeration.Description))
                //.ForMember(t => t.Weight, opt => opt.MapFrom(t => t.PhysicalInformation_PersonId.Weight))
                //.ForMember(t => t.WeightUom,
                //    opt => opt.MapFrom(t => t.PhysicalInformation_PersonId.WeightEnumId_Enumeration.Description))
                //.ForMember(t => t.Height, opt => opt.MapFrom(t => t.PhysicalInformation_PersonId.Height))
                //.ForMember(t => t.ProfilePic,
                //    opt =>
                //        opt.MapFrom(
                //            t =>
                //                t.Uploadables_PersonId.FirstOrDefault(x => x.FileTypeId == Utility.ContentTypeProfilePic) ==
                //                null
                //                    ? null
                //                    : t.Uploadables_PersonId.FirstOrDefault(
                //                        x => x.FileTypeId == Utility.ContentTypeProfilePic)
                //                        .FileData))
                ;

            CreateMap<User, UserQueryModel>()
                 .ForMember(t => t.Status, opt => opt.MapFrom(t => t.StatusId_StatusItem))
                 //.ForMember(t => t.RoleType, opt => opt.MapFrom(t => t.RoleType_RoleTypeId))
                 ;
            CreateMap<Uploadable, UplodableListModel>()
                 //.ForMember(t => t.FileType, opt => opt.MapFrom(t => t.FileType_FileTypeId))
                 //.ForMember(t => t.ParentFileType, opt => opt.MapFrom(t => t.FileType_FileTypeId.FileType_ParentFileTypeId.Description))
                 ;
            CreateMap<PhysicalInformation, PhysicalInformationEditModel>();
            CreateMap<Category, CategoryQueryModel>()
                .ForMember(t => t.CategoryType, opt => opt.MapFrom(t => t.CategoryTypeId_CategoryType))
                .ForMember(t => t.CategoryId, opt => opt.MapFrom(t => t.CategoryTypeId));
            CreateMap<ContactInformation, ContactInformationListModel>();
            //.ForMember(t => t.ContactMechType, opt => opt.MapFrom(t => t.ContactMechTypeId_ContactMechType));

            CreateMap<Enumeration, EnumerationListModel>();

            CreateMap<Geo, GeoListModel>();

            CreateMap<OfferType, OfferListModel>()
               .ForMember(t => t.OfferItemTypes, opt => opt.MapFrom(t => t.OfferTypeId_OfferType));


            CreateMap<OfferItemType, OfferItemTypeListModel>()
                .ForMember(t => t.UserLogin, opt => opt.MapFrom(t => t.UserLoginId_UserLogin));

            CreateMap<OfferItemTypeMap, OfferItemTypeListModel>()
                .ForMember(t => t.OfferItemTypeId, opt => opt.MapFrom(t => t.OfferItemTypeId_OfferItemType.OfferItemTypeId))
                .ForMember(t => t.Sequence, opt => opt.MapFrom(t => t.OfferTypeId_OfferType.Sequence))
                .ForMember(t => t.Description, opt => opt.MapFrom(t => t.OfferItemTypeId_OfferItemType.Description));

            CreateMap<OfferType, OfferTypeListModel>()
                .ForMember(t => t.UserLogin, opt => opt.MapFrom(t => t.UserLoginId_UserLogin))
                ;

            CreateMap<JobPost, JobPostListModel>()
                //.ForMember(t => t.UserLogin, opt => opt.MapFrom(t => t.UserLoginId_UserLogin))
                ;
            CreateMap<JobOffer, JobOfferListModel>()
                .ForMember(t => t.ModelUser, opt => opt.MapFrom(t => t.JobOffer_ModelUserId))
                ;

            CreateMap<Content, ContentListModel>();

            CreateMap<User, ModelListModel>()
                .ForMember(t => t.FirstName, opt => opt.MapFrom(t => t.PersonId_PersonalInformation.FirstName))
                .ForMember(t => t.FatherName, opt => opt.MapFrom(t => t.PersonId_PersonalInformation.FatherName))
                .ForMember(t => t.Sex, opt => opt.MapFrom(t => t.PersonId_PersonalInformation.Sex))
                .ForMember(t => t.Height,
                    opt => opt.MapFrom(t => t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Height))
                .ForMember(t => t.Weight,
                    opt => opt.MapFrom(t => t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Weight))
                .ForMember(t => t.Complexion,
                    opt => opt.MapFrom(t => t.PersonId_PersonalInformation.PersonId_PhysicalInformation.Complexion))
                .ForMember(t => t.HairColor,
                    opt => opt.MapFrom(t => t.PersonId_PersonalInformation.PersonId_PhysicalInformation.HairColor))
                .ForMember(t => t.EyeColor,
                    opt => opt.MapFrom(t => t.PersonId_PersonalInformation.PersonId_PhysicalInformation.EyeColor))
                ;

            CreateMap<ContentData, ContentDataListModel>();

            CreateMap<JobApplication, JobApplicationListModel>()
                .ForMember(t => t.ApplyingUser, opt => opt.MapFrom(t => t.JobApplication_ApplyingUser.UserNumber));

            ;

        }
    }
}
