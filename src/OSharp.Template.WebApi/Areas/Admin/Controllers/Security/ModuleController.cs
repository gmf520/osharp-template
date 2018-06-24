﻿// -----------------------------------------------------------------------
//  <copyright file="ModuleController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-03-10 16:58</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OSharp.AspNetCore.Mvc.Filters;
using OSharp.AspNetCore.UI;
using OSharp.Core.Modules;
using OSharp.Data;
using OSharp.Template.Common.Dtos;
using OSharp.Template.Security;
using OSharp.Template.Security.Dtos;
using OSharp.Template.Security.Entities;
using OSharp.Entity;
using OSharp.Filter;
using OSharp.Security;


namespace OSharp.Template.WebApi.Areas.Admin.Controllers
{
    [ModuleInfo(Order = 1, Position = "Security")]
    [Description("管理-模块信息")]
    public class ModuleController : AdminApiController
    {
        private readonly SecurityManager _securityManager;

        public ModuleController(SecurityManager securityManager)
        {
            _securityManager = securityManager;
        }

        [ModuleInfo]
        [Description("读取")]
        public IActionResult Read()
        {
            ListFilterGroup group = new ListFilterGroup(Request);
            Expression<Func<Module, bool>> predicate = FilterHelper.GetExpression<Module>(group);
            var modules = _securityManager.Modules.Where(predicate).OrderBy(m => m.OrderCode).Select(m => new
            {
                m.Id,
                m.Name,
                m.ParentId,
                m.OrderCode,
                m.Code,
                m.Remark
            }).ToList();
            return Json(modules);
        }

        [Description("读取模块[用户]树数据")]
        public IActionResult ReadUserModules(int userId)
        {
            Check.GreaterThan(userId, nameof(userId), 0);
            int[] checkedModuleIds = _securityManager.ModuleUsers.Where(m => m.UserId == userId).Select(m => m.ModuleId).ToArray();

            int[] rootIds = _securityManager.Modules.Where(m => m.ParentId == null).OrderBy(m => m.OrderCode).Select(m => m.Id).ToArray();
            var result = GetModulesWithChecked(rootIds, checkedModuleIds);
            return Json(result);
        }

        [Description("读取模块[角色]树数据")]
        public ActionResult ReadRoleModules(int roleId)
        {
            Check.GreaterThan(roleId, nameof(roleId), 0);
            int[] checkedModuleIds = _securityManager.ModuleRoles.Where(m => m.RoleId == roleId).Select(m => m.ModuleId).ToArray();

            int[] rootIds = _securityManager.Modules.Where(m => m.ParentId == null).OrderBy(m => m.OrderCode).Select(m => m.Id).ToArray();
            var result = GetModulesWithChecked(rootIds, checkedModuleIds);
            return Json(result);
        }

        private List<object> GetModulesWithChecked(int[] rootIds, int[] checkedModuleIds)
        {
            var modules = _securityManager.Modules.Where(m => rootIds.Contains(m.Id)).OrderBy(m => m.OrderCode).Select(m => new
            {
                m.Id,
                m.Name,
                m.OrderCode,
                m.Remark,
                ChildIds = _securityManager.Modules.Where(n => n.ParentId == m.Id).OrderBy(n => n.OrderCode).Select(n => n.Id).ToList()
            }).ToList();
            List<object> nodes = new List<object>();
            foreach (var item in modules)
            {
                var node = new
                {
                    item.Id,
                    item.Name,
                    item.OrderCode,
                    IsChecked = checkedModuleIds.Contains(item.Id),
                    HasChildren = item.ChildIds.Count > 0,
                    item.Remark,
                    Items = item.ChildIds.Count > 0 ? GetModulesWithChecked(item.ChildIds.ToArray(), checkedModuleIds) : new List<object>()
                };
                nodes.Add(node);
            }
            return nodes;
        }

        [ModuleInfo]
        [DependOnFunction("Read")]
        [Description("读取模块功能")]
        public IActionResult ReadFunctions()
        {
            PageRequest request = new PageRequest(Request);
            if (request.FilterGroup.Rules.Count == 0)
            {
                return Json(new PageData<object>());
            }
            Expression<Func<Module, bool>> moduleExp = FilterHelper.GetExpression<Module>(request.FilterGroup);
            int[] moduleIds = _securityManager.Modules.Where(moduleExp).Select(m => m.Id).ToArray();
            Guid[] functionIds = _securityManager.ModuleFunctions.Where(m => moduleIds.Contains(m.ModuleId))
                .Select(m => m.FunctionId).Distinct().ToArray();
            if (functionIds.Length == 0)
            {
                return Json(new PageData<object>());
            }
            if (request.PageCondition.SortConditions.Length == 0)
            {
                request.PageCondition.SortConditions = new[] { new SortCondition("Area"), new SortCondition("Controller") };
            }
            var page = _securityManager.Functions.ToPage(m => functionIds.Contains(m.Id),
                request.PageCondition,
                m => new { m.Id, m.Name, m.AccessType, m.Area, m.Controller });
            return Json(page.ToPageData());
        }

        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("新增子节点")]
        public async Task<IActionResult> Create(ModuleInputDto dto)
        {
            Check.NotNull(dto, nameof(dto));

            OperationResult result = await _securityManager.CreateModule(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("更新")]
        public async Task<IActionResult> Update(ModuleInputDto dto)
        {
            Check.NotNull(dto, nameof(dto));
            if (dto.Id == 1)
            {
                return Json(new AjaxResult("根节点不能编辑", AjaxResultType.Error));
            }

            OperationResult result = await _securityManager.UpdateModule(dto);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("删除")]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            Check.NotNull(id, nameof(id));
            Check.GreaterThan(id, nameof(id), 0);
            if (id == 1)
            {
                return Json(new AjaxResult("根节点不能删除", AjaxResultType.Error));
            }

            OperationResult result = await _securityManager.DeleteModule(id);
            return Json(result.ToAjaxResult());
        }

        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [DependOnFunction("ReadTreeNode", Controller = "Function")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("设置功能")]
        public async Task<IActionResult> SetFunctions([FromBody]ModuleSetFunctionDto dto)
        {
            OperationResult result = await _securityManager.SetModuleFunctions(dto.ModuleId, dto.FunctionIds);
            return Json(result.ToAjaxResult());
        }
    }
}