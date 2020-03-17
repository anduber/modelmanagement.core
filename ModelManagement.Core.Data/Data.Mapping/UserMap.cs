using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            #region Configuration
            HasKey(t => new { t.PersonId });
            HasOptional(t => t.PersonalInformation).WithRequired(s => s.PersonId_User).WillCascadeOnDelete(false);
            HasOptional(t => t.StatusId_StatusItem).WithMany(t => t.UserId_Users).HasForeignKey(t => t.StatusId);

            #endregion

            #region Property
            this.Property(t => t.PersonId)
                    .IsRequired()
                    .HasMaxLength(50);
            this.Property(t => t.UserNumber)
                 .IsRequired()
                 .HasMaxLength(60)
                 .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                      new IndexAnnotation(
                                          new IndexAttribute("IX_UserNumber,1")
                                          {
                                              IsUnique = true
                                          }));

            this.Property(t => t.UserName)
                 .IsRequired()
                 .HasMaxLength(60)
                 .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                      new IndexAnnotation(
                                          new IndexAttribute("IX_UserName,1")
                                          {
                                              IsUnique = true
                                          }));

            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.UserNumber).HasColumnName("USER_NUMBER");
            //this.Property(t => t.RoleTypeId).HasColumnName("ROLE_TYPE_ID");
            Property(t => t.UserName).HasColumnName("USER_NAME");
            //this.Property(t => t.Password).HasColumnName("PASSWORD");
            Property(t => t.PrimaryEmail).HasMaxLength(100).HasColumnName("PRIMARY_EMAIL");
            Property(t => t.StatusId).HasColumnName("STATUS_ID");
            Property(t => t.PrimaryPhoneNumber).HasMaxLength(50).HasColumnName("PRIMARY_PHONE_NUMBER");
            Property(t => t.Description).HasMaxLength(255).HasColumnName("DESCRIPTION");
            //Property(t => t.PasswordHint).HasMaxLength(20).HasColumnName("PASSWORD_HINT");
            //Property(t => t.RequirePasswordChange).HasMaxLength(1).HasColumnName("REQUIRE_PASSWORD_CHANGE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            #endregion

            this.ToTable("user");
        }
    }
}
