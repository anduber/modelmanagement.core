using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class FileType : Entity
    {
        public FileType()
        {
            Uploadables = new List<Uploadable>();
            FileType_Child = new List<FileType>();
        }
        public string FileTypeId { get; set; }
        public string ParentFileTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<Uploadable> Uploadables { get; set; }
        public virtual FileType FileType_ParentFileTypeId { get; set; }
        public virtual List<FileType> FileType_Child { get; set; }
    }
}
