using ModelManagement.Core.Data.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class GeoAssoc:CommonEntity
    {
        public string GeoId { get; set; }
        public string GeoIdTo { get; set; }
        public string GeoAssocTypeId { get; set; }
        public virtual Geo GeoId_Geo { get; set; }
        public virtual Geo GeoIdTo_Geo { get; set; }
        public virtual GeoType GeoAssocTypeId_GeoType { get; set; }


    }
}
