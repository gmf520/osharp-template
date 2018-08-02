﻿using System;
using System.Collections.Generic;
using System.Text;

using OSharp.Template.System.Entities;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OSharp.Entity;


namespace OSharp.Template.EntityConfiguration.System
{
    public class AuditPropertyConfiguration : EntityTypeConfigurationBase<AuditProperty, Guid>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Configure(EntityTypeBuilder<AuditProperty> builder)
        {
            builder.HasIndex(m => m.AuditEntityId);
            builder.HasOne(m => m.AuditEntity).WithMany(n => n.Properties).HasForeignKey(m => m.AuditEntityId);
        }
    }
}
