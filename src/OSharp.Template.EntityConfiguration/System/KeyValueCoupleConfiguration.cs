﻿// -----------------------------------------------------------------------
//  <copyright file="KeyValueCoupleConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-25 21:20</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OSharp.Entity;
using OSharp.System;


namespace OSharp.Template.EntityConfiguration.System
{
    public class KeyValueCoupleConfiguration : EntityTypeConfigurationBase<KeyValueCouple, Guid>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Configure(EntityTypeBuilder<KeyValueCouple> builder)
        {
            builder.HasData(
                new KeyValueCouple() { Key = SystemSettingKeys.SiteName, Value = "OSHARP" },
                new KeyValueCouple() { Key = SystemSettingKeys.SiteDescription,Value = "Osharp with .NetStandard2.0 & Angular6"}
            );
        }
    }
}