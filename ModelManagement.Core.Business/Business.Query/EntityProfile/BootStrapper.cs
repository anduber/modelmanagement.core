using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelManagement.Core.Business.Business.Query.EntityProfile
{
    public class BootStrapper
    {
        public static void Start()
        {
            var profileType = typeof(BaseProfile);

            var profiles = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => profileType.IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<BaseProfile>();

            AutoMapper.Mapper.Initialize(a => profiles.ForEach(a.AddProfile));
        }
    }
}
