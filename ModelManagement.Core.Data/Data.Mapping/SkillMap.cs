using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class SkillMap : EntityTypeConfiguration<Skill>
    {
        public SkillMap()
        {
            #region Configuration
            HasKey(t => t.SkillId);
            HasOptional(t => t.PersonalInformation).WithMany(t => t.Skills).HasForeignKey(t => t.PersonId);
            HasOptional(t => t.SkillType).WithMany(t => t.Skills).HasForeignKey(t => t.SkillTypeId);
            HasOptional(t => t.SkillIdLevel_Enumeration).WithMany(t => t.Enumeration_SkillLevel).HasForeignKey(t => t.SkillLevelEnumId);
            #endregion

            #region Property
            Property(t => t.SkillId).HasColumnName("SKILL_ID");
            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.SkillLevelEnumId).HasColumnName("SKILL_LEVEL_ENUM_ID");
            Property(t => t.SkillInfo).HasMaxLength(255).HasColumnName("SKILL_INFO");
            Property(t => t.SkillTypeId).HasMaxLength(50).HasColumnName("SKILL_TYPE_ID");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            ToTable("skill");
        }
    }
}
