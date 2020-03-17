using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class PhysicalInformation : CommonEntity
    {
        public string PersonId { get; set; }
        public Nullable<double> Height { get; set; }
        public string HeightEnumId { get; set; }
        public Nullable<double> Weight { get; set; }
        public string WeightEnumId { get; set; }
        public string Complexion { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public Nullable<double> Bust { get; set; }
        public Nullable<double> Waist { get; set; }
        public Nullable<double> Hip { get; set; }
        public string DressSize { get; set; }
        public Nullable<double> ShoeSize { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        public virtual Enumeration HeightEnumId_Enumeration { get; set; }
        public virtual Enumeration WeightEnumId_Enumeration { get; set; }
    }
}
