using ModelManagement.Core.Business.Business.Model.QueryModel;
using ModelManagement.Core.Data.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
using ModelManagement.Core.Business.Business.Model.Utils;


namespace ModelManagement.Core.Business.Business.Query
{
    public class QueryAppService
    {
        private ModelManagementContext _context;

        public ModelManagementContext ModelManagementContext()
        {
            return _context ?? new ModelManagementContext();
        }


    }
}
