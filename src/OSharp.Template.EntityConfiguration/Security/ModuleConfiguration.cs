﻿// -----------------------------------------------------------------------
//  <copyright file="ModuleConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:48</last-date>
// -----------------------------------------------------------------------

using OSharp.Template.Security.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OSharp.Entity;


namespace OSharp.Template.EntityConfiguration.Security
{
    /// <summary>
    /// 模块信息映射配置类
    /// </summary>
    public class ModuleConfiguration : EntityTypeConfigurationBase<Module, int>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasOne<Module>().WithMany().HasForeignKey(m => m.ParentId).IsRequired(false);

            builder.HasData(
                new Module() { Id = 1, Name = "根节点", Remark = "系统根节点", Code = "Root", OrderCode = 1, TreePathString = "$1$" },
                new Module() { Id = 2, Name = "网站", Remark = "网站前台", Code = "Site", OrderCode = 1, ParentId = 1, TreePathString = "$1$,$2$" },
                new Module() { Id = 3, Name = "管理", Remark = "管理后台", Code = "Admin", OrderCode = 2, ParentId = 1, TreePathString = "$1$,$3$" },
                new Module()
                {
                    Id = 4,
                    Name = "身份认证模块",
                    Remark = "身份认证模块节点",
                    Code = "Identity",
                    OrderCode = 1,
                    ParentId = 3,
                    TreePathString = "$1$,$3$,$4$"
                },
                new Module()
                {
                    Id = 5,
                    Name = "权限安全模块",
                    Remark = "权限安全模块节点",
                    Code = "Security",
                    OrderCode = 2,
                    ParentId = 3,
                    TreePathString = "$1$,$3$,$5$"
                },
                new Module()
                {
                    Id = 6,
                    Name = "系统管理模块",
                    Remark = "系统管理模块节点",
                    Code = "System",
                    OrderCode = 3,
                    ParentId = 3,
                    TreePathString = "$1$,$3$,$6$"
                }
            );
        }
    }
}