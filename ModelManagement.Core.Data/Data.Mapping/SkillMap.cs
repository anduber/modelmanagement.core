using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class SkillMap : EntityTypeConfiguration<Skill>
    {
        public SkillMap()
        {
            #region Configuration
            this.HasKey(t => t.SkillId);
            this.HasOptional(t => t.PersonalInformation)
                .WithMany(t => t.Skills)
                .HasForeignKey(t => t.PersonId);
            HasOptional(t => t.SkillType)
                .WithMany(t => t.Skills)
                .HasForeignKey(t => t.SkillTypeId);
            #endregion

            #region Property
            Property(t => t.SkillId).HasColumnName("SKILL_ID");
            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.SkillInfo).HasColumnName("SKILL_INFO");
            Property(t => t.SkillTypeId).HasMaxLength(50).HasColumnName("SKILL_TYPE_ID");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            ToTable("skill");
        }
    }
}
