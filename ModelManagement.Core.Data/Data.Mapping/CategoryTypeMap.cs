using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class CategoryTypeMap : EntityTypeConfiguration<CategoryType>
    {
        public CategoryTypeMap()
        {
            #region Configuration
            HasKey(t => new { t.CategoryTypeId });
            HasOptional(t => t.CategoryType_ParentTypeId)
                .WithMany(t => t.CategoryType_Child)
                .HasForeignKey(t => t.ParentTypeId);
            #endregion

            #region Property
            Property(t => t.CategoryTypeId).HasMaxLength(50).HasColumnName("CATEGORY_TYPE_ID");
            Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            Property(t => t.ParentTypeId).HasColumnName("PARENT_TYPE_ID");
            Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("category_type");
        }
    }
}
