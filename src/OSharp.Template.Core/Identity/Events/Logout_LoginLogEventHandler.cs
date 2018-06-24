﻿// -----------------------------------------------------------------------
//  <copyright file="Logout_LoginLogEventHandler.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-05-03 1:22</last-date>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using OSharp.Template.Identity.Entities;
using OSharp.Dependency;
using OSharp.Entity;
using OSharp.EventBuses;


namespace OSharp.Template.Identity.Events
{
    /// <summary>
    /// 用户登出事件：登录日志
    /// </summary>
    public class LogoutLoginLogEventHandler : EventHandlerBase<LogoutEventData>, ITransientDependency
    {
        private readonly IRepository<LoginLog, Guid> _loginLogRepository;

        /// <summary>
        /// 初始化一个<see cref="LogoutLoginLogEventHandler"/>类型的新实例
        /// </summary>
        public LogoutLoginLogEventHandler(IRepository<LoginLog, Guid> loginLogRepository)
        {
            _loginLogRepository = loginLogRepository;
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="eventData">事件源数据</param>
        public override void Handle(LogoutEventData eventData)
        {
            LoginLog log = _loginLogRepository.Entities.LastOrDefault(m => m.UserId == eventData.UserId);
            if (log == null)
            {
                return;
            }
            log.LogoutTime = DateTime.Now;
            _loginLogRepository.Update(log);
        }

    }
}