using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class ContactMechTypeMap : EntityTypeConfiguration<ContactMechType>
    {
        public ContactMechTypeMap()
        {
            #region Configuration
            this.HasKey(t => t.ContactMechTypeId);
            #endregion

            #region Property
            this.Property(t => t.ContactMechTypeId).HasColumnName("CONTACT_MECH_TYPE_ID");
            this.Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            this.Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("contact_mech_type");
        }
    }
}
