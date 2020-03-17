using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelManagement.Core.Business.Business.Service;

namespace ModelManagement.Business.Test
{
    [TestClass]
    public class CommonDataQueryTest
    {
        private ModelManagementQueryServices _queryService;
        [TestInitialize]
        public void SetUp()
        {
            this._queryService = new ModelManagementQueryServices();
        }

        
    }
}
