using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            #endregion

            #region Property
            this.Property(t => t.SkillId).HasColumnName("SKILL_ID");
            this.Property(t => t.PersonId).HasColumnName("PERSON_ID");
            this.Property(t => t.SkillInfo).HasColumnName("SKILL_INFO");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("skill");
        }
    }
}
