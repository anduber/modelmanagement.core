using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class GeoMap : EntityTypeConfiguration<Geo>
    {
        public GeoMap()
        {
            #region Configuration
            this.HasKey(t => t.GeoId);

            this.HasOptional(t => t.GeoTypeId_GeoType)
                .WithMany(t => t.GeoId_Geos)
                .HasForeignKey(t => t.GeoTypeId); 
            #endregion

            #region Property
            this.Property(t => t.GeoId).HasColumnName("GEO_ID");
            this.Property(t => t.GeoTypeId).HasColumnName("GEO_TYPE_ID");
            this.Property(t => t.GeoName).HasMaxLength(100).HasColumnName("GEO_NAME");
            this.Property(t => t.GeoCode).HasMaxLength(50).HasColumnName("GEO_CODE");
            this.Property(t => t.DialingCode).HasMaxLength(50).HasColumnName("DIALING_CODE");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("geo");
        }
    }
}
