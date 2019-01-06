using System.Collections.Generic;
using System.Linq;
using Bst.Blueprint.Core.Models;

namespace Bst.Blueprint.Api.Models
{
    public class UserModel : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<TenantModel> Tenants { get; set; }

        public UserModel(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Tenants = user.Tenants.Select(t => new TenantModel(t.Tenant));
        }
    }
}
