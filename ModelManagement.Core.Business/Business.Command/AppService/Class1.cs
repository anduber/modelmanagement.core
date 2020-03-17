using ModelManagement.Core.Business.Business.Command.EntityRepositories;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Data.Data.Context;

namespace ModelManagement.Core.Business.Business.Command.AppService
{
    public class Class1 : AppRepository
    {
        public Class1(ModelManagementContext context)
        {
            Context = context;
        }
        public CommandResult RemoveGeoType(string geoId)
        {
            var re = GeoType().Find(geoId);
            GeoType().Remove(re);
            return Utility.CommandSuccess();
        }
    }
}
