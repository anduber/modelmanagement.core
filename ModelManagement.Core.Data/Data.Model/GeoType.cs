using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class GeoType:CommonEntity
    {
        public GeoType()
        {
            this.GeoId_Geos = new List<Geo>();
            this.GeoIdAssoc_GeoAssoc = new List<GeoAssoc>();
        }

        public string GeoTypeId { get; set; }
        public string Description { get; set; }
        public string GeoTypePurposeId { get; set; }
        public virtual List<Geo> GeoId_Geos { get; set; }
        public virtual List<GeoAssoc> GeoIdAssoc_GeoAssoc { get; set; }
        public virtual GeoType GeoTypePurposeId_GeoTypeParent { get; set; }
        public virtual List<GeoType> GeoTypeId_GeoTypeChild { get; set; }
    }
}
