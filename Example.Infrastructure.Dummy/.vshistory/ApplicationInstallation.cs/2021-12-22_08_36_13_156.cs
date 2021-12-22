using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infrastructure.Dummy
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection
            AddMediatRInfrastructureDummy(this IServiceCollection services)
        {
            services.AddSingleton<IPostRepository, PostDummyRepository>();

            return services;
        }
    }
}
