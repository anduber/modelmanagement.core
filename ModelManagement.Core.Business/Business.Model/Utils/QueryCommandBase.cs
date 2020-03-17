using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public class QueryCommandBase
    {
        public string SearchText { get; set; }
        public Pagination Pagination { get; set; }
        public QueryParamArg QueryParamArg { get; set; }

        public QueryCommandBase()
        {
            QueryParamArg = new QueryParamArg();
        }
    }
}
