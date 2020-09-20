using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class PhysicalInformation : Entity
    {
        public string PersonId { get; set; }
        public double? Height { get; set; }
        public string HeightEnumId { get; set; }
        public double? Weight { get; set; }
        public string WeightEnumId { get; set; }
        public double? BmI { get; set; }
        public string Complexion { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public double? Bust { get; set; }
        public double? Waist { get; set; }
        public double? Hip { get; set; }
        public string DressSize { get; set; }
        public double? ShoeSize { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
        public virtual UserLogin UserLoginId_UserLogin { get; set; }
        public virtual Enumeration Complexion_Enumeration { get; set; }
        public virtual Enumeration HairColor_Enumeration { get; set; }
    }
}
