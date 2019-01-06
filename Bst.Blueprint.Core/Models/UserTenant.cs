namespace Bst.Blueprint.Core.Models
{
    public class UserTenant : Entity
    {
        public int UserId { get; private set; }
        public User User { get; private set; }
        public int TenantId { get; private set; }
        public Tenant Tenant { get; private set; }
    }
}
