using Dukkantek.Repo.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Dukkantek.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Infa.Data.Layer
            services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

        }
    }
}
