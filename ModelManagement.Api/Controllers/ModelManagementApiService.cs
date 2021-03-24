using ModelManagement.Core.Business.Business.Command.Utils;
using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Business.Business.Model.Utils;
using ModelManagement.Core.Business.Business.Query.EntityProfile;
using ModelManagement.Core.Business.Business.Query.Utils;
using ModelManagement.Core.Data.Data.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace ModelManagement.Api.Controllers
{
    public class ModelManagementApiService
    {

        private ModelManagementContext _context;
        public ModelManagementApiService()
        {
            _context = new ModelManagementContext();
        }

        static ModelManagementApiService()
        {
            BootStrapper.Start();
        }

        #region Command
        public CommandResult InvokeCommand(ICommand command)
        {
            try
            {
                return command.Execute();
            }
            catch (Exception e)
            {
                return Utility.CommandError(e.Message);
            }
            //return command.Execute();
        }

        public ICommand GetCommand(JObject commandObject, string commandName)
        {
            var command = CommandList.GetCommand(commandName).GetType();
            return (ICommand)JsonConvert.DeserializeObject(commandObject.ToString(), command);

        }
        #endregion

        #region Query
        public QueryResult InvokeQuery(IQuery query)
        {
            //try
            //{
            //    return query.Execute();
            //}
            //catch (Exception e)
            //{
            //    return Utility.QueryErrorResult(e.Message);
            //}
            return query.Execute();
        }

        public IQuery GetQuery(JObject queryObject, string queryName)
        {
            var query = QueryList.GetQuery(queryName).GetType();
            return (IQuery)JsonConvert.DeserializeObject(queryObject.ToString(), query);
        }
        #endregion
    }
}