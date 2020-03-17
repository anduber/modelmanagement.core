using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class UserLoginCommandModel
    {
        public string UserLoginId { get; set; }
        public string PersonId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ThruDate { get; set; }
    }
}
