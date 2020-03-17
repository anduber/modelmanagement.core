using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class PhysicalInformationMap : EntityTypeConfiguration<PhysicalInformation>
    {
        public PhysicalInformationMap()
        {
            #region Configuration
            this.HasKey(t => t.PersonId);
            this.HasOptional(t => t.UserLoginId_UserLogin)
              .WithMany(t => t.PhysicalInformationUserLogin_PersonId)
              .HasForeignKey(t => t.UserLoginId);
            this.HasOptional(t => t.HeightEnumId_Enumeration)
              .WithMany(t => t.HeightEnumId_PhysicalInformation)
              .HasForeignKey(t => t.HeightEnumId);
            this.HasOptional(t => t.WeightEnumId_Enumeration)
             .WithMany(t => t.WeightEnumId_PhysicalInformation)
             .HasForeignKey(t => t.WeightEnumId);
            #endregion

            #region Property
            this.Property(t => t.PersonId).HasColumnName("PERSON_ID");
            this.Property(t => t.Height).HasColumnName("HEIGHT");
            this.Property(t => t.HeightEnumId).HasColumnName("HEIGHT_ENUM_ID");
            this.Property(t => t.Weight).HasColumnName("WEIGHT");
            this.Property(t => t.WeightEnumId).HasColumnName("WEIGHT_ENUM_ID");
            this.Property(t => t.Complexion).HasMaxLength(50).HasColumnName("COMPLEXION");
            this.Property(t => t.HairColor).HasMaxLength(50).HasColumnName("HAIR_COLOR");
            this.Property(t => t.EyeColor).HasMaxLength(50).HasColumnName("EYE_COLOR");
            this.Property(t => t.Bust).HasColumnName("BUST");
            this.Property(t => t.Waist).HasColumnName("WAIST");
            this.Property(t => t.Hip).HasColumnName("HIP");
            this.Property(t => t.DressSize).HasMaxLength(50).HasColumnName("DRESS_SIZE");
            this.Property(t => t.ShoeSize).HasColumnName("SHOE_SIZE");
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
       
            #endregion

            this.ToTable("physical_information");
        }
    }
}
