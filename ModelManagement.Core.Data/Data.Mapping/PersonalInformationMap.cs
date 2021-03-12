using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class PersonalInformationMap : EntityTypeConfiguration<PersonalInformation>
    {
        public PersonalInformationMap()
        {
            #region Configuration
            this.HasKey(t => new { t.PersonId });

            HasOptional(t => t.Adderss)
                .WithRequired(s => s.PersonId_PersonalInformation);

            HasOptional(t => t.PersonId_PhysicalInformation)
                .WithRequired(s => s.PersonalInformation);

            HasOptional(t => t.ExperienceEnumId_Enumeration)
                .WithMany(t => t.PersonalInformationExperiance_PersonalInformation)
                .HasForeignKey(t => t.ExperienceEnumId);

            HasOptional(t => t.GeoId_Geo)
               .WithMany(t => t.PersonId_PersonalInformation)
               .HasForeignKey(t => t.GeoId);

            HasOptional(t => t.CountryGeoId_Geo)
               .WithMany(t => t.Country_PersonGeoId_PersonalInformation)
               .HasForeignKey(t => t.CountryGeoId);

            HasOptional(t => t.CityGeoId_Geo)
               .WithMany(t => t.City_PersonGeoId_PersonalInformation)
               .HasForeignKey(t => t.CityGeoId);

            HasOptional(t => t.UserLoginId_UserLogin)
                .WithMany(t => t.PersonalInformationUserLogin_PersonId)
                .HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Property
            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.FirstName).HasMaxLength(50).HasColumnName("FIRST_NAME");
            Property(t => t.FatherName).HasMaxLength(50).HasColumnName("FATHER_NAME");
            Property(t => t.LastName).HasMaxLength(50).HasColumnName("LAST_NAME");
            Property(t => t.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
            Property(t => t.Sex).HasMaxLength(1).HasColumnName("SEX");
            Property(t => t.GeoId).HasColumnName("GEO_ID");
            Property(t => t.CityGeoId).HasColumnName("CITY_GEO_ID");
            Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            Property(t => t.CountryGeoId).HasMaxLength(50).HasColumnName("COUNTRY_GEO_ID");
            Property(t => t.MaritialStatusEnumId).HasMaxLength(50).HasColumnName("MARITIAL_STATUS_ENUM_ID");
            Property(t => t.ExperienceEnumId).HasColumnName("EXPERIENCE_ENUM_ID");
            Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            ToTable("personal_information");
        }
    }
}
