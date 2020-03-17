using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class FileTypeCommandModel
    {
        public string FileTypeId { get; set; }
        public string ParentFileTypeId { get; set; }
        public string Description { get; set; }
    }
}
