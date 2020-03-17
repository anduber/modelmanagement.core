using ModelManagement.Core.Business.Business.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Query.Utils
{
    public class QueryList
    {
        public static IEnumerable<IQuery> ListAvailableQuery()
        {
            var type = typeof(IQuery);
            var queries = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => type.IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<IQuery>().ToList();
            return queries;
        }

        public static IQuery GetQuery(string queryName)
        {
            return ListAvailableQuery().FirstOrDefault(t => t.GetType().Name == queryName);
        }
    }
}
