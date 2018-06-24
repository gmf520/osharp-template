﻿// -----------------------------------------------------------------------
//  <copyright file="UserDetailConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2017 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-09-11 11:21</last-date>
// -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OSharp.Template.Identity.Entities;
using OSharp.Entity;


namespace OSharp.Template.EntityConfiguration.Identity
{
    public class UserDetailConfiguration : EntityTypeConfigurationBase<UserDetail, int>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Configure(EntityTypeBuilder<UserDetail> builder)
        { }
    }
}