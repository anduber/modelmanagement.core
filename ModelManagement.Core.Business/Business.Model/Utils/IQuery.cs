using System;

namespace ModelManagement.Core.Business.Business.Model.Utils
{
    public interface IQuery
    {   
        QueryResult Execute();
    }

    public class QueryEntity
    {
        public string UserLoginId { get; set; }
        public EntityDescription UserLogin { get; set; }
        public DateTime? CreatedStamp { get; set; }
        public DateTime? LastUpdatedStamp { get; set; }
    }
}
