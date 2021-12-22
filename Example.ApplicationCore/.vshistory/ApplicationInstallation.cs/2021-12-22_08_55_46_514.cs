using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddMediatRFunApplication
            (this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ConsoleWriteLineBehavior<,>));


            return services;
        }
    }
}
