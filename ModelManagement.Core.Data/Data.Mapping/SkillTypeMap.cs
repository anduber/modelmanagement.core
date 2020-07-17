using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class SkillTypeMap: EntityTypeConfiguration<SkillType>
    {
        public SkillTypeMap()
        {
            HasKey(t => t.SkillTypeId);

            Property(t => t.SkillTypeId).HasMaxLength(50).HasColumnName("SKILL_TYPE_ID");
            Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("skill_type");
        }
    }
}
