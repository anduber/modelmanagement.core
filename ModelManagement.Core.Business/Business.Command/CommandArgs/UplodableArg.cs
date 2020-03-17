﻿namespace ModelManagement.Core.Business.Business.Command.CommandArgs
{
    public class UplodableArg
    {
        public string FileUploadId { get; set; }
        public string FileTypeId { get; set; }
        public string MimeTypeId { get; set; }
        public byte[] File { get; set; }
    }
}
