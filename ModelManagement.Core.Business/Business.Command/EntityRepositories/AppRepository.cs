using ModelManagement.Core.Data.Data.Context;
using ModelManagement.Core.Data.Data.Model;
using ModelManagement.Core.Data.Data.Repository.GenericRepository;

namespace ModelManagement.Core.Business.Business.Command.EntityRepositories
{
    public class AppRepository
    {
        public ModelManagementContext Context;

        private EntityRepository<UserRole> _userRoleRepository;
        private EntityRepository<User> _userRepository;
        private EntityRepository<UserLogin> _userLoginRepository;
        private EntityRepository<PersonalInformation> _personalInfoRepository;
        private EntityRepository<PhysicalInformation> _physicalInfoRepository;
        private EntityRepository<UserAppl> _userApplRepository;
        private EntityRepository<UserStatus> _userStatusRepository;
        private EntityRepository<OfferType> _offerTypeRepository;
        private EntityRepository<OfferItemType> _offerItemTypeRepository;
        private EntityRepository<OfferItemTypeMap> _offerItemTypeMapRepository;
        private EntityRepository<Visitor> _visitorRepository;
        private EntityRepository<Visit> _visitRepository;
        private EntityRepository<EnumerationType> _enumerationTypeRepository;
        private EntityRepository<Enumeration> _enumerationRepository;
        private EntityRepository<GeoType> _geoTypeRepository;
        private EntityRepository<Geo> _geoRepository;
        private EntityRepository<GeoAssoc> _geoAssocRepository;
        private EntityRepository<JobPost> _jobPostRepository;
        private EntityRepository<JobOffer> _jobOfferRepository;
        private EntityRepository<Uploadable> _uploadableRepository;
        private EntityRepository<Category> _categoryRepository;
        private EntityRepository<ContactInformation> _contactInfoRepository;
        private EntityRepository<Content> _contentRepository;
        private EntityRepository<ContentType> _contentTypeRepository;
        private EntityRepository<ContentData> _contentDataRepository;
        private EntityRepository<StatusType> _statusTypeRepository;
        private EntityRepository<JobApplication> _jobApplicationRepository;
        private EntityRepository<Skill> _skillRepository;

        public AppRepository(ModelManagementContext context = null)
        {
            Context = context ?? new ModelManagementContext();
        }

        public EntityRepository<UserRole> UserRole()
        {
            return _userRoleRepository ?? (_userRoleRepository = new EntityRepository<UserRole>(Context));
        }

        public EntityRepository<User> User()
        {
            return _userRepository ?? (_userRepository = new EntityRepository<User>(Context));
        }

        public EntityRepository<UserLogin> UserLogin()
        {
            return _userLoginRepository ?? (_userLoginRepository = new EntityRepository<UserLogin>(Context));
        }

        public EntityRepository<PersonalInformation> PersonalInformation()
        {
            return _personalInfoRepository ?? (_personalInfoRepository = new EntityRepository<PersonalInformation>(Context));
        }

        public EntityRepository<PhysicalInformation> PhysicalInformation()
        {
            return _physicalInfoRepository ?? (_physicalInfoRepository = new EntityRepository<PhysicalInformation>(Context));
        }

        public EntityRepository<UserAppl> UserAppl()
        {
            return _userApplRepository ?? (_userApplRepository = new EntityRepository<UserAppl>(Context));
        }

        public EntityRepository<UserStatus> UserStatus()
        {
            return _userStatusRepository ?? (_userStatusRepository = new EntityRepository<UserStatus>(Context));
        }

        public EntityRepository<OfferType> OfferType()
        {
            return _offerTypeRepository ?? (_offerTypeRepository = new EntityRepository<OfferType>(Context));
        }

        public EntityRepository<ContactInformation> ContactInfo()
        {
            return _contactInfoRepository ?? (_contactInfoRepository = new EntityRepository<ContactInformation>(Context));
        }

        public EntityRepository<OfferItemType> OfferItemType()
        {
            return _offerItemTypeRepository ?? (_offerItemTypeRepository = new EntityRepository<OfferItemType>(Context));
        }

        public EntityRepository<OfferItemTypeMap> OfferItemTypeMap()
        {
            return _offerItemTypeMapRepository ?? (_offerItemTypeMapRepository = new EntityRepository<OfferItemTypeMap>(Context));
        }

        public EntityRepository<Visitor> Visitor()
        {
            return _visitorRepository ?? (_visitorRepository = new EntityRepository<Visitor>(Context));
        }

        public EntityRepository<Visit> Visit()
        {
            return _visitRepository ?? (_visitRepository = new EntityRepository<Visit>(Context));
        }

        public EntityRepository<EnumerationType> EnumerationType()
        {
            return _enumerationTypeRepository ?? (_enumerationTypeRepository = new EntityRepository<EnumerationType>(Context));
        }

        public EntityRepository<Enumeration> Enumeration()
        {
            return _enumerationRepository ?? (_enumerationRepository = new EntityRepository<Enumeration>(Context));
        }

        public EntityRepository<GeoType> GeoType()
        {
            return _geoTypeRepository ?? (_geoTypeRepository = new EntityRepository<GeoType>(Context));
        }

        public EntityRepository<GeoAssoc> GeoAssoc()
        {
            return _geoAssocRepository ?? (_geoAssocRepository = new EntityRepository<GeoAssoc>(Context));
        }

        public EntityRepository<Geo> Geo()
        {
            return _geoRepository ?? (_geoRepository = new EntityRepository<Geo>(Context));
        }

        public EntityRepository<JobPost> JobPost()
        {
            return _jobPostRepository ?? (_jobPostRepository = new EntityRepository<JobPost>(Context));
        }

        public EntityRepository<JobOffer> JobOffer()
        {
            return _jobOfferRepository ?? (_jobOfferRepository = new EntityRepository<JobOffer>(Context));
        }

        public EntityRepository<Uploadable> Uploadable()
        {
            return _uploadableRepository ?? (_uploadableRepository = new EntityRepository<Uploadable>(Context));
        }

        public EntityRepository<Category> Category()
        {
            return _categoryRepository ?? (_categoryRepository = new EntityRepository<Category>(Context));
        }

        public EntityRepository<Content> Content()
        {
            return _contentRepository ?? (_contentRepository = new EntityRepository<Content>(Context));
        }

        public EntityRepository<ContentType> ContentType()
        {
            return _contentTypeRepository ?? (_contentTypeRepository = new EntityRepository<ContentType>(Context));
        }

        public EntityRepository<ContentData> ContentData()
        {
            return _contentDataRepository ?? (_contentDataRepository = new EntityRepository<ContentData>(Context));
        }

        public EntityRepository<StatusType> StatusType()
        {
            return _statusTypeRepository ?? (_statusTypeRepository = new EntityRepository<StatusType>(Context));
        }

        public EntityRepository<JobApplication> JobApplication()
        {
            return _jobApplicationRepository ?? (_jobApplicationRepository = new EntityRepository<JobApplication>(Context));
        }

        public EntityRepository<Skill> Skill()
        {
            return _skillRepository ?? (_skillRepository = new EntityRepository<Skill>(Context));
        }
    }
}
