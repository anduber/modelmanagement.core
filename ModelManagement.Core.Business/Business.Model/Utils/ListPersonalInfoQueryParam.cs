using ModelManagement.Core.Business.Business.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public class ListPersonalInfoQueryParam : QueryCommandBase
    {
        public ListPersonalInfoQueryParam()
        {
            CategoryTypeIds = new List<string>();
        }
        public string FirstName { get; set; }
        public int AgeFrom { get; set; }
        public int ThruAge { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public double? HeightFrom { get; set; }
        public double? HeightThru { get; set; }
        public string HeightUom { get; set; }
        public string Complexion { get; set; }
        public string UserNumber { get; set; }
        public List<string> CategoryTypeIds { get; set; }
    }

    public class ListModelsQueryParam : QueryCommandBase
    {
        public int? AgeFrom { get; set; }
        public int? ThruAge { get; set; }
        public double? HeightFrom { get; set; }
        public double? HeightThru { get; set; }
        public string HeightEnumId { get; set; }
        public double? WeightFrom { get; set; }
        public double? WeightThru { get; set; }
        public string WeightEnumId { get; set; }
        public string CategoryTypeId { get; set; }
        public string Sex { get; set; }
        public string Complextion { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ListModelsQueryParamArg
    {
        public ListModelsQueryParamArg()
        {
            CategoryTypeIds = new List<string>();
        }
        public string Sex { get; set; }
        public string Complexion { get; set; }
        public double? HeightFrom { get; set; }
        public double? HeightThru { get; set; }
        public string CategoryTypeId { get; set; }
        public string CountryGeoId { get; set; }
        public string CityGeoId { get; set; }
        public List<string> CategoryTypeIds { get; set; }
        public double? WeightFrom { get; set; }
        public double? WeightThru { get; set; }
        public int AgeFrom { get; set; }
        public int ThruAge { get; set; }
    }
}
