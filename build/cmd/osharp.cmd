::�������й���������������Ŀ����ģ�һ������
@echo off
echo ��������������������������������������������������
echo �� ��ӭʹ�� OSharpһ��ģ�� ����
echo �� http://www.osharp.org
echo �� Copyright @ 2014 - 2019 OSHARP.ORG
echo ��������������������������������������������������
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