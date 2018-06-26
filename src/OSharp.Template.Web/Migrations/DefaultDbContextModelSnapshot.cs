﻿// -----------------------------------------------------------------------
//  <copyright file="DefaultDbContextModelSnapshot.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-27 4:50</last-date>
// -----------------------------------------------------------------------

using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

using OSharp.Entity;


namespace OSharp.Template.Web.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    partial class DefaultDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OSharp.Core.EntityInfos.EntityInfo",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AuditEnabled");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PropertyNamesJson")
                        .IsRequired();

                    b.Property<string>("TypeName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TypeName")
                        .IsUnique()
                        .HasName("ClassFullNameIndex");

                    b.ToTable("EntityInfo");
                });

            modelBuilder.Entity("OSharp.Core.Functions.Function",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessType");

                    b.Property<string>("Action");

                    b.Property<string>("Area");

                    b.Property<bool>("AuditEntityEnabled");

                    b.Property<bool>("AuditOperationEnabled");

                    b.Property<int>("CacheExpirationSeconds");

                    b.Property<string>("Controller");

                    b.Property<bool>("IsAccessTypeChanged");

                    b.Property<bool>("IsAjax");

                    b.Property<bool>("IsCacheSliding");

                    b.Property<bool>("IsController");

                    b.Property<bool>("IsLocked");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("Area", "Controller", "Action")
                        .IsUnique()
                        .HasName("AreaControllerActionIndex")
                        .HasFilter("[Area] IS NOT NULL AND [Controller] IS NOT NULL AND [Action] IS NOT NULL");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.LoginLog",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Ip");

                    b.Property<DateTime?>("LogoutTime");

                    b.Property<string>("UserAgent");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LoginLog");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.Organization",
                b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.Property<string>("Remark");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.Role",
                b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsLocked");

                    b.Property<bool>("IsSystem");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("NormalizedName")
                        .IsRequired();

                    b.Property<string>("Remark")
                        .HasMaxLength(512);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "dbecf737-5373-4b96-ac2b-7febd57b363c",
                            CreatedTime = new DateTime(2018, 6, 25, 21, 44, 21, 200, DateTimeKind.Local),
                            IsAdmin = true,
                            IsDefault = false,
                            IsLocked = false,
                            IsSystem = true,
                            Name = "系统管理员",
                            NormalizedName = "系统管理员",
                            Remark = "系统最高权限管理角色"
                        }
                    );
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.RoleClaim",
                b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.User",
                b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("HeadImg");

                    b.Property<bool>("IsLocked");

                    b.Property<bool>("IsSystem");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NickName");

                    b.Property<string>("NormalizeEmail")
                        .IsRequired();

                    b.Property<string>("NormalizedUserName")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Remark");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("NormalizeEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserClaim",
                b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .IsRequired();

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserDetail",
                b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RegisterIp");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetail");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserLogin",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("LoginProvider", "ProviderKey")
                        .IsUnique()
                        .HasName("UserLoginIndex")
                        .HasFilter("[LoginProvider] IS NOT NULL AND [ProviderKey] IS NOT NULL");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserRole",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<bool>("IsLocked");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId", "RoleId")
                        .IsUnique()
                        .HasName("UserRoleIndex");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserToken",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "LoginProvider", "Name")
                        .IsUnique()
                        .HasName("UserTokenIndex")
                        .HasFilter("[LoginProvider] IS NOT NULL AND [Name] IS NOT NULL");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.EntityRole",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<Guid>("EntityId");

                    b.Property<string>("FilterGroupJson");

                    b.Property<bool>("IsLocked");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("EntityId", "RoleId")
                        .IsUnique()
                        .HasName("EntityRoleIndex");

                    b.ToTable("EntityRole");
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.EntityUser",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<Guid>("EntityId");

                    b.Property<string>("FilterGroupJson");

                    b.Property<bool>("IsLocked");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("EntityId", "UserId")
                        .HasName("EntityUserIndex");

                    b.ToTable("EntityUser");
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.Module",
                b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("OrderCode");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Remark");

                    b.Property<string>("TreePathString");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Module");

                    b.HasData(
                        new { Id = 1, Code = "Root", Name = "根节点", OrderCode = 1.0, Remark = "系统根节点", TreePathString = "$1$" },
                        new { Id = 2, Code = "Site", Name = "网站", OrderCode = 1.0, ParentId = 1, Remark = "网站前台", TreePathString = "$1$,$2$" },
                        new { Id = 3, Code = "Admin", Name = "管理", OrderCode = 2.0, ParentId = 1, Remark = "管理后台", TreePathString = "$1$,$3$" },
                        new
                        {
                            Id = 4,
                            Code = "Identity",
                            Name = "身份认证模块",
                            OrderCode = 1.0,
                            ParentId = 3,
                            Remark = "身份认证模块节点",
                            TreePathString = "$1$,$3$,$4$"
                        },
                        new
                        {
                            Id = 5,
                            Code = "Security",
                            Name = "权限安全模块",
                            OrderCode = 2.0,
                            ParentId = 3,
                            Remark = "权限安全模块节点",
                            TreePathString = "$1$,$3$,$5$"
                        },
                        new
                        {
                            Id = 6,
                            Code = "System",
                            Name = "系统管理模块",
                            OrderCode = 3.0,
                            ParentId = 3,
                            Remark = "系统管理模块节点",
                            TreePathString = "$1$,$3$,$6$"
                        }
                    );
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.ModuleFunction",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FunctionId");

                    b.Property<int>("ModuleId");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("ModuleId", "FunctionId")
                        .IsUnique()
                        .HasName("ModuleFunctionIndex");

                    b.ToTable("ModuleFunction");
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.ModuleRole",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ModuleId");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("ModuleId", "RoleId")
                        .IsUnique()
                        .HasName("ModuleRoleIndex");

                    b.ToTable("ModuleRole");
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.ModuleUser",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Disabled");

                    b.Property<int>("ModuleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("ModuleId", "UserId")
                        .IsUnique()
                        .HasName("ModuleUserIndex");

                    b.ToTable("ModuleUser");
                });

            modelBuilder.Entity("OSharp.System.KeyValueCouple",
                b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsLocked");

                    b.Property<string>("Key")
                        .IsRequired();

                    b.Property<string>("ValueJson");

                    b.Property<string>("ValueType");

                    b.HasKey("Id");

                    b.ToTable("KeyValueCouple");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa84bfa5-47c7-4fa8-9fb0-a90a0166404b"),
                            IsLocked = false,
                            Key = "Site.Name",
                            ValueJson = "\"OSHARP\"",
                            ValueType = "System.String"
                        },
                        new
                        {
                            Id = new Guid("1928b030-7a4b-48b6-b6ec-a90a01664050"),
                            IsLocked = false,
                            Key = "Site.Description",
                            ValueJson = "\"Osharp with .NetStandard2.0 & Angular6\"",
                            ValueType = "System.String"
                        }
                    );
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.LoginLog",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.Organization",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.Organization")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.RoleClaim",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserClaim",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserDetail",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithOne()
                        .HasForeignKey("OSharp.Template.Identity.Entities.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserLogin",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserRole",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Identity.Entities.UserToken",
                b =>
                {
                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.EntityRole",
                b =>
                {
                    b.HasOne("OSharp.Core.EntityInfos.EntityInfo")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OSharp.Template.Identity.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.EntityUser",
                b =>
                {
                    b.HasOne("OSharp.Core.EntityInfos.EntityInfo")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.Module",
                b =>
                {
                    b.HasOne("OSharp.Template.Security.Entities.Module")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.ModuleFunction",
                b =>
                {
                    b.HasOne("OSharp.Core.Functions.Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OSharp.Template.Security.Entities.Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.ModuleRole",
                b =>
                {
                    b.HasOne("OSharp.Template.Security.Entities.Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OSharp.Template.Identity.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OSharp.Template.Security.Entities.ModuleUser",
                b =>
                {
                    b.HasOne("OSharp.Template.Security.Entities.Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OSharp.Template.Identity.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}