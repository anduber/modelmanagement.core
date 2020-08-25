using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

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
            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.Height).HasColumnName("HEIGHT");
            Property(t => t.HeightEnumId).HasColumnName("HEIGHT_ENUM_ID");
            Property(t => t.Weight).HasColumnName("WEIGHT");
            Property(t => t.WeightEnumId).HasColumnName("WEIGHT_ENUM_ID");
            Property(t => t.Complexion).HasMaxLength(50).HasColumnName("COMPLEXION");
            Property(t => t.HairColor).HasMaxLength(50).HasColumnName("HAIR_COLOR");
            Property(t => t.EyeColor).HasMaxLength(50).HasColumnName("EYE_COLOR");
            Property(t => t.Bust).HasColumnName("BUST");
            Property(t => t.BmI).HasColumnName("BMI");
            Property(t => t.Waist).HasColumnName("WAIST");
            Property(t => t.Hip).HasColumnName("HIP");
            Property(t => t.DressSize).HasMaxLength(50).HasColumnName("DRESS_SIZE");
            Property(t => t.ShoeSize).HasColumnName("SHOE_SIZE");
            Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
       
            #endregion

            this.ToTable("physical_information");
        }
    }
}
