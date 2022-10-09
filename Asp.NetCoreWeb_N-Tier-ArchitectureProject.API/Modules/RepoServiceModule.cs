using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Caching;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.Repositories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.UnitofWorks;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Mapping;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks;
using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.API.Modules
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitofWork>().As<IUnitofWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDBContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                    .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

//            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();

        }
    }
}
