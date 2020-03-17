using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class PhysicalInformationCommandModel
    {
        public string PersonId { get; set; }
        public Nullable<double> Height { get; set; }
        public string HeightEnumId { get; set; }
        public string WeightEnumId { get; set; }
        public Nullable<double> Weight { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public Nullable<double> Bust { get; set; }
        public Nullable<double> Waist { get; set; }
        public Nullable<double> Hip { get; set; }
        public string DressSize { get; set; }
        public Nullable<double> ShoeSize { get; set; }
        public string UserLoginId { get; set; }
    }
}
