using Autofac;
using Dukkantek.Repo.Data;
using System.Reflection;

namespace Dukkantek.Repo.Autofact
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IAppRepository>())
            .AsImplementedInterfaces().AsSelf();
        }
    }
}
