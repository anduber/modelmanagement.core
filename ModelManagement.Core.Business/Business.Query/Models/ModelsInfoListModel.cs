using System.Collections.Generic;
using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class ModelsInfoListModel
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePic { get; set; }
        public int Age { get; set; }
        public double? Height { get; set; }
        public string HeightUom { get; set; }
        public double? Weight { get; set; }
        public string WeightUom { get; set; }
    }

    public class GetModelsInfoListModel:EntityCount
    {
        public List<ModelsInfoListModel> ModelList { get; set; }
    }

    public class ModelListModel
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Sex { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public string Complexion { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }

    }
}
