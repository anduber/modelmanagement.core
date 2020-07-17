using System;
using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Visitor:Entity
    {
        public Visitor()
        {
            VisitVisitor_VisitorId = new List<Visit>();
        }
        public string VisitorId { get; set; }
        public string UserAgentTypeId { get; set; }
        public virtual UserAgentType UserAgentTypeId_UserAgentType { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        public virtual List<Visit> VisitVisitor_VisitorId { get; set; }

    }
}
