SET ROOTDIRECTORY=%~dp0
SET ExistFile=%ROOTDIRECTORY%\englishtotamil.Models\englishtotamil.Models.csproj
cd %ROOTDIRECTORY%
if exist %ExistFile% goto  RUN_DOTNET
dotnet new classlib -n englishtotamil.Models --framework netcoreapp3.1 --force
cd englishtotamil.Models
dotnet add package FluentValidation.AspNetCore --version 8.6.2
dotnet build
cd..
dotnet new classlib -n englishtotamil.DAL --framework netcoreapp3.1 --force
dotnet add englishtotamil.DAL/englishtotamil.DAL.csproj reference englishtotamil.Models/englishtotamil.Models.csproj
cd englishtotamil.DAL
dotnet add package EnterpriseLibrary.Caching.Database.NetCore --version 5.0.512
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.1.6
dotnet build
cd..
dotnet new webapi -n englishtotamilWebApi --framework netcoreapp3.1 --force
xcopy /y  "%ROOTDIRECTORY%\englishtotamilWebApiRequisites" "%ROOTDIRECTORY%\englishtotamilWebApi"
dotnet add englishtotamilWebApi/englishtotamilWebApi.csproj reference englishtotamil.Models/englishtotamil.Models.csproj
dotnet add englishtotamilWebApi/englishtotamilWebApi.csproj reference englishtotamil.DAL/englishtotamil.DAL.csproj
cd englishtotamilWebApi
dotnet add package NLog --version 4.7.2
dotnet add package NLog.Web.AspNetCore  --version 4.9.2
dotnet add package NLog.Extensions.Logging  --version 1.6.4
dotnet add package NLog.MailKit  --version 3.2.0
dotnet add package Microsoft.AspNet.WebApi.Cors --version 5.2.7
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.1.6
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 3.1.6
dotnet add package Swashbuckle.AspNetCore --version 6.1.1
dotnet add package Swashbuckle.AspNetCore.SwaggerUi --version 6.1.1
dotnet add package RestSharp --version 106.11.7
dotnet add package IdentityServer4.AccessTokenValidation --version 2.7.0
:RUN_DOTNET
cd %ROOTDIRECTORY%\
cd englishtotamil.Models
dotnet build
cd..
cd englishtotamil.DAL
dotnet build
cd..
setx ASPNETCORE_ENVIRONMENT "Development"
START CMD /K Admin.bat
setx ASPNETCORE_ENVIRONMENT "Development"
START CMD /K Client.bat

cd %ROOTDIRECTORY%\englishtotamilWebApi
dotnet run

