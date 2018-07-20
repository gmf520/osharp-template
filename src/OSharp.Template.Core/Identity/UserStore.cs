﻿// -----------------------------------------------------------------------
//  <copyright file="UserStore.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:44</last-date>
// -----------------------------------------------------------------------

using System;

using OSharp.Template.Identity.Entities;

using OSharp.Entity;
using OSharp.EventBuses;
using OSharp.Identity;


namespace OSharp.Template.Identity
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class UserStore : UserStoreBase<User, int, UserClaim, UserLogin, UserToken, Role, int, UserRole>
    {
        /// <summary>
        /// 初始化一个<see cref="UserStoreBase{TUser, TUserKey, TUserClaim, TUserLogin, TUserToken, TRole, TRoleKey, TUserRole}"/>类型的新实例
        /// </summary>
        /// <param name="userRepository">用户仓储</param>
        /// <param name="userLoginRepository">用户登录仓储</param>
        /// <param name="userClaimRepository">用户声明仓储</param>
        /// <param name="userTokenRepository">用户令牌仓储</param>
        /// <param name="roleRepository">角色仓储</param>
        /// <param name="userRoleRepository">用户角色仓储</param>
        /// <param name="eventBus">事件总线</param>
        public UserStore(IRepository<User, int> userRepository,
            IRepository<UserLogin, Guid> userLoginRepository,
            IRepository<UserClaim, int> userClaimRepository,
            IRepository<UserToken, Guid> userTokenRepository,
            IRepository<Role, int> roleRepository,
            IRepository<UserRole, Guid> userRoleRepository,
            IEventBus eventBus)
            : base(userRepository, userLoginRepository, userClaimRepository, userTokenRepository, roleRepository, userRoleRepository, eventBus)
        { }
    }
}