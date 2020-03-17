using ModelManagement.Core.Business.Business.Helpers;
using ModelManagement.Core.Business.Business.Model.CommandModel;
using ModelManagement.Core.Business.Business.Model.Utils;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ModelManagement.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ModelManagementApiController : ApiController
    {
        private readonly ModelManagementApiService _apiService;

        public ModelManagementApiController()
        {
            _apiService = new ModelManagementApiService();
        }

        #region CommandApi
        [HttpPost, Route("cmd/{commandName}")]
        public CommandResult ExecuteCommand([FromBody]JObject commandObject, string commandName)
        {
            return RunCommand(commandObject, commandName);
        }

        private CommandResult RunCommand(JObject commandObject, string commandName)
        {
            var command = _apiService.GetCommand(commandObject, commandName);
            return command != null ? _apiService.InvokeCommand(command) : Utility.CommandError("Command not found!");
        }
        #endregion

        [HttpPost, Route("run/{queryName}")]
        public QueryResult ExecuteQuery([FromBody]JObject queryObject, string queryName)
        {
            return RunQuery(queryObject, queryName);
        }

        private QueryResult RunQuery(JObject queryObject, string queryName)
        {
            var query = _apiService.GetQuery(queryObject, queryName);
            return query != null ? _apiService.InvokeQuery(query) : Utility.QueryErrorResult("Query not found!");
        }


    }
}
