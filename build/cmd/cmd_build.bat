::�������й���������������Ŀ����ģ�һ������
@echo off
echo ��������Ŀ���ƣ��Ƽ����� ����˾.��Ŀ����ģʽ��
set name=:
set /p name=
dotnet new osharp_sln -n %name%
dotnet new osharp_core -n %name% -o %name%\src\%name%.Core
dotnet new osharp_entityconfig -n %name% -o %name%\src\%name%.EntityConfiguration
dotnet new osharp_mvc -n %name% -o %name%\src\%name%.Web
dotnet new osharp_ng -o %name%\src\ui
echo ��Ŀ�����������
pause