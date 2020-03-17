using System.Data.Entity.ModelConfiguration;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserAgentTypeMap: EntityTypeConfiguration<UserAgentType>
    {
        public UserAgentTypeMap()
        {
            HasKey(t => t.UserAgentTypeId);

            Property(t => t.UserAgentTypeId).HasColumnName("USER_AGENT_TYPE_ID");
            Property(t => t.Description).HasColumnName("DESCRIPTION");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            ToTable("user_agent_type");
        }
    }
}
