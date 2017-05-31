Steps to build/run:

 1. dotnet restore -r win10-x64
 2. dotnet publish -c release -r win10-x64 -f netcoreapp2.0
 3. .\bin\release\netcoreapp2.0\win10-x64\publish\Microsoft.AspNetCore.Server.Kestrel.Performance.exe xunit

