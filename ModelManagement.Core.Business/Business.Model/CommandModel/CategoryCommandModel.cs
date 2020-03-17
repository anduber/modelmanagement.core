using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Model.CommandModel
{

    public class CategoryCommandModel
    {
        public string PersonId { get; set; }
        public List<CategoryArgModel> CategoryArgs { get; set; }
    }
    public class CategoryArgModel
    {
        public string CategoryId { get; set; }
        public string CategoryTypeId { get; set; }
    }
}
