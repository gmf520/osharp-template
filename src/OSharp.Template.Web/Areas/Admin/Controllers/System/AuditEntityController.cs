﻿// -----------------------------------------------------------------------
//  <copyright file="AuditEntityController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-08-02 14:57</last-date>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

using OSharp.Template.System;
using OSharp.Template.System.Dtos;
using OSharp.Template.System.Entities;

using Microsoft.AspNetCore.Mvc;

using OSharp.Core.Modules;
using OSharp.Entity;
using OSharp.Filter;
using OSharp.IO;

using Z.EntityFramework.Plus;


namespace OSharp.Template.Web.Areas.Admin.Controllers
{
    [ModuleInfo(Order = 3, Position = "System", PositionName = "系统管理模块")]
    [Description("管理-数据审计信息")]
    public class AuditEntityController : AdminApiController
    {
        private readonly IAuditContract _auditContract;

        /// <summary>
        /// 初始化一个<see cref="AuditEntityController"/>类型的新实例
        /// </summary>
        public AuditEntityController(IAuditContract auditContract)
        {
            _auditContract = auditContract;
        }

        [HttpPost]
        [ModuleInfo]
        [Description("读取")]
        public PageData<AuditEntityOutputDto> Read(PageRequest request)
        {
            Expression<Func<AuditEntity, bool>> predicate = FilterHelper.GetExpression<AuditEntity>(request.FilterGroup);
            PageResult<AuditEntityOutputDto> page;
            //有操作参数，是从操作列表来的
            if (request.FilterGroup.Rules.Any(m => m.Field == "OperationId"))
            {
                page = _auditContract.AuditEntitys.ToPage(predicate, request.PageCondition, m => new AuditEntityOutputDto
                {
                    Name = m.Name,
                    TypeName = m.TypeName,
                    EntityKey = m.EntityKey,
                    OperateType = m.OperateType,
                    Properties = _auditContract.AuditProperties.Where(n => n.AuditEntityId == m.Id).OrderBy(n => n.FieldName != "Id").ThenBy(n => n.FieldName).Select(n => new AuditPropertyOutputDto()
                    {
                        DisplayName = n.DisplayName,
                        FieldName = n.FieldName,
                        OriginalValue = n.OriginalValue,
                        NewValue = n.NewValue,
                        DataType = n.DataType
                    }).ToList()
                });
                return page.ToPageData();
            }
            request.AddDefaultSortCondition(new SortCondition("Operation.CreatedTime", ListSortDirection.Descending));
            page = _auditContract.AuditEntitys.ToPage(predicate, request.PageCondition, m => new AuditEntityOutputDto
            {
                Name = m.Name,
                TypeName = m.TypeName,
                EntityKey = m.EntityKey,
                OperateType = m.OperateType,
                NickName = m.Operation.NickName,
                FunctionName = m.Operation.FunctionName,
                CreatedTime = m.Operation.CreatedTime,
                Properties = _auditContract.AuditProperties.Where(n => n.AuditEntityId == m.Id).OrderBy(n => n.FieldName != "Id").ThenBy(n => n.FieldName).Select(n => new AuditPropertyOutputDto()
                {
                    DisplayName = n.DisplayName,
                    FieldName = n.FieldName,
                    OriginalValue = n.OriginalValue,
                    NewValue = n.NewValue,
                    DataType = n.DataType
                }).ToList()
            });
            return page.ToPageData();
        }
    }
}