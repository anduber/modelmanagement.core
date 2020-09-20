using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class PhysicalInformationMap : EntityTypeConfiguration<PhysicalInformation>
    {
        public PhysicalInformationMap()
        {
            #region Configuration
            HasKey(t => t.PersonId);
            HasOptional(t => t.UserLoginId_UserLogin)
              .WithMany(t => t.PhysicalInformationUserLogin_PersonId)
              .HasForeignKey(t => t.UserLoginId);
            HasOptional(t => t.Complexion_Enumeration)
              .WithMany(t => t.Enumeration_Complexion)
              .HasForeignKey(t => t.Complexion);
            HasOptional(t => t.HairColor_Enumeration)
                .WithMany(t => t.Enumeration_HairColor)
                .HasForeignKey(t => t.HairColor);
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
