// -----------------------------------------------------------------------
//  <copyright file="Program.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2020 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2020-06-02 11:32</last-date>
// -----------------------------------------------------------------------

using OSharp.Template.Web;

var builder = WebApplication.CreateBuilder(args);

Startup startup = new Startup();
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app);
app.Run();