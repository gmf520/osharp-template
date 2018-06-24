// -----------------------------------------------------------------------
//  <copyright file="EntityUserConfiguration.cs" company="OSharp��Դ�Ŷ�">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>������</last-editor>
//  <last-date>2018-05-15 14:03</last-date>
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
    public class EntityUserConfiguration : EntityTypeConfigurationBase<EntityUser, Guid>
    {
        /// <summary>
        /// ��д��ʵ��ʵ�����͸������Ե����ݿ�����
        /// </summary>
        /// <param name="builder">ʵ�����ʹ�����</param>
        public override void Configure(EntityTypeBuilder<EntityUser> builder)
        {
            builder.HasIndex(m => new { m.EntityId, m.UserId }).HasName("EntityUserIndex");

            builder.HasOne<EntityInfo>().WithMany().HasForeignKey(m => m.EntityId);
            builder.HasOne<User>().WithMany().HasForeignKey(m => m.UserId);
        }
    }
}