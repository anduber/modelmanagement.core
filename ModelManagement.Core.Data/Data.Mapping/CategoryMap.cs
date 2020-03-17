using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            #region Configuration
            HasKey(t => new { t.PersonId, t.CategoryTypeId });
            HasRequired(t => t.CategoryTypeId_CategoryType).WithMany(t => t.CategoryType_Categories).HasForeignKey(t => t.CategoryTypeId);
            HasRequired(t => t.PersonId_PersonalInformation).WithMany(t => t.Categories_PersonId).HasForeignKey(t => t.PersonId);
            HasOptional(t => t.UserLoginId_UserLogin).WithMany(t => t.CategoryUserLogin_PersonId).HasForeignKey(t => t.UserLoginId);
            #endregion

            #region Propery
            Property(t => t.PersonId).HasColumnName("PERSON_ID");
            Property(t => t.CategoryTypeId).HasColumnName("CATEGORY_TYPE_ID");
            Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            #endregion

            ToTable("category");
        }
    }
}
