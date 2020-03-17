namespace ModelManagement.Core.Business.Business.Command.CommandArgs
{
    public class CommonDataArgs
    {
    }

    public class GeoTypeArg
    {
        public string GeoTypeId { get; set; }
        public string Description { get; set; }
        public string GeoTypePurposeId { get; set; }
    }

    public class GeoArg
    {
        public string GeoId { get; set; }
        public string GeoTypeId { get; set; }
        public string GeoName { get; set; }
        public string GeoCode { get; set; }
        public string DialingCode { get; set; }
    }

    public class GeoAssocArg
    {
        public string GeoId { get; set; }
        public string GeoIdTo { get; set; }
        public string GeoAssocTypeId { get; set; }
    }

    public class GeoTypeImp
    {
        public string GEO_TYPE_ID { get; set; }
        public string DESCRIPTION { get; set; }
    }

    public class GeoImport
    {
        public string GEO_ID { get; set; }
        public string GEO_TYPE_ID { get; set; }
        public string GEO_NAME { get; set; }
        public string GEO_CODE { get; set; }
        public string DIALING_CODE { get; set; }
    }

    public class GeoAssocImport
    {
        public string GEO_ID { get; set; }
        public string GEO_ID_TO { get; set; }
        public string GEO_ASSOC_TYPE_ID { get; set; }
    }
}
