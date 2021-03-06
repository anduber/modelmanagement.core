﻿using ModelManagement.Core.Business.Business.Helpers;
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
            MapDesc<User>(
                t => t.PersonId_PersonalInformation.FirstName + " " + t.PersonId_PersonalInformation.FatherName);
            MapDesc<Enumeration>(t => t.Description);
            MapDesc<Geo>(t => t.GeoName);
            MapDesc<JobPost>(t => t.JobTitle);
            #endregion

            #region KeyDescriptions
            MapKeyDesc<ContactMechType>(t => t.ContactMechTypeId, t => t.Description);
            MapKeyDesc<Enumeration>(t => t.EnumerationId, t => t.Description);
            MapKeyDesc<FileType>(t => t.FileTypeId, t => t.Description);
            MapKeyDesc<RoleType>(t => t.RoleTypeId, t => t.Description);
            MapKeyDesc<StatusItem>(t => t.StatusId, t => t.Description);
            MapKeyDesc<CategoryType>(t => t.CategoryTypeId, t => t.Description);
            MapKeyDescId<CategoryType>(t => t.CategoryTypeId, t => t.Description, t => t.ParentTypeId);
            MapKeyDesc<Category>(t => t.CategoryTypeId, t => t.CategoryTypeId_CategoryType.Description);
            MapKeyDesc<SkillType>(t => t.SkillTypeId, t => t.Description);
            #endregion

            CreateMap<PersonalInformation, PersonalInformationQueryModel>()
                .ForMember(t => t.UserNumber, opt => opt.MapFrom(t => t.PersonId_User.UserNumber))
                .ForMember(t => t.StatusId, opt => opt.MapFrom(t => t.PersonId_User.StatusId))
                .ForMember(t => t.Status, opt => opt.MapFrom(t => t.PersonId_User.StatusId_StatusItem))
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
                .ForMember(t => t.UserNumber, opt => opt.MapFrom(t => t.PersonId_User.UserNumber))
                .ForMember(t => t.StatusId, opt => opt.MapFrom(t => t.PersonId_User.StatusId))
                .ForMember(t => t.Status, opt => opt.MapFrom(t => t.PersonId_User.StatusId_StatusItem.Description))
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
                .ForMember(t => t.Experience, opt => opt.MapFrom(t => t.ExperienceEnumId_Enumeration))
                .ForMember(t => t.PrimaryEmail, opt => opt.MapFrom(t => t.PersonId_User.PrimaryEmail))
                .ForMember(t => t.PrimaryPhoneNumber, opt => opt.MapFrom(t => t.PersonId_User.PrimaryPhoneNumber))
                .ForMember(t => t.TaxId, opt => opt.MapFrom(t => t.PersonId_User.TaxId))
                .ForMember(t => t.Height, opt => opt.MapFrom(t => t.PersonId_PhysicalInformation.Height))
                .ForMember(t => t.Weight, opt => opt.MapFrom(t => t.PersonId_PhysicalInformation.Weight))
                .ForMember(t => t.Complexion, opt => opt.MapFrom(t => t.PersonId_PhysicalInformation.Complexion))
                .ForMember(t => t.Bmi, opt => opt.MapFrom(t => t.PersonId_PhysicalInformation.BmI))
                .ForMember(t => t.ProfilePic,
                    opt =>
                        opt.MapFrom(
                            t =>
                                t.PersonId_User.User_Contents.FirstOrDefault(c => c.ContentTypeId == "PROFILE_PIC") ==
                                null
                                    ? null
                                    : t.PersonId_User.User_Contents.FirstOrDefault(c => c.ContentTypeId == "PROFILE_PIC")
                                        .ContentName))

                ;

            CreateMap<PersonalInformation, ModelsInfoListModel>()

                ;

            CreateMap<User, UserQueryModel>()
                 .ForMember(t => t.Status, opt => opt.MapFrom(t => t.StatusId_StatusItem))
                 ;
            CreateMap<Uploadable, UplodableListModel>()
                 ;
            CreateMap<PhysicalInformation, PhysicalInformationEditModel>()
                .ForMember(t => t.ComplexionDesc, opt => opt.MapFrom(t => t.Complexion_Enumeration))
                .ForMember(t => t.HairColorDesc, opt => opt.MapFrom(t => t.HairColor_Enumeration))
                ;
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
                .ForMember(t => t.NoOfPeopleApplied, opt => opt.MapFrom(t => t.JobPost_JobApplications.Count))
                .ForMember(t => t.JobLocationGeo, opt => opt.MapFrom(t => t.JobPost_JobLocationGeoId))
                ;

            CreateMap<JobOffer, JobOfferListModel>()
                .ForMember(t => t.ModelUser, opt => opt.MapFrom(t => t.JobOffer_ModelUserId))
                .ForMember(t => t.JobPost, opt => opt.MapFrom(t => t.JobPost_JobOfferId))
                .ForMember(t => t.AgentUser,
                    opt => opt.MapFrom(t => t.JobPost_JobOfferId.JobPost_UserId))
                ;

            CreateMap<Content, ContentListModel>();

            CreateMap<User, ModelListModel>()
                .ForMember(t => t.FirstName, opt => opt.MapFrom(t => t.PersonId_PersonalInformation.FirstName))
                .ForMember(t => t.FatherName, opt => opt.MapFrom(t => t.PersonId_PersonalInformation.FatherName))
                .ForMember(t => t.Description, opt => opt.MapFrom(t => t.PersonId_PersonalInformation.Description))
                .ForMember(t => t.Experience,
                    opt => opt.MapFrom(t => t.PersonId_PersonalInformation.ExperienceEnumId_Enumeration))
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
                .ForMember(t => t.ProfileImage,
                    opt =>
                        opt.MapFrom(
                            t =>
                                t.User_Contents.FirstOrDefault(c => c.ContentTypeId == "PROFILE_PIC") == null
                                    ? null
                                    : t.User_Contents.FirstOrDefault(c => c.ContentTypeId == "PROFILE_PIC").ContentName))
                ;

            CreateMap<ContentData, ContentDataListModel>();

            CreateMap<JobApplication, JobApplicationListModel>()
                .ForMember(t => t.ApplyingUser,
                    opt =>
                        opt.MapFrom(
                            t =>
                                t.JobApplication_ApplyingUser.PersonId_PersonalInformation.FirstName +
                                t.JobApplication_ApplyingUser.PersonId_PersonalInformation.FatherName))
                .ForMember(t => t.ApplyingPersonId,
                    opt => opt.MapFrom(t => t.JobApplication_ApplyingUser.PersonId_PersonalInformation.PersonId))
                .ForMember(t => t.ApplyingUserProfilePic,
                    opt =>
                        opt.MapFrom(
                            t =>
                                t.JobApplication_ApplyingUser.User_Contents.FirstOrDefault(
                                    c => c.ContentTypeId == "PROFILE_PIC") == null
                                    ? null
                                    : t.JobApplication_ApplyingUser.User_Contents.FirstOrDefault(
                                        c => c.ContentTypeId == "PROFILE_PIC").ContentName))
                ;

            CreateMap<Skill, SkillListModel>();



        }
    }
}
