// -----------------------------------------------------------------------
//  <copyright file="Startup.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2020 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2020-06-02 14:35</last-date>
// -----------------------------------------------------------------------

using OSharp.Template.Web.Startups;

using OSharp.AspNetCore;
using OSharp.AspNetCore.Routing;
using OSharp.AutoMapper;
using OSharp.Hosting.Authorization;
using OSharp.Hosting.Identity;
using OSharp.Hosting.Infos;
using OSharp.Hosting.Systems;
using OSharp.Log4Net;
using OSharp.MiniProfiler;
using OSharp.Redis;
using OSharp.Swagger;


namespace OSharp.Template.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddOSharp()
                .AddPack<Log4NetPack>()
                .AddPack<AutoMapperPack>()
                .AddPack<EndpointsPack>()
                .AddPack<MiniProfilerPack>()
                .AddPack<SwaggerPack>()
                .AddPack<RedisPack>()
                .AddPack<SystemsPack>()
                .AddPack<AuthenticationPack>()
                .AddPack<FunctionAuthorizationPack>()
                .AddPack<DataAuthorizationPack>()
                .AddPack<SqlServerDefaultDbContextMigrationPack>()
                .AddPack<AuditPack>()
                .AddPack<InfosPack>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(WebApplication app)
        {
            IWebHostEnvironment env = app.Environment;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseMiddleware<JsonExceptionHandlerMiddleware>()
                .UseDefaultFiles()
                .UseStaticFiles();
            app.UseOSharp();
        }
    }
}