using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class ContentType:Entity
    {
        public ContentType()
        {
            Contents = new List<Content>();
            ContentType_ChildId = new List<ContentType>();
        }
        public string ContentTypeId { get; set; }
        public string ParentTypeId { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; } = "Y";
        public virtual ContentType ContentType_ParentId { get; set; }
        public virtual List<ContentType> ContentType_ChildId { get; set; }
        public List<Content> Contents { get; set; }

    }
}
