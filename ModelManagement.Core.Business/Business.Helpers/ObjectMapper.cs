using AutoMapper;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelManagement.Core.Business.Business.Command.CommandArgs;

namespace ModelManagement.Core.Business.Business.Helpers
{
    public class ObjectMapper
    {
        private readonly IMapper _mapper;

        public ObjectMapper()
        {
            var config = new MapperConfiguration(
                EntityMap);
            _mapper = config.CreateMapper();
        }

        public void EntityMap(IMapperConfiguration cfg)
        {
            #region User-UserCommandModel
            cfg.CreateMap<User, UserCommandModel>();
            cfg.CreateMap<UserCommandModel, User>();
            #endregion

            #region PersonalInformation-PersonalInformationCommandModel
            cfg.CreateMap<PersonalInformation, PersonalInformationCommandModel>();
            cfg.CreateMap<PersonalInformationArg, PersonalInformation>();
            cfg.CreateMap<PersonalInformationCommandModel, PersonalInformation>();
            #endregion

            #region PhysicalInformation-PhysicalInformationCommandModel
            cfg.CreateMap<PhysicalInformation, PhysicalInformationCommandModel>();
            cfg.CreateMap<PhysicalInformationCommandModel, PhysicalInformation>();
            cfg.CreateMap<PhysicalInformationArg, PhysicalInformation>();
            #endregion

            #region Uploadable-UploadableCommandModel
            cfg.CreateMap<Uploadable, UploadableCommandModel>();
            cfg.CreateMap<UploadableCommandModel, Uploadable>();
            #endregion

            #region FileType-FileTypeCommandModel
            cfg.CreateMap<FileType, FileTypeCommandModel>();
            cfg.CreateMap<FileTypeCommandModel, FileType>();
            #endregion

            #region StatusType-StatusTypeCommandModel
            cfg.CreateMap<StatusItem, StatusTypeCommandModel>();
            cfg.CreateMap<StatusTypeCommandModel, StatusItem>();
            #endregion

            #region RoleType-RoleTypeCommandModel
            cfg.CreateMap<RoleType, RoleTypeCommandModel>();
            cfg.CreateMap<RoleTypeCommandModel, RoleType>();
            #endregion

            #region CategoryType-CategoryTypeCommandModel
            cfg.CreateMap<CategoryType, CategoryTypeCommandModel>();
            cfg.CreateMap<CategoryTypeCommandModel, CategoryType>();
            #endregion

            #region Category-CategoryArgModel
            cfg.CreateMap<Category, CategoryArgModel>();
            cfg.CreateMap<CategoryArgModel, Category>();
            #endregion

            #region ContactMechType-ContactMechTypeCommandModel
            cfg.CreateMap<ContactMechType, ContactMechTypeCommandModel>();
            cfg.CreateMap<ContactMechTypeCommandModel, ContactMechType>();
            #endregion

            #region ContactInformation-ContactInformationCommandModel
            cfg.CreateMap<ContactInformation, ContactInformationCommandModel>();
            cfg.CreateMap<ContactInformationCommandModel, ContactInformation>();
            #endregion

            #region EnumerationType-EnumerationTypeCommandModel
            cfg.CreateMap<EnumerationType, EnumerationTypeCommandModel>();
            cfg.CreateMap<EnumerationTypeCommandModel, EnumerationType>();
            #endregion

            #region Enumeration-EnumerationCommandModel
            cfg.CreateMap<Enumeration, EnumerationCommandModel>();
            cfg.CreateMap<EnumerationCommandModel, Enumeration>();
            #endregion

            #region UserLogin-UserLoginCommandModel
            cfg.CreateMap<UserLogin, UserLoginCommandModel>();
            cfg.CreateMap<UserLoginCommandModel, UserLogin>();
            #endregion
        }

        public TTarget Map<TTarget>(object source)
        {
            return _mapper.Map<TTarget>(source);
        }
    }
}
