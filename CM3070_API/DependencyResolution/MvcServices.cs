﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CM3070_API.DependencyResolution
{
    public class MvcServices : IInstaller
    {
        

        public void InstallerServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(setupAction: options => { options.EnableEndpointRouting = false; }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "TeleMED Validator API", Version = "v1" });

            });
        }

    }
}
