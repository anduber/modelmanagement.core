using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class ContentMap : EntityTypeConfiguration<Content>
    {
        public ContentMap()
        {
            HasKey(t => t.ContentId);
            HasOptional(t => t.ContentType_ContentTypeId)
                .WithMany(t => t.Contents)
                .HasForeignKey(t => t.ContentTypeId);
            HasOptional(t => t.User_ContentUserId)
                .WithMany(t => t.User_Contents)
                .HasForeignKey(t => t.ContentUserId);
            HasOptional(t => t.UserLoginId_UserLogin)
                .WithMany(t => t.UserLogin_Contents)
                .HasForeignKey(t => t.UserLoginId);
            //HasOptional(t => t.UserLoginId_LastUpdatedByUserLogin)
            //    .WithMany(t => t.UserLoginLastUpdatedBy_Contents)
            //    .HasForeignKey(t => t.LastUpdatedByUserLoginId);

            Property(t => t.ContentId).HasMaxLength(50).HasColumnName("CONTENT_ID");
            Property(t => t.ContentTypeId).HasMaxLength(50).HasColumnName("CONTENT_TYPE_ID");
            Property(t => t.ContentUserId).HasMaxLength(50).HasColumnName("CONTENT_USER_ID");
            Property(t => t.ContentName).HasColumnName("CONTENT_NAME");
            Property(t => t.ContentDescription).HasMaxLength(50).HasColumnName("CONTENT_DESCRIPTION");
            Property(t => t.LongDescription).HasColumnName("LONG_DESCRIPTION");
            Property(t => t.MimeTypeId).HasMaxLength(50).HasColumnName("MIME_TYPE_ID");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
           // Property(t => t.LastUpdatedByUserLoginId).HasMaxLength(50).HasColumnName("LAST_UPDATED_BY_USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");



            ToTable("content");
        }
    }
}