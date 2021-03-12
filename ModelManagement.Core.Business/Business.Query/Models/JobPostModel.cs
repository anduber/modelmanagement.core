namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class JobPostQueryParamArg
    {
        public decimal? PaymentAmount { get; set; }
        public decimal? HeightFrom { get; set; }
        public decimal? HeightThru { get; set; }
        public decimal? AgeFrom { get; set; }
        public decimal? AgeThru { get; set; }
        public string JobLocation { get; set; }
        public string Sex { get; set; }
        public string Complexion { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public double? Bust { get; set; }
        public double? Waist { get; set; }
        public double? Hip { get; set; }
        public string DressSize { get; set; }
        public double? ShoeSize { get; set; }
    }
}
