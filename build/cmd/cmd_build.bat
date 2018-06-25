::此命令行工具是用来生成项目代码的，一键生成
@echo off
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