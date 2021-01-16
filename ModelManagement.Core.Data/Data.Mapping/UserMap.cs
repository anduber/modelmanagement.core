using ModelManagement.Core.Data.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            #region Configuration
            HasKey(t => new { t.PersonId });
            HasOptional(t => t.PersonId_PersonalInformation).WithRequired(s => s.PersonId_User).WillCascadeOnDelete(false);
            HasOptional(t => t.StatusId_StatusItem).WithMany(t => t.UserId_Users).HasForeignKey(t => t.StatusId);
            HasOptional(t => t.UserTypeId_UserType)
                .WithMany(t => t.UserType_UserTypeIds)
                .HasForeignKey(t => t.UserTypeId);
            HasOptional(t => t.UserMainTypeId_UserType)
                .WithMany(t => t.UserType_UserMainTypeIds)
                .HasForeignKey(t => t.UserMainTypeId);


            #endregion

            #region Property
            Property(t => t.PersonId)
                    .IsRequired()
                    .HasMaxLength(50);
            Property(t => t.UserNumber)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_UserNumber,1")
                        {
                            IsUnique = true
                        }));
            Property(t => t.PrimaryEmail)
                .IsOptional()
                .HasMaxLength(60)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Email,1")
                        {
                            IsUnique = true
                        }));


            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.UserNumber).HasColumnName("USER_NUMBER");
            Property(t => t.UserMainTypeId).HasMaxLength(50).HasColumnName("USER_MAIN_TYPEID");
            Property(t => t.UserTypeId).HasMaxLength(50).HasColumnName("USER_TYPE_ID");
            //this.Property(t => t.Password).HasColumnName("PASSWORD");
            Property(t => t.PrimaryEmail).HasMaxLength(100).HasColumnName("PRIMARY_EMAIL");
            Property(t => t.StatusId).HasColumnName("STATUS_ID");
            Property(t => t.PrimaryPhoneNumber).HasMaxLength(50).HasColumnName("PRIMARY_PHONE_NUMBER");
            Property(t => t.Description).HasMaxLength(255).HasColumnName("DESCRIPTION");
            //Property(t => t.PasswordHint).HasMaxLength(20).HasColumnName("PASSWORD_HINT");
            //Property(t => t.RequirePasswordChange).HasMaxLength(1).HasColumnName("REQUIRE_PASSWORD_CHANGE");
            Property(t => t.IsUserActivated).HasMaxLength(1).HasColumnName("IS_USER_ACTIVATED");
            Property(t => t.VerificationCode).HasMaxLength(50).HasColumnName("VERIFICATION_CODE");
            Property(t => t.TaxId).HasMaxLength(50).HasColumnName("TAX_ID");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            #endregion

            ToTable("user");
        }
    }
}
