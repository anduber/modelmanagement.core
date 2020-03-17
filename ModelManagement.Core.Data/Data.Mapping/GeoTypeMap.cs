using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class GeoTypeMap : EntityTypeConfiguration<GeoType>
    {
        public GeoTypeMap()
        {
            #region Configuration
            this.HasKey(t => t.GeoTypeId);

            this.HasOptional(t => t.GeoTypePurposeId_GeoTypeParent)
                .WithMany(t => t.GeoTypeId_GeoTypeChild)
                .HasForeignKey(t => t.GeoTypePurposeId);

            #endregion

            #region Property
            this.Property(t => t.GeoTypeId).HasColumnName("GEO_TYPE_ID");
            this.Property(t => t.GeoTypePurposeId).HasColumnName("GEO_TYPE_PURPOSE_ID");
            this.Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("geo_type");
        }
    }
}
