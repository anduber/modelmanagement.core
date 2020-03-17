using System.Data.Entity.ModelConfiguration;
using ModelManagement.Core.Data.Data.Model;

namespace ModelManagement.Core.Data.Data.Mapping
{
    public class VisitMap : EntityTypeConfiguration<Visit>
    {
        public VisitMap()
        {
            HasKey(t => t.VisitId);
            HasOptional(t => t.Visitor_VisitorId).WithMany(t => t.VisitVisitor_VisitorId).HasForeignKey(t => t.VisitorId);

            Property(t => t.VisitId).HasColumnName("VISIT_ID");
            Property(t => t.VisitorId).HasColumnName("VISITOR_ID");
            Property(t => t.UserLoginId).HasColumnName("USER_LOGIN_ID");
            Property(t => t.CreatedStamp).HasColumnName("CREATED_STAMP");
            Property(t => t.LastUpdatedStamp).HasColumnName("LAST_UPDATED_STAMP");
            ToTable("visit");
        }
    }
}
