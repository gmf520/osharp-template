﻿// -----------------------------------------------------------------------
//  <copyright file="Startup.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:50</last-date>
// -----------------------------------------------------------------------

using OSharp.Template.Web.Startups;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
#if !NETCOREAPP2_2
using Microsoft.Extensions.Hosting;
#endif
using Microsoft.Extensions.Logging;

using OSharp.AspNetCore;
using OSharp.AspNetCore.Http;
using OSharp.Core.Builders;
using OSharp.Core.Options;
using OSharp.Entity;


namespace OSharp.Template.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOSharp<AspOsharpPackManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#if !NETCOREAPP2_2
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)

#else
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)

#endif
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/#/500");
                app.UseHsts().UseHttpsRedirection();
            }

            app
                //.UseMiddleware<HostHttpCryptoMiddleware>()
                //.UseMiddleware<NodeNoFoundHandlerMiddleware>()
                .UseMiddleware<NodeExceptionHandlerMiddleware>()
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseOSharp();
        }
    }
}