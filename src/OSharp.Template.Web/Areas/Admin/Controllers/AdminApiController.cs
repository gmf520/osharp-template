﻿// -----------------------------------------------------------------------
//  <copyright file="AdminApiController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-09 20:36</last-date>
// -----------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;

using OSharp.AspNetCore.Mvc;
using OSharp.Core;
using OSharp.Security;


namespace OSharp.Template.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [RoleLimit]
    public abstract class AdminApiController : AreaApiController
    { }
}