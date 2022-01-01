# OSharp 项目模板

此项目模板生成OSharp项目的初始解决方案代码，生成 3 个项目：
1. OSharp.Template.Web：宿主项目，对外提供WebApi服务
2. OSharp.Template.Core：服务核心项目，分模块实现业务的
3. OSharp.Template.EntityConfiguration：实体映射配置项目

## 1. 使用说明
### 1.1 安装
打开`PowerShell`或者`cmd`，运行如下命令安装模板包
```
dotnet new --install OSharp.Template.WebApi
```
安装之后，运行`dotnet new --list`可以查看到已安装的模板
```
模板名                短名称                语言         标记
-------------------  -------------------  ----------  ----------------
...
OSharp Template      osharp               [C#]        Web/OSharp
...
``` 

### 1.2 创建项目
在一个空白文件夹，运行如下命令，即可生成项目初始化解决方案的代码，其中`Company.Project`是项目代码默认基础命名空间，推荐格式为“公司.项目”，默认将生成`net6.0的项目`
```
dotnet new osharp -n Company.Project
```
如果要生成其他sdk版本的项目，可以使用`-F`或`--Framework`参数指定，可选值为：net6.0/net5.0/netcoreapp3.1
net5.0：
```
dotnet new osharp -n Company.Project -F net5.0
```
netcoreapp3.1
```
dotnet new osharp -n Company.Project -F netcoreapp3.1
```

## 2.文件清单如下：
```
|-- Company.Project
    |-- Company.Project.sln
    |-- Company.Project.sln.DotSettings
    |-- LICENSE
    |-- ReadMe.md
    |-- build
    |   |-- icon.png
    |   |-- public.props
    |   |-- version.props
    |-- src
        |-- Company.Project.Core
        |   |-- Company.Project.Core.csproj
        |-- Company.Project.EntityConfiguration
        |   |-- Company.Project.EntityConfiguration.csproj
        |-- Company.Project.Web
            |-- appsettings.Development.json
            |-- appsettings.json
            |-- Company.Project.Web.csproj
            |-- log4net.config
            |-- Program.cs
            |-- Startup.cs
            |-- Areas
            |   |-- Admin
            |       |-- Controllers
            |       |   |-- DashboardController.cs
            |       |   |-- HomeController.cs
            |       |   |-- WeatherForecastController.cs
            |       |-- Models
            |           |-- WeatherForecast.cs
            |-- Controllers
            |-- Hangfire
            |   |-- HangfireJobRunner.cs
            |-- Migrations
            |-- Properties
            |   |-- launchSettings.json
            |-- Startups
                |-- DesignTimeDefaultDbContextFactory.cs
                |-- MySqlDefaultDbContextMigrationPack.cs
                |-- NpgsqlDefaultDbContextMigrationPack.cs
                |-- OracleDefaultDbContextMigrationPack.cs
                |-- SqliteDefaultDbContextMigrationPack.cs
                |-- SqlServerDefaultDbContextMigrationPack.cs
```

## 3. 运行项目

### 3.1 更换数据库驱动
项目数据库驱动默认使用`SqlServer`，OSharp支持的数据库驱动有：
1. SqlServer
2. MySql
3. PostgreSql
4. Oracle
5. Sqlite
如果需要更换数据库驱动，遵循如下步骤
#### 3.1.1 更改数据库连接串
进入`src/Company.Project.Web`文件夹，打开`appsettings.Development.json`，更新`OSharp::DbContexts`节点的相应配置
```
"SqlServer": {
    "DbContextTypeName": "OSharp.Entity.DefaultDbContext,OSharp.EntityFrameworkCore",
    "ConnectionString": "Server=localhost;Database=Company.Project-dev;User Id=sa;Password=Abc123456!;",
    "DatabaseType": "SqlServer",
    "AuditEntityEnabled": true,
    "AutoMigrationEnabled": true
}
```
`SqlServer`更改为相应数据库名称，同时按实际场景更新`ConnectionString`连接串内容

#### 3.1.2 添加相应数据库驱动的nuget包引用
在`src/Company.Project.Web`文件夹，打开`PowerShell`或`cmd，运行相应命令安装

SqlServer: 
```
Install-Package OSharp.EntityFrameworkCore.SqlServer
```
MySql
```
Install-Package OSharp.EntityFrameworkCore.MySql
```
等等，其他数据库驱动找相应包进行安装

#### 3.1.3 启用相应数据库驱动的 XXXDefaultDbContextMigrationPack
1. 在`src/Company.Project.Web/Startups`文件夹中，将相应数据库驱动的Pack引入工程中
2. 在`Startup.cs`文件中，添加其他相应数据库驱动Pack类型
```
service.AddOSharp()
    ...

    .AddPack<MySqlDefaultDbContextMigrationPack>()
    ...
    
```
#### 3.1.4 创建数据库迁移记录
如果没有安装`dotnet-ef`工具，运行如下命令安装
```
dotnet tool install dotnet-ef -g
```
在`src/Company.Project.Web`文件夹中，运行如下命令添加迁移记录
```
dotnet ef migrations add Init
```
运行如下命令创建数据库
```
dotnet ef database update
```
### 3.2 运行项目
至此，数据库创建完毕，可以在`src/Company.Project.Web`文件夹中运行如下命令运行项目
```
dotnet run
```