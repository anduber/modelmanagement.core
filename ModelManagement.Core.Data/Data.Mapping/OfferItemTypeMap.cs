using ModelManagement.Core.Data.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class OfferItemTypeMap : EntityTypeConfiguration<OfferItemType>
    {
        public OfferItemTypeMap()
        {
            HasKey(t => t.OfferItemTypeId);
            HasOptional(t => t.UserLoginId_UserLogin).WithMany(t => t.OfferItemTypeUserLogin_UserLoginId).HasForeignKey(t => t.UserLoginId);
            Property(t => t.OfferItemTypeId).HasColumnName("OFFER_ITEM_TYPE_ID");
            Property(t => t.Sequence).HasMaxLength(50).HasColumnName("SEQUENCE");
            Property(t => t.Description).HasMaxLength(128).HasColumnName("DESCRIPTION");
            Property(t => t.IsActive).HasMaxLength(128).HasColumnName("IS_ACTIVE");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("offer_item_type");
        }
    }
}
