::�������й���������������Ŀ����ģ�һ������
@echo off
::���ɴ���
echo ��������������������������������������������������
echo �� ��ӭʹ�� OSharpһ��ģ�� ����
echo �� ��ǰ�汾��3.1.2.326
echo �� http://www.osharp.org
echo �� Copyright @ 2014 - 2020 OSHARP.ORG
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