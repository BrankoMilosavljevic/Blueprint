using Bst.Blueprint.Core.Models;

namespace Bst.Blueprint.Api.Models
{
    public class TenantModel : BaseModel
    {
        public string Name { get; set; }

        public TenantModel(Tenant tenant)
        {
            Id = tenant.Id;
            Name = tenant.Name;
        }
    }
}
