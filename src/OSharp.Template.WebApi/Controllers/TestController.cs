﻿// -----------------------------------------------------------------------
//  <copyright file="TestController.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-05-10 22:46</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using OSharp.AspNetCore.Mvc;
using OSharp.Collections;
using OSharp.Core.Functions;
using OSharp.Template.Security.Entities;
using OSharp.Entity;


namespace OSharp.Template.WebApi.Controllers
{
    [Description("网站-测试")]
    public class TestController : ApiController
    {
        private readonly IRepository<EntityRole, Guid> _entityRoleRepository;

        public TestController(IRepository<EntityRole, Guid> entityRoleRepository)
        {
            _entityRoleRepository = entityRoleRepository;
        }

        [Description("测试01")]
        public IActionResult Test01()
        {
            List<object> list = new List<object>();

            string str = string.Empty;
            list.Add(str);

            return Content(list.ExpandAndToString("\r\n"));
        }
    }
}