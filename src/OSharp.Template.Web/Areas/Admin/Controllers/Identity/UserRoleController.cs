﻿// -----------------------------------------------------------------------
//  <copyright file="UserRoleController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:49</last-date>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using OSharp.Template.Identity;
using OSharp.Template.Identity.Dtos;
using OSharp.Template.Identity.Entities;

using Microsoft.AspNetCore.Mvc;

using OSharp.AspNetCore.Mvc.Filters;
using OSharp.AspNetCore.UI;
using OSharp.Core.Modules;
using OSharp.Data;
using OSharp.Entity;
using OSharp.Filter;
using OSharp.Secutiry;


namespace OSharp.Template.Web.Areas.Admin.Controllers
{
    [ModuleInfo(Order = 3, Position = "Identity", PositionName = "身份认证模块")]
    [Description("管理-用户角色信息")]
    public class UserRoleController : AdminApiController
    {
        private readonly IIdentityContract _identityContract;
        private readonly IFilterService _filterService;

        public UserRoleController(IIdentityContract identityContract,
            IFilterService filterService)
        {
            _identityContract = identityContract;
            _filterService = filterService;
        }

        /// <summary>
        /// 读取用户角色信息
        /// </summary>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [Description("读取")]
        public PageData<UserRoleOutputDto> Read(PageRequest request)
        {
            Expression<Func<UserRole, bool>> predicate = _filterService.GetExpression<UserRole>(request.FilterGroup);
            Func<UserRole, bool> updateFunc = _filterService.GetDataFilterExpression<UserRole>(null, DataAuthOperation.Update).Compile();
            Func<UserRole, bool> deleteFunc = _filterService.GetDataFilterExpression<UserRole>(null, DataAuthOperation.Delete).Compile();

            PageResult<UserRoleOutputDto> page = _identityContract.UserRoles.ToPage(predicate, request.PageCondition, m => new
            {
                D = m,
                UserName = _identityContract.Users.Where(n => n.Id == m.UserId).Select(n => n.UserName).FirstOrDefault(),
                RoleName = _identityContract.Roles.Where(n => n.Id == m.RoleId).Select(n => n.Name).FirstOrDefault()
            }).ToPageResult(data => data.Select(m => new UserRoleOutputDto(m.D)
            {
                UserName = m.UserName,
                RoleName = m.RoleName,
                Updatable = updateFunc(m.D),
                Deletable = deleteFunc(m.D)
            }).ToArray());
            return page.ToPageData();
        }

        /// <summary>
        /// 更新用户角色信息
        /// </summary>
        /// <param name="dtos">用户角色信息</param>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("更新")]
        public async Task<AjaxResult> Update(UserRoleInputDto[] dtos)
        {
            OperationResult result = await _identityContract.UpdateUserRoles(dtos);
            return result.ToAjaxResult();
        }
    }
}