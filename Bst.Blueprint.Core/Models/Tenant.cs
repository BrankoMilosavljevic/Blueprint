using System.Collections.Generic;

namespace Bst.Blueprint.Core.Models
{
    public class Tenant : Entity
    {
        public string Name { get; private set; }
        public ICollection<UserTenant> Users { get; private set; }

        public static Tenant Create(string name)
        {
            return new Tenant {Name = name};
        }
    }
}
