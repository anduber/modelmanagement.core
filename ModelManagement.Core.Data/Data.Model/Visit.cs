namespace ModelManagement.Core.Data.Data.Model
{
    public class Visit:Entity
    {
        public string VisitId { get; set; }
        public string VisitorId { get; set; }
        public virtual Visitor Visitor_VisitorId { get; set; }
    }
}
