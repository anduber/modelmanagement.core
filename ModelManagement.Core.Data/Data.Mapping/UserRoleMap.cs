using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            this.HasKey(t => new { t.UserId, t.RoleTypeId });

            #region Configuration
            this.HasRequired(t => t.UserId_UserRole)
                    .WithMany(t => t.UserRoleId_UserRoles)
                    .HasForeignKey(t => t.UserId);

            this.HasRequired(t => t.RoleTypeId_UserRole)
                .WithMany(t => t.RoleTypeId_UserRoles)
                .HasForeignKey(t => t.RoleTypeId);

            this.HasOptional(t => t.UserLoginId_UserLogin)
             .WithMany(t => t.UserRoleUserLogin_UserLoginId)
             .HasForeignKey(t => t.UserLoginId); 
            #endregion

            #region Properties
            this.Property(t => t.UserId).HasColumnName("USER_ID");
            this.Property(t => t.RoleTypeId).HasColumnName("ROLETYPE_ID");
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");

            #endregion

            this.ToTable("user_role");
        }
    }
}
