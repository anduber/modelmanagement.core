using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{
    public class CommandResult
    {
        public object Data { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

    }
}
