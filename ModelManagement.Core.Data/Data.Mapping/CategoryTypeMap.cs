using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class CategoryTypeMap : EntityTypeConfiguration<CategoryType>
    {
        public CategoryTypeMap()
        {
            #region Configuration
            this.HasKey(t => t.CategoryTypeId);
            HasOptional(t => t.CategoryType_ParentTypeId)
                .WithMany(t => t.CategoryType_Child)
                .HasForeignKey(t => t.ParentTypeId);
            #endregion

            #region Property
            this.Property(t => t.CategoryTypeId).HasMaxLength(50).HasColumnName("CATEGORY_TYPE_ID");
            this.Property(t => t.Description).HasMaxLength(50).HasColumnName("DESCRIPTION");
            this.Property(t => t.ParentTypeId).HasColumnName("PARENT_TYPE_ID");
            this.Property(t => t.IsActive).HasMaxLength(1).HasColumnName("IS_ACTIVE");
            this.Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            this.Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            this.Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            #endregion

            this.ToTable("category_type");
        }
    }
}
