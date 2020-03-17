using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public class QueryParamArg
    {
        private string _searchText;

        public string SearchText
        {
            get { return _searchText = _searchText?.ToLower(); }
            set { _searchText = value; }
        }

        public string SortingColumnName { get; set; }
        public string SortDirection { get; set; }
        public bool ShowEntityCount { get; set; }
        public Pagination Pagination { get; set; }
    }
}
