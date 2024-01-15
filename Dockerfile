FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS development
WORKDIR /source
COPY . .
WORKDIR /source/Arc.Executable.WebApi
RUN dotnet restore 
RUN dotnet build
COPY ./Arc.Executable.WebApi/appsettings.json ./bin/Debug/net8.0/appsettings.json
WORKDIR /source/Arc.Executable.WebApi/bin/Debug/net8.0

ENTRYPOINT ["dotnet", "Arc.Executable.WebApi.dll"]
