using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserTypeMap : EntityTypeConfiguration<UserType>
    {
        public UserTypeMap()
        {
            #region Configuration
            HasKey(t => t.UserTypeId);
            //this.HasOptional(t => t.UserLoginId_UserLogin)
            //  .WithMany(t => t.OfferTypeUserLogin_UserLoginId)
            //  .HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Property
            Property(t => t.UserTypeId).HasColumnName("USER_TYPE_ID");
            //this.Property(t => t.Sequence).HasMaxLength(50).HasColumnName("SEQUENCE");
            Property(t => t.Description).HasMaxLength(100).HasColumnName("DESCRIPTION");
            //this.Property(t => t.LongDescription).HasColumnName("LONG_DESCRIPTION");
            //this.Property(t => t.ValidNoOfDays).HasColumnName("VALID_NO_OF_DAYS");
            //this.Property(t => t.FeeAmount).HasColumnName("FEE_AMOUNT");
            Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("user_type");
        }
    }
}
