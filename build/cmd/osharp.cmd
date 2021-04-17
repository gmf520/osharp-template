::此命令行工具是用来生成项目代码的，一键生成
@echo off
::生成代码
echo －－－－－－－－－－－－－－－－－－－－－－－－－
echo － 欢迎使用 OSharp一键模板 命令
echo － 当前版本：3.1.2.326
echo － http://www.osharp.org
echo － Copyright @ 2014 - 2020 OSHARP.ORG
echo －－－－－－－－－－－－－－－－－－－－－－－－－
echo 请输入项目名称，推荐形如 “公司.项目”的模式：
set name=:
set /p name=
dotnet new osharp_sln -n %name%
dotnet new osharp_core -n %name% -o %name%\src\%name%.Core
dotnet new osharp_entityconfig -n %name% -o %name%\src\%name%.EntityConfiguration
dotnet new osharp_mvc -n %name% -o %name%\src\%name%.Web
dotnet new osharp_ng -o %name%\src\ui
echo 项目代码生成完成
pause