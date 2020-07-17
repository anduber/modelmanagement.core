using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class StatusType : Entity
    {
        public StatusType()
        {
            StatusType_StatusItems = new List<StatusItem>();
        }
        public string StatusTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<StatusItem> StatusType_StatusItems { get; set; }

    }
}
