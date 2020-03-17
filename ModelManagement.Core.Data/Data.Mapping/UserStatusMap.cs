using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserStatusMap : EntityTypeConfiguration<UserStatus>
    {
        public UserStatusMap()
        {
            this.HasKey(t => t.UserStatusId);

            #region Configuration
            this.HasOptional(t => t.UserStatus_UserId)
                    .WithMany(t => t.UserStatusId_UserStatuses)
                    .HasForeignKey(t => t.UserId);

            this.HasOptional(t => t.StatusId_UserStatsuTypes)
                .WithMany(t => t.UserStatusId_UserStatuses)
                .HasForeignKey(t => t.StatusId); 
            #endregion

            #region Property
            this.Property(t => t.UserStatusId).HasColumnName("USER_STATUS_ID");
            this.Property(t => t.UserId).HasColumnName("USER_ID");
            this.Property(t => t.StatusId).HasColumnName("STATUS_ID");
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("user_status");
        }
    }
}
