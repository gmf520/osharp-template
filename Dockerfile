FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base

WORKDIR /app
EXPOSE 80

COPY ./src/OSharp.Template.Web/bin/Release/netcoreapp2.2/publish /app
ENTRYPOINT ["dotnet", "OSharp.Template.Web.dll"]