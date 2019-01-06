using Bst.Blueprint.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bst.Blueprint.Data.Configurations
{
    public class UserTenantConfiguration : IEntityTypeConfiguration<UserTenant>
    {
        public void Configure(EntityTypeBuilder<UserTenant> builder)
        {
            builder.HasKey(t => new { t.UserId, t.TenantId });
            builder.Ignore(t => t.Id);
        }
    }
}
