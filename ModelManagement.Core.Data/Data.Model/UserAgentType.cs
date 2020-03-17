using System;
using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserAgentType:CommonEntity
    {
        public UserAgentType()
        {
            VisitorUserAgentType_UserAgentTypeId = new List<Visitor>();
        }
        public string UserAgentTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<Visitor> VisitorUserAgentType_UserAgentTypeId  { get; set; }
    }
}
