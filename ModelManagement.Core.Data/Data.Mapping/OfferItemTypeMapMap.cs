using System.Data.Entity.ModelConfiguration;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class OfferItemTypeMapMap : EntityTypeConfiguration<ModelManagement.Core.Data.Data.Model.OfferItemTypeMap>
    {
        public OfferItemTypeMapMap()
        {
            HasKey(t => new { t.OfferTypeId, t.OfferItemTypeId, });

            HasRequired(t => t.OfferItemTypeId_OfferItemType).WithMany(t => t.OfferItemTypeId_OfferType).HasForeignKey(t => t.OfferItemTypeId);
            HasRequired(t => t.OfferTypeId_OfferType).WithMany(t => t.OfferTypeId_OfferType).HasForeignKey(t => t.OfferTypeId);
            HasOptional(t => t.UserLoginId_UserLogin).WithMany(t => t.OfferItemTypeMapUserLogin_UserLoginId).HasForeignKey(t => t.UserLoginId);

            Property(t => t.OfferTypeId).HasColumnName("OFFER_TYPE_ID");
            Property(t => t.OfferItemTypeId).HasColumnName("OFFER_ITEM_TYPE_ID");
            Property(t => t.UserLoginId).HasMaxLength(50).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");

            ToTable("offer_item_type_map");
        }
    }
}
