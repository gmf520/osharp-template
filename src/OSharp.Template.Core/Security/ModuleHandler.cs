// -----------------------------------------------------------------------
//  <copyright file="ModuleHandler.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-23 18:50</last-date>
// -----------------------------------------------------------------------

using OSharp.Core.Functions;
using OSharp.Template.Security.Dtos;
using OSharp.Template.Security.Entities;
using OSharp.Security;


namespace OSharp.Template.Security
{
    /// <summary>
    /// 模块信息处理器
    /// </summary>
    public class ModuleHandler : ModuleHandlerBase<Module, ModuleInputDto, int, Function, ModuleFunction>
    { }
}