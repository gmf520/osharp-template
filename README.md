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
模板名             短名称      语言     标记
---------------  ---------  -------  ----------
OSharp Template    osharp     [C#]   Web/OSharp
``` 

### 1.2 创建项目
在一个空白文件夹，运行如下命令，即可生成项目初始化解决方案的代码，其中`Company.Project`是项目代码默认基础命名空间，推荐格式为“公司.项目”，默认将生成`net6.0的项目`
```
dotnet new osharp -n Company.Project
```
* 指定sdk版本，`--Framework`参数
如果要生成其他sdk版本的项目，可以使用`-F`或`--Framework`参数指定，可选值为：net7.0/net6.0
net6.0：
```
dotnet new osharp -n Company.Project -F net6.0
```
net7.0
```
dotnet new osharp -n Company.Project -F net7.0
```

* 指定数据库类型，`--DatabaseType`参数
项目默认使用`SqlServer`数据库类型，如果要使用其他数据库类型，可以使用`--DatabaseType`参数指定，可选值为：SqlServer/MySql/Sqlite/PostgreSql/Oracle
```
dotnet new osharp -n Company.Project -F net7.0 --DatabaseType MySql
```

* 指定OSharp版本，`--OsharpVersion`参数
引用指定版本的osharp nuget版本号，例如：7.0.11，如果要使用雪花long类型作为主键，可引用snow特定版本，如：7.0.11-snow
```
dotnet new osharp -n Company.Project -F net7.0 --OsharpVersion 7.0.11
```


## 2.文件清单如下：
```
|-- Company.Project
    |-- Company.Project.sln
    |-- Company.Project.sln.DotSettings
    |-- LICENSE
    |-- README.md
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
                |-- DefaultDbContextMigrationPack.cs
                |-- DesignTimeDefaultDbContextFactory.cs
```
