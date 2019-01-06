using System.Linq;
using System.Reflection;
using Bst.Blueprint.Core.Models;
using Bst.Blueprint.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Bst.Blueprint.Data.EntityFramework
{
    public class BlueprintContext : DbContext
    {
        public BlueprintContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEntityTypeConfiguration(typeof(UserConfiguration).Assembly);

            RegisterEntities(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterEntities(ModelBuilder modelBuilder)
        {
            MethodInfo entityMethod = typeof(ModelBuilder).GetMethods().First(m => m.Name == "Entity" && m.IsGenericMethod);

            var entityTypes = Assembly.GetAssembly(typeof(User)).GetTypes()
                .Where(x => x.IsSubclassOf(typeof(Entity)) && !x.IsAbstract);

            foreach (var type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
