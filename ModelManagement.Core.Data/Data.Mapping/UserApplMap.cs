using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserApplMap : EntityTypeConfiguration<UserAppl>
    {
        public UserApplMap()
        {
            #region Configuration
            this.HasKey(t => new { t.UserId, t.OfferTypeId, t.FromDate });

            this.HasRequired(t => t.UserId_UserAppl)
                .WithMany(t => t.UserApplId_UserAppls)
                .HasForeignKey(t => t.UserId);

            this.HasRequired(t => t.OfferTypeId_OfferType)
                .WithMany(t => t.UserApplId_UserAppls)
                .HasForeignKey(t => t.OfferTypeId);

            this.HasOptional(t => t.UserLoginId_UserLogin)
              .WithMany(t => t.UserApplUserLogin_UserId)
              .HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Properties
            this.Property(t => t.UserId).HasColumnName("USER_ID");
            this.Property(t => t.OfferTypeId).HasColumnName("OFFER_TYPE_ID");
            this.Property(t => t.FromDate).HasColumnName("FROM_DATE");
            this.Property(t => t.ThruDate).HasColumnName("THRU_DATE");
            this.Property(t => t.Comment).HasMaxLength(255).HasColumnName("COMMENT");
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            #endregion

            this.ToTable("user_appl");


        }
    }
}
