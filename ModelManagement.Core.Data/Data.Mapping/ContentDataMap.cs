using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class ContentDataMap: EntityTypeConfiguration<ContentData>
    {
        public ContentDataMap()
        {
            HasKey(t => t.ContentId);

            Property(t => t.ContentId).HasMaxLength(50).HasColumnName("CONTENT_ID");
            Property(t => t.Data).HasColumnName("DATA");

            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            //Property(t => t.LastUpdatedByUserLoginId).HasMaxLength(50).HasColumnName("LAST_UPDATED_BY_USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            ToTable("content_data");
        }
    }
}
