using CM3070.DbRepositoryCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CM3070_API.DependencyResolution
{
    public class Services : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IRepositoryCore, RepositoryCore>();
        }
    }
}
