using System;

namespace ModelManagement.Core.Data.Data.Model
{
    public class Entity
    {
        public Entity()
        {
            CreatedStamp = DateTime.Now;
            LastUpdatedStamp = DateTime.Now;
        }
        public string UserLoginId { get; set; }
       // public string LastUpdatedByUserLoginId { get; set; }
        public DateTime? CreatedStamp { get; set; }
        public DateTime? LastUpdatedStamp { get; set; }
    }
}
