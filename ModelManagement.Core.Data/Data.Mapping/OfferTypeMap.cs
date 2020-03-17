using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class OfferTypeMap : EntityTypeConfiguration<OfferType>
    {
        public OfferTypeMap()
        {
            #region Configuration
            HasKey(t => t.OfferTypeId);
            HasOptional(t => t.UserLoginId_UserLogin).WithMany(t => t.OfferTypeUserLogin_UserLoginId).HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Property
            Property(t => t.OfferTypeId).HasColumnName("OFFER_TYPE_ID");
            Property(t => t.Sequence).HasMaxLength(50).HasColumnName("SEQUENCE");
            Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            Property(t => t.LongDescription).HasColumnName("LONG_DESCRIPTION");
            Property(t => t.ValidNoOfDays).HasColumnName("VALID_NO_OF_DAYS");
            Property(t => t.FeeAmount).HasColumnName("FEE_AMOUNT");
            Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("offer_type");
        }
    }
}
