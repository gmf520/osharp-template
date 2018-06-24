﻿// -----------------------------------------------------------------------
//  <copyright file="UserConfiguration.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2017 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-09-11 11:21</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OSharp.Template.Identity.Entities;
using OSharp.Entity;


namespace OSharp.Template.EntityConfiguration.Identity
{
    public class UserConfiguration : EntityTypeConfigurationBase<User, int>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(m => m.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(m => m.NormalizeEmail).HasName("EmailIndex");

            builder.Property(m => m.ConcurrencyStamp).IsConcurrencyToken();

            builder.HasOne<UserDetail>().WithOne().HasForeignKey<UserDetail>(ud => ud.UserId).IsRequired();
            builder.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            builder.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            builder.HasData(new User()
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NickName = "站长",
                Email = "admin@66soft.net",
                NormalizeEmail = "ADMIN@66SOFT.NET",
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                IsSystem = true
            });
        }
    }
}