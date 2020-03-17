using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserLoginPasswordHistoryMap : EntityTypeConfiguration<UserLoginPasswordHistory>
    {
        public UserLoginPasswordHistoryMap()
        {
            this.HasKey(t => new { t.UserLoginId, t.FromDate });
            this.HasRequired(t => t.UserLoginId_UserLogin)
                .WithMany(t => t.UserLoginPasswordHistory_UserLoginId)
                .HasForeignKey(t => t.UserLoginId);

            #region Proprty
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.FromDate).HasColumnName("FROM_DATE");
            this.Property(t => t.ThruDate).HasColumnName("THRU_DATE");
            this.Property(t => t.CurrentPassword).HasColumnName("CURRENT_PASSWORD");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("user_login_password_history");
        }
    }
}
