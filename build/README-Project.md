# OSharp框架开发说明
## 1. 运行前初始化
### 1.1 更新数据库连接串
进入`src/OSharp.Template.Web`文件夹，打开`appsettings.Development.json`，按实际运行环境更新`OSharp::DbContexts::SqlServer::ConnectionString`节点的数据库连接字符串
```
  "OSharp": {
    "DbContexts": {
      "SqlServer": {
        "DbContextTypeName": "OSharp.Entity.DefaultDbContext,OSharp.EntityFrameworkCore",
        "ConnectionString": "在此配置数据库连接字符串",
        "DatabaseType": "SqlServer",
        "AuditEntityEnabled": true,
        "AutoMigrationEnabled": true
      }
      ...
```

### 1.2 创建数据库迁移记录
如果没有安装`dotnet-ef`工具，运行如下命令安装
```
dotnet tool install dotnet-ef -g
```
在`src/OSharp.Template.Web`文件夹中，运行如下命令添加迁移记录
```
dotnet ef migrations add Init
```
运行如下命令创建数据库
```
dotnet ef database update
```
## 2. 运行项目
至此，数据库创建完毕，可以在`src/OSharp.Template.Web`文件夹中运行如下命令启动项目
```
dotnet run
```
