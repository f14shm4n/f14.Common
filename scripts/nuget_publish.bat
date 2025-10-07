dotnet build -c Release
dotnet pack
dotnet nuget push .\src\f14.Common\bin\Release\ --api-key %1 --source https://api.nuget.org/v3/index.json --skip-duplicate