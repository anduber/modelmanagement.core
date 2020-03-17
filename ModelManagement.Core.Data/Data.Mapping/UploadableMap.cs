using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class UploadableMap : EntityTypeConfiguration<Uploadable>
    {
        public UploadableMap()
        {
            #region Configuration
            this.HasKey(t => t.FileUploadId);
            this.HasOptional(t => t.FileType_FileTypeId)
                .WithMany(t => t.Uploadables)
                .HasForeignKey(t => t.FileTypeId);
            this.HasOptional(t => t.PersonalInformation_PersonId)
                .WithMany(t => t.Uploadables_PersonId)
                .HasForeignKey(t => t.PersonId);
            this.HasOptional(t => t.UserLoginId_UserLogin)
              .WithMany(t => t.UploadableUserLogin_PersonId)
              .HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Property
            this.Property(t => t.FileUploadId).HasColumnName("FILE_UPLOAD_ID");
            this.Property(t => t.PersonId).HasColumnName("PERSON_ID");
            this.Property(t => t.FileTypeId).HasColumnName("FILETYPE_ID");
            this.Property(t => t.MimeTypeId).HasMaxLength(50).HasColumnName("MIME_TYPE_ID");
            this.Property(t => t.FileName).HasMaxLength(255).HasColumnName("FILE_NAME");
            this.Property(t => t.FileData).HasColumnName("FILE_DATA");
            this.Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("uploadable");
        }
    }
}
