using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class RoleTypeMap : EntityTypeConfiguration<RoleType>
    {
        public RoleTypeMap()
        {
            #region Configuration
            HasKey(t => t.RoleTypeId);
            HasOptional(t=>t.RoleType_InitialStatusId).WithMany(t=>t.StatusItem_RoleTypes).HasForeignKey(k=>k.InitialStatusId);
            #endregion

            #region Property
            Property(t => t.RoleTypeId).HasColumnName("ROLETYPE_ID");
            Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            Property(t => t.InitialStatusId).HasMaxLength(50).HasColumnName("INITIAL_STATUS_ID");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("role_type");
        }
    }
}
