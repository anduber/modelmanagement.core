using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class SystemConfigurationMap:EntityTypeConfiguration<SystemConfiguration>
    {
        public SystemConfigurationMap()
        {
            this.HasKey(t => t.SystemConfigurationId);

            #region Property
            this.Property(t => t.SystemConfigurationId).HasColumnName("SYSTEM_CONFIGURATION_ID");
            this.Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            this.Property(t => t.LongDescription).HasColumnName("LONG_DESCRIPTION");
            this.Property(t => t.ConfigurationValue).HasMaxLength(50).HasColumnName("CONFIGURATION_VALUE");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            #endregion
            this.ToTable("system_configuration");
        }
    }
}
