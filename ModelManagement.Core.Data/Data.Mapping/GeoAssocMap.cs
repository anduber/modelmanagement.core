using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class GeoAssocMap : EntityTypeConfiguration<GeoAssoc>
    {
        public GeoAssocMap()
        {
            #region Configuration
            this.HasKey(t => new { t.GeoId, t.GeoIdTo });

            this.HasRequired(t => t.GeoId_Geo)
                .WithMany(t => t.GeoId_GeoAssoc)
                .HasForeignKey(t => t.GeoId);

            this.HasRequired(t => t.GeoIdTo_Geo)
                .WithMany(t => t.GeoIdTo_GeoAssoc)
                .HasForeignKey(t => t.GeoIdTo);

            this.HasOptional(t => t.GeoAssocTypeId_GeoType)
                .WithMany(t => t.GeoIdAssoc_GeoAssoc)
                .HasForeignKey(t => t.GeoAssocTypeId); 
            #endregion

            #region Property
            this.Property(t => t.GeoId).HasColumnName("GEO_ID");
            this.Property(t => t.GeoIdTo).HasColumnName("GEO_ID_TO");
            this.Property(t => t.GeoAssocTypeId).HasColumnName("GEO_ASSOC_TYPE_ID");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            #endregion

            this.ToTable("geo_assoc");

        }
    }
}
