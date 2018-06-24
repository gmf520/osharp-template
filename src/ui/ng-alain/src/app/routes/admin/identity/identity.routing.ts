import { NgModule, } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RoleComponent } from './role/role.component';
import { UserRoleComponent } from './user-role/user-role.component';

const routes: Routes = [
  { path: 'user', component: UserComponent, data: { title: '用户信息管理', reuse: true } },
  { path: 'role', component: RoleComponent, data: { title: '角色信息管理', reuse: true } },
  { path: 'user-role', component: UserRoleComponent, data: { title: '用户角色管理', reuse: true } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class IdentityRoutingModule { }
