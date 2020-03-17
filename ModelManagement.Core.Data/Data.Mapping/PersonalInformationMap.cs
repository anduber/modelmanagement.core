using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class PersonalInformationMap : EntityTypeConfiguration<PersonalInformation>
    {
        public PersonalInformationMap()
        {
            #region Configuration
            this.HasKey(t => new { t.PersonId});

            this.HasOptional(t => t.Adderss)
                .WithRequired(s => s.PersonId_PersonalInformation);
            this.HasOptional(t => t.PhysicalInformation_PersonId)
                .WithRequired(s => s.PersonalInformation);
            this.HasOptional(t => t.Enumeration_MaritialStatusEnumId)
               .WithMany(t => t.MaritialStatus_PersonalInformation)
               .HasForeignKey(t => t.MaritialStatusEnumId);

            this.HasOptional(t => t.GeoId_Geo)
               .WithMany(t => t.PersonId_PersonalInformation)
               .HasForeignKey(t => t.GeoId);
            
            this.HasOptional(t => t.UserLoginId_UserLogin)
              .WithMany(t => t.PersonalInformationUserLogin_PersonId)
              .HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Property
            this.Property(t => t.PersonId).HasColumnName("PERSON_ID");
            this.Property(t => t.FirstName).HasMaxLength(50).HasColumnName("FIRST_NAME");
            this.Property(t => t.FatherName).HasMaxLength(50).HasColumnName("FATHER_NAME");
            this.Property(t => t.LastName).HasMaxLength(50).HasColumnName("LAST_NAME");
            this.Property(t => t.DateOfBirth).HasColumnName("DATE_OF_BIRTH");
            this.Property(t => t.Sex).HasMaxLength(1).HasColumnName("SEX");
            this.Property(t => t.GeoId).HasColumnName("GEO_ID");
            this.Property(t => t.MaritialStatusEnumId).HasColumnName("MARITIAL_STATUS_ENUM_ID");
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("personal_information");
        }
    }
}
