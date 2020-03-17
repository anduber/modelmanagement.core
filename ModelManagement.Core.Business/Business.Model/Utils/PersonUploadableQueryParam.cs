using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public class PersonUploadableQueryParam:QueryCommandBase
    {
        public string PersonId { get; set; }
        public string ParentFileTypeId { get; set; }
        public string FileTypeId { get; set; }
    }
}
