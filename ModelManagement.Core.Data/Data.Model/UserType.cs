using System.Collections.Generic;

namespace ModelManagement.Core.Data.Data.Model
{
    public class UserType : Entity
    {
        public UserType()
        {
            UserType_UserTypeIds = new List<User>();
            UserType_UserMainTypeIds = new List<User>();
        }
        public string UserTypeId { get; set; }
        public string Description { get; set; }
        public virtual List<User> UserType_UserTypeIds { get; set; }
        public virtual List<User> UserType_UserMainTypeIds { get; set; }

    }
}
