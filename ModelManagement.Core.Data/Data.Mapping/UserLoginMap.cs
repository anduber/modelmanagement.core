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
    public class UserLoginMap : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginMap()
        {
            HasKey(t => new { t.UserLoginId });
            HasOptional(t => t.User_PersonId).WithMany(t => t.User_UserLogin).HasForeignKey(t => t.PersonId);

            Property(t => t.UserName)
                 .IsOptional()
                 .HasMaxLength(60)
                 .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                      new IndexAnnotation(
                                          new IndexAttribute("IX_UserName,1")
                                          {
                                              IsUnique = true
                                          }));

            #region Property
            Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.UserName).HasColumnName("USER_NAME");
            Property(t => t.FromDate).HasColumnName("FROM_DATE");
            Property(t => t.ThruDate).HasColumnName("THRU_DATE");
            Property(t => t.CurrentPassword).HasColumnName("CURRENT_PASSWORD");
            Property(t => t.PasswordHint).HasMaxLength(50).HasColumnName("PASSWORD_HINT");
            Property(t => t.RequirePasswordChange).HasMaxLength(1).HasColumnName("REQUIRE_PASSWORD_CHANGE");
            Property(t => t.HasLoggedOut).HasMaxLength(1).HasColumnName("HAS_LOGGED_OUT");
            Property(t => t.SuccessiveFailedLogins).HasColumnName("SUCCESSIVE_FAILED_LOGINS");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            ToTable("user_login");
        }
    }
}
