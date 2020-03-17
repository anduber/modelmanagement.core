using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class ContactInformationMap : EntityTypeConfiguration<ContactInformation>
    {
        public ContactInformationMap()
        {
            #region Configuration
            this.HasKey(t => new {t.PersonId,t.ContactMechTypeId,t.ContactUrl});

            this.HasRequired(t => t.ContactMechTypeId_ContactMechType)
                .WithMany(t => t.ContactInformations)
                .HasForeignKey(t => t.ContactMechTypeId);

            this.HasRequired(t => t.PersonId_PersonalInformation)
                .WithMany(t => t.ContactInformations_PersonId)
                .HasForeignKey(t => t.PersonId);

            this.HasOptional(t => t.UserLoginId_UserLogin)
              .WithMany(t => t.ContactInformationUserLogin_PersonId)
              .HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Property
            this.Property(t => t.PersonId).HasColumnName("PERSON_ID");
            this.Property(t => t.ContactMechTypeId).HasColumnName("CONTACT_MECH_TYPE_ID");
            this.Property(t => t.ContactUrl).HasColumnName("CONTACT_URL");
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("contact_information");
        }
    }
}
