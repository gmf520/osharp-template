﻿// -----------------------------------------------------------------------
//  <copyright file="UserOutputDto.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:44</last-date>
// -----------------------------------------------------------------------

using System;
using System.Linq;

using OSharp.Dependency;
using OSharp.Entity;


namespace OSharp.Template.Identity.Dtos
{
    /// <summary>
    /// 输出DTO:用户信息
    /// </summary>
    public class UserOutputDto : IOutputDto
    {
        /// <summary>
        /// 获取或设置 用户编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置 表示用户是否已确认其电子邮件地址的标志
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// 获取或设置 手机号码
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 获取或设置 手机号码是否已确认
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 获取或设置 当任何用户锁定结束时，UTC的日期和时间。
        /// </summary>
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// 获取或设置 指示用户是否可以被锁定的标志。
        /// </summary>
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// 获取或设置 当前用户失败的登录尝试次数。
        /// </summary>
        public int AccessFailedCount { get; set; }

        /// <summary>
        /// 获取或设置 是否锁定当前信息
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 角色信息集合
        /// </summary>
        public string[] Roles
        {
            get
            {
                IIdentityContract identityContract = ServiceLocator.Instance.GetService<IIdentityContract>();
                return identityContract.UserRoles.Where(m => !m.IsLocked).Where(m => m.UserId == Id)
                    .SelectMany(m => identityContract.Roles.Where(n => n.Id == m.RoleId).Select(n => n.Name)).Distinct().ToArray();
            }
        }
    }
}