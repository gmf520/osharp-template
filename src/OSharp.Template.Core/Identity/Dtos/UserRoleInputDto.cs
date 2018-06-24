﻿// -----------------------------------------------------------------------
//  <copyright file="UserRoleInputDto.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2017 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-11-16 14:37</last-date>
// -----------------------------------------------------------------------

using OSharp.Template.Identity.Entities;
using OSharp.Identity;
using OSharp.Mapping;


namespace OSharp.Template.Identity.Dtos
{
    /// <summary>
    /// 输入DTO：用户角色信息
    /// </summary>
    [MapTo(typeof(UserRole))]
    public class UserRoleInputDto : UserRoleInputDtoBase<int, int>
    { }
}