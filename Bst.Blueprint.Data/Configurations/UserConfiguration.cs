using Bst.Blueprint.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bst.Blueprint.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(255).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Password).HasMaxLength(255).IsRequired();
        }
    }
}
