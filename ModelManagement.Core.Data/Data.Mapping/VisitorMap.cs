using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class VisitorMap : EntityTypeConfiguration<Visitor>
    {
        public VisitorMap()
        {
            HasKey(t => t.VisitorId);
            HasOptional(t => t.UserLoginId_UserLogin).WithMany(t => t.VisitorUserLogin_PersonId).HasForeignKey(t => t.UserLoginId);
            HasOptional(t => t.UserAgentTypeId_UserAgentType).WithMany(t => t.VisitorUserAgentType_UserAgentTypeId).HasForeignKey(t => t.UserAgentTypeId);

            Property(t => t.UserAgentTypeId).HasColumnName("USER_AGENT_TYPE_ID");
            Property(t => t.VisitorId).HasColumnName("VISITOR_ID");
            Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            ToTable("visitor");
        }
    }
}
