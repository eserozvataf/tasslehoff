﻿// --------------------------------------------------------------------------
// <copyright file="Startup.cs" company="-">
//   Copyright (c) 2008-2019 Eser Ozvataf (eser@ozvataf.com). All rights reserved.
//   Licensed under the Apache-2.0 license. See LICENSE file in the project root
//   for full license information.
//
//   Web: http://eser.ozvataf.com/ GitHub: http://github.com/eserozvataf
// </copyright>
// <author>Eser Ozvataf (eser@ozvataf.com)</author>
// --------------------------------------------------------------------------

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Tassle.TestWebApi {
    public class Startup : DefaultWebApiStartup {
        // methods

        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServiceProvider(HostBuilderContext hostingContext, IServiceCollection services) {
            base.ConfigureServiceProvider(hostingContext, services);

            services.Configure<AppSettings>(hostingContext.Configuration.GetSection("AppSettings"));

            // register external services
            switch (hostingContext.HostingEnvironment.EnvironmentName) {
                case "Development":
                    services.AddTransient<IDummyExternalService, FakeDummyExternalService>();
                    break;
                case "Testing":
                case "Staging":
                case "Production":
                    services.AddTransient<IDummyExternalService, LiveDummyExternalService>();
                    break;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            base.Configure(app, env);
        }
    }
}
