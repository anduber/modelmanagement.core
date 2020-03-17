using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class ModelingExperianceMap : EntityTypeConfiguration<ModelingExperiance>
    {
        public ModelingExperianceMap()
        {
            #region Configuration
            this.HasKey(t => t.ModelingExperianceId);
            this.HasOptional(t => t.PersonalInformation)
                .WithMany(t => t.ModelingExperiances)
                .HasForeignKey(t => t.PersonId);
            #endregion

            #region Property
            this.Property(t => t.ModelingExperianceId).HasColumnName("MODELING_EXPERIANCE_ID");
            this.Property(t => t.PersonId).HasColumnName("PERSON_ID");
            this.Property(t => t.ExperianceInfo).HasColumnName("EXPERIANCE_INFO");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("modeling_experiance");
        }
    }
}
