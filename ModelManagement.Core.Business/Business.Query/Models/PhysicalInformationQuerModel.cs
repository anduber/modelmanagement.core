using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class PhysicalInformationEditModel
    {
        public string PersonId { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string HairColor { get; set; }
        public EntityDescription HairColorDesc { get; set; }
        public string Complexion { get; set; }
        public EntityDescription ComplexionDesc { get; set; }
        public string EyeColor { get; set; }
        public double? Bust { get; set; }
        public double? Waist { get; set; }
        public double? Hip { get; set; }
        public string DressSize { get; set; }
        public double? ShoeSize { get; set; }
    }
}
