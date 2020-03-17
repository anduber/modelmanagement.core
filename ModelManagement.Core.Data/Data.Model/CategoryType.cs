using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Data.Data.Model
{
    public class CategoryType : CommonEntity
    {
        public CategoryType()
        {
            CategoryType_Categories = new List<Category>();
            CategoryType_Child = new List<CategoryType>();
        }

        public string CategoryTypeId { get; set; }
        public string ParentTypeId { get; set; }
        public string Description { get; set; }
        public virtual CategoryType CategoryType_ParentTypeId { get; set; }
        public virtual List<CategoryType> CategoryType_Child { get; set; }
        public virtual List<Category> CategoryType_Categories { get; set; }
    }
}
