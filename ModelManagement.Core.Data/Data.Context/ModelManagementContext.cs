using ModelManagement.Core.Data.Data.Mapping;
using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity;

namespace ModelManagement.Core.Data.Data.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ModelManagementContext : DbContext
    {

        public ModelManagementContext() : base("ModelingContext")
        {
            Configuration.ValidateOnSaveEnabled = false;
        }

        static ModelManagementContext()
        {
            DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
        }
        public DbSet<PersonalInformation> PersonalInformations { get; set; }
        public DbSet<ModelingExperiance> ModelingExperiances { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EnumerationType> EnumerationTypes { get; set; }
        public DbSet<Enumeration> Enumerations { get; set; }
        public DbSet<Adderss> Addresses { get; set; }
        public DbSet<PhysicalInformation> PhysicalInformations { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<ContactMechType> ContactMechTypes { get; set; }
        public DbSet<StatusItem> StatusTypes { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<Uploadable> Uploadables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperiance> WorkExperiances { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserLoginPasswordHistory> UserLoginPasswordHistories { get; set; }
        public DbSet<SystemConfiguration> SystemConfigurations { get; set; }
        public DbSet<UserAppl> UserAppls { get; set; }
        public DbSet<GeoType> GeoTypes { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<GeoAssoc> GeoAssoces { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<OfferItemType> OfferItemTypes { get; set; }
        public DbSet<Model.OfferItemTypeMap> OfferItemTypeMapes { get; set; }
        public DbSet<UserAgentType> UserAgentTypes { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ModelManagementContext>(null);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new PersonalInformationMap());
            modelBuilder.Configurations.Add(new ModelingExperianceMap());
            modelBuilder.Configurations.Add(new CategoryTypeMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new PhysicalInformationMap());
            modelBuilder.Configurations.Add(new ContactMechTypeMap());
            modelBuilder.Configurations.Add(new ContactInformationMap());
            modelBuilder.Configurations.Add(new StatusItemMap());
            modelBuilder.Configurations.Add(new FileTypeMap());
            modelBuilder.Configurations.Add(new UploadableMap());
            modelBuilder.Configurations.Add(new RoleTypeMap());
            modelBuilder.Configurations.Add(new TrainingMap());
            modelBuilder.Configurations.Add(new SkillMap());
            modelBuilder.Configurations.Add(new WorkExperianceMap());
            modelBuilder.Configurations.Add(new EnumerationTypeMap());
            modelBuilder.Configurations.Add(new EnumerationMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
            modelBuilder.Configurations.Add(new UserLoginPasswordHistoryMap());
            modelBuilder.Configurations.Add(new SystemConfigurationMap());
            modelBuilder.Configurations.Add(new UserApplMap());
            modelBuilder.Configurations.Add(new GeoTypeMap());
            modelBuilder.Configurations.Add(new GeoMap());
            modelBuilder.Configurations.Add(new GeoAssocMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new UserStatusMap());
            modelBuilder.Configurations.Add(new OfferTypeMap());
            modelBuilder.Configurations.Add(new Mapping.OfferItemTypeMap());
            modelBuilder.Configurations.Add(new OfferItemTypeMapMap());
            modelBuilder.Configurations.Add(new UserAgentTypeMap());
            modelBuilder.Configurations.Add(new VisitorMap());
            modelBuilder.Configurations.Add(new VisitMap());
            modelBuilder.Configurations.Add(new JobPostMap());
            modelBuilder.Configurations.Add(new JobOfferMap());
        }
    }
}
