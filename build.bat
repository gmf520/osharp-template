dotnet build

cd src/ui/ng-alain
npm install && npm run-script build && del ..\..\OSharp.Template.Web\wwwroot\* /q && copy dist\* ..\..\OSharp.Template.Web\wwwroot\ && cd ..\..\OSharp.Template.Web && dotnet build -c Release && dotnet publish -c Release && cd ..\..\ && docker build -t osharp.template.web .
