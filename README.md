# OSharp ��Ŀģ��

����Ŀģ������OSharp��Ŀ�ĳ�ʼ����������룬���� 3 ����Ŀ��
1. OSharp.Template.Web��������Ŀ�������ṩWebApi����
2. OSharp.Template.Core�����������Ŀ����ģ��ʵ��ҵ���
3. OSharp.Template.EntityConfiguration��ʵ��ӳ��������Ŀ

## 1. ʹ��˵��
### 1.1 ��װ
��`PowerShell`����`cmd`�������������װģ���
```
dotnet new --install OSharp.Template.WebApi
```
��װ֮������`dotnet new --list`���Բ鿴���Ѱ�װ��ģ��
```
ģ����                ������                ����         ���
-------------------  -------------------  ----------  ----------------
...
OSharp Template      osharp               [C#]        Web/OSharp
...
``` 

### 1.2 ������Ŀ
��һ���հ��ļ��У����������������������Ŀ��ʼ����������Ĵ��룬����`Company.Project`����Ŀ����Ĭ�ϻ��������ռ䣬�Ƽ���ʽΪ����˾.��Ŀ����Ĭ�Ͻ�����`net6.0����Ŀ`
```
dotnet new osharp -n Company.Project
```
���Ҫ��������sdk�汾����Ŀ������ʹ��`-F`��`--Framework`����ָ������ѡֵΪ��net6.0/net5.0/netcoreapp3.1
net5.0��
```
dotnet new osharp -n Company.Project -F net5.0
```
netcoreapp3.1
```
dotnet new osharp -n Company.Project -F netcoreapp3.1
```

## 2.�ļ��嵥���£�
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

## 3. ������Ŀ

### 3.1 �������ݿ�����
��Ŀ���ݿ�����Ĭ��ʹ��`SqlServer`��OSharp֧�ֵ����ݿ������У�
1. SqlServer
2. MySql
3. PostgreSql
4. Oracle
5. Sqlite
�����Ҫ�������ݿ���������ѭ���²���
#### 3.1.1 �������ݿ����Ӵ�
����`src/Company.Project.Web`�ļ��У���`appsettings.Development.json`������`OSharp::DbContexts`�ڵ����Ӧ����
```
"SqlServer": {
    "DbContextTypeName": "OSharp.Entity.DefaultDbContext,OSharp.EntityFrameworkCore",
    "ConnectionString": "Server=localhost;Database=Company.Project-dev;User Id=sa;Password=Abc123456!;",
    "DatabaseType": "SqlServer",
    "AuditEntityEnabled": true,
    "AutoMigrationEnabled": true
}
```
`SqlServer`����Ϊ��Ӧ���ݿ����ƣ�ͬʱ��ʵ�ʳ�������`ConnectionString`���Ӵ�����

#### 3.1.2 �����Ӧ���ݿ�������nuget������
��`src/Company.Project.Web`�ļ��У���`PowerShell`��`cmd��������Ӧ���װ

SqlServer: 
```
Install-Package OSharp.EntityFrameworkCore.SqlServer
```
MySql
```
Install-Package OSharp.EntityFrameworkCore.MySql
```
�ȵȣ��������ݿ���������Ӧ�����а�װ

#### 3.1.3 ������Ӧ���ݿ������� XXXDefaultDbContextMigrationPack
1. ��`src/Company.Project.Web/Startups`�ļ����У�����Ӧ���ݿ�������Pack���빤����
2. ��`Startup.cs`�ļ��У����������Ӧ���ݿ�����Pack����
```
service.AddOSharp()
    ...

    .AddPack<MySqlDefaultDbContextMigrationPack>()
    ...
    
```
#### 3.1.4 �������ݿ�Ǩ�Ƽ�¼
���û�а�װ`dotnet-ef`���ߣ������������װ
```
dotnet tool install dotnet-ef -g
```
��`src/Company.Project.Web`�ļ����У����������������Ǩ�Ƽ�¼
```
dotnet ef migrations add Init
```
����������������ݿ�
```
dotnet ef database update
```
### 3.2 ������Ŀ
���ˣ����ݿⴴ����ϣ�������`src/Company.Project.Web`�ļ�����������������������Ŀ
```
dotnet run
```