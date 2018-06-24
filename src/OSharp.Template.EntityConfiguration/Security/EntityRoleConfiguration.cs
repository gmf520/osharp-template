﻿// -----------------------------------------------------------------------
//  <copyright file="EntityRoleConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-05-15 13:57</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OSharp.Core.EntityInfos;
using OSharp.Template.Identity.Entities;
using OSharp.Template.Security.Entities;
using OSharp.Entity;


namespace OSharp.Template.EntityConfiguration.Security
{
    public class EntityRoleConfiguration : EntityTypeConfigurationBase<EntityRole, Guid>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Configure(EntityTypeBuilder<EntityRole> builder)
        {
            builder.HasIndex(m => new { m.EntityId, m.RoleId }).HasName("EntityRoleIndex").IsUnique();

            builder.HasOne<EntityInfo>().WithMany().HasForeignKey(m => m.EntityId);
            builder.HasOne<Role>().WithMany().HasForeignKey(m => m.RoleId);
        }
    }
}