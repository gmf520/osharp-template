﻿// -----------------------------------------------------------------------
//  <copyright file="LogoutEventData.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-05-03 1:17</last-date>
// -----------------------------------------------------------------------

using OSharp.EventBuses;


namespace OSharp.Template.Identity.Events
{
    /// <summary>
    /// 用户退出事件数据
    /// </summary>
    public class LogoutEventData : EventDataBase
    {
        /// <summary>
        /// 获取或设置 用户编号
        /// </summary>
        public int UserId { get; set; }
    }
}