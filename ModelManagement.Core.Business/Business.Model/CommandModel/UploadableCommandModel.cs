using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class UploadableCommandModel
    {
        public string FileUploadId { get; set; }
        public string PersonId { get; set; }
        public string FileTypeId { get; set; }
        public string FilePath { get; set; }
        public string UserLoginId { get; set; }

    }
}
