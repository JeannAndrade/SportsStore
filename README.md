# SportsStore

 SportsStore by Pro ASP.NET Core 3 - Adam Freeman

## Comandos executados

1. dotnet new globaljson --sdk-version 3.1.404 --output Sports/SportsStore

2. dotnet new web --no-https --output Sports/SportsStore --framework netcoreapp3.1

3. dotnet new sln -o Sports

4. dotnet sln Sports add Sports/SportsStore

5. dotnet new xunit -o Sports/SportsStore.Tests --framework netcoreapp3.1

6. dotnet sln Sports add Sports/SportsStore.Tests

7. dotnet add Sports/SportsStore.Tests reference Sports/SportsStore

8. dotnet add Sports/SportsStore.Tests package Moq

9. dotnet add Sports/SportsStore package Microsoft.EntityFrameworkCore.Design

10. dotnet add Sports/SportsStore package Microsoft.EntityFrameworkCore.SqlServer

11. (se não instalado) dotnet tool uninstall --global dotnet-ef

12. (se não instalado) dotnet tool install --global dotnet-ef --version 3.1.1

13. dotnet ef migrations add Initial -p Sports/SportsStore

14. dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli

15. dotnet tool install --global Microsoft.Web.LibraryManager.Cli

16. libman init -p cdnjs

17. libman install twitter-bootstrap@4.3.1 -d wwwroot/lib/twitter-bootstrap
