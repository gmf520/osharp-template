﻿// -----------------------------------------------------------------------
//  <copyright file="CodeGeneratorPack.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-08-06 15:04</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using OSharp.CodeGenerator;
using OSharp.Core.Packs;
using OSharp.Data;


namespace OSharp.Template.Web.Startups
{
    /// <summary>
    /// 代码生成模块
    /// </summary>
    public class CodeGeneratorPack : OsharpPack
    {
        /// <summary>
        /// 获取 模块级别，级别越小越先启动
        /// </summary>
        public override PackLevel Level => PackLevel.Application;

        /// <summary>
        /// 获取 模块启动顺序，模块启动的顺序先按级别启动，同一级别内部再按此顺序启动，
        /// 级别默认为0，表示无依赖，需要在同级别有依赖顺序的时候，再重写为>0的顺序值
        /// </summary>
        public override int Order => 2;

        /// <summary>
        /// 将模块服务添加到依赖注入服务容器中
        /// </summary>
        /// <param name="services">依赖注入服务容器</param>
        /// <returns></returns>
        public override IServiceCollection AddServices(IServiceCollection services)
        {
            if (Singleton<IHostingEnvironment>.Instance.IsDevelopment())
            {
                services.AddSingleton<ITypeMetadataHandler, TypeMetadataHandler>();
            }
            return services;
        }

        /// <summary>
        /// 应用模块服务
        /// </summary>
        /// <param name="provider">服务提供者</param>
        public override void UsePack(IServiceProvider provider)
        {
            IHostingEnvironment environment = provider.GetService<IHostingEnvironment>();
            if (environment.IsDevelopment())
            {
                IsEnabled = true;
            }
        }
    }
}