using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class WorkExperianceMap : EntityTypeConfiguration<WorkExperiance>
    {
        public WorkExperianceMap()
        {
            #region Configuration
            this.HasKey(t => t.WorkExperianceId);
            this.HasOptional(t => t.PersonalInformation)
               .WithMany(t => t.WorkExperiances)
               .HasForeignKey(t => t.PersonId);
            #endregion

            #region Property
            this.Property(t => t.WorkExperianceId).HasColumnName("WORK_EXPERIANCE_ID");
            this.Property(t => t.PersonId).HasColumnName("PERSON_ID");
            this.Property(t => t.FromDate).HasColumnName("FROM_DATE");
            this.Property(t => t.WorkExperianceInfo).HasColumnName("WORK_EXPERIANCE_INFO");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("work_experiance");
        }
    }
}
