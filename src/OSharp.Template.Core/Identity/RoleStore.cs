using System;
using System.Collections.Generic;
using System.Text;

using OSharp.Template.Identity.Entities;
using OSharp.Entity;
using OSharp.Identity;


namespace OSharp.Template.Identity
{
    public class RoleStore : RoleStoreBase<Role, int, RoleClaim>
    {
        /// <summary>
        /// 初始化一个<see cref="RoleStoreBase{TRole,TRoleKey,TRoleClaim}"/>类型的新实例
        /// </summary>
        public RoleStore(IRepository<Role, int> roleRepository, IRepository<RoleClaim, int> roleClaimRepository)
            : base(roleRepository, roleClaimRepository)
        { }
    }
}
