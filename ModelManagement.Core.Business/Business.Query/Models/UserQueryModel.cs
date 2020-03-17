using ModelManagement.Core.Business.Business.Model.Utils;

namespace ModelManagement.Core.Business.Business.Query.Models
{
    public class UserQueryModel
    {
        public string PersonId { get; set; }
        public string UserNumber { get; set; }
        public string RoleTypeId { get; set; }
        public EntityDescription RoleType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string StatusId { get; set; }
        public EntityDescription Status { get; set; }
    }
}
