using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class ContentListModel
    {
        public string ContentId { get; set; }
        public string ContentTypeId { get; set; }
        public string ContentUserId { get; set; }
        public string ContentName { get; set; }
        public string ContentDescription { get; set; }
        public string LongDescription { get; set; }
        public string MimeTypeId { get; set; }
        public byte[] Data { get; set; }
    }

    public class ContentDataListModel
    {
        public string ContentId { get; set; }
        public byte[] Data { get; set; }
    }
}
