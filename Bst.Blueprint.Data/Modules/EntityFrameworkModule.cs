using System;
using System.Linq;
using Autofac;
using Bst.Blueprint.Core.Policies.Data;
using Bst.Blueprint.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Bst.Blueprint.Data.Modules
{
    public class EntityFrameworkModule : Module
    {
        public DbContextOptions DbContextOptions { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.RegisterGeneric(typeof(EntityFrameworkRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly)
                .Where(
                    type =>
                        ImplementsInterface(typeof(IRepository<>), type) ||
                        type.Name.EndsWith("Repository")
                ).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.Register(c => DbContextOptions).As<DbContextOptions>().InstancePerLifetimeScope();
            builder.RegisterType<BlueprintContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DbContextUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }

        private static bool ImplementsInterface(Type interfaceType, Type concreteType)
        {
            return
                concreteType.GetInterfaces().Any(
                    t =>
                        (interfaceType.IsGenericTypeDefinition && t.IsGenericType
                            ? t.GetGenericTypeDefinition()
                            : t) == interfaceType);
        }
    }
}