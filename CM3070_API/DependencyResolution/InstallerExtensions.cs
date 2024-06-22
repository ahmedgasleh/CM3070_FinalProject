using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CM3070_API.DependencyResolution
{
    public static class InstallerExtensions
    {
        public static void InstallServiceAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(WebApplication).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) &&
           !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installer => installer.InstallerServices(services, configuration));

        }
    }
}
