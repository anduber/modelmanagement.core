using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class ContentTypeMap: EntityTypeConfiguration<ContentType>
    {
        public ContentTypeMap()
        {
            HasKey(t => t.ContentTypeId);
            HasOptional(t => t.ContentType_ParentId)
                .WithMany(t => t.ContentType_ChildId)
                .HasForeignKey(t => t.ParentTypeId);

            Property(t => t.ContentTypeId).HasMaxLength(50).HasColumnName("CONTENT_TYPE_ID");
            Property(t => t.ParentTypeId).HasMaxLength(50).HasColumnName("PARENT_TYPE_ID");
            Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
           // Property(t => t.LastUpdatedByUserLoginId).HasMaxLength(50).HasColumnName("LAST_UPDATED_BY_USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("content_type");
        }
    }
}
