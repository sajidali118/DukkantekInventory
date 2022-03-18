using Autofac;
using Dukkantek.Repo.Autofact;
using Dukkantek.Repo.SharedKernal;

namespace DTA.Application.Autofact
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetAssembly(typeof(AppService))).AsSelf();
            builder.RegisterModule<RepositoryModule>();
        }
    }

}
