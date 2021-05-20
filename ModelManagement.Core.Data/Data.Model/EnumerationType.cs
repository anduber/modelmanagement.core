using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class EnumerationType : Entity
    {
        public EnumerationType()
        {
            Enumerations = new List<Enumeration>();
        }
        public string EnumerationTypeId { get; set; }
        public string ParentTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<Enumeration> Enumerations { get; set; }
    }
}
