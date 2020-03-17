using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelManagement.Core.Data.Data.Context;

namespace Test.Core
{
    [TestClass]
    public class UnitTest1
    {
        private ModelManagementContext _context;

        [TestMethod]
        public void TestMethod1()
        {
            _context = new ModelManagementContext();
            _context.Database.Delete();
            _context.Database.CreateIfNotExists();
        }
    }
}
