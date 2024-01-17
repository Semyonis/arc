FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /source
COPY . .
RUN dotnet restore 
RUN dotnet build --no-restore

FROM build AS test
WORKDIR /source
RUN dotnet test  --no-build --verbosity normal

FROM build AS development
WORKDIR /source/Arc.Executable.WebApi/bin/Debug/net8.0
COPY ./Arc.Executable.WebApi/appsettings.json ./appsettings.json

ENTRYPOINT ["dotnet", "Arc.Executable.WebApi.dll"]
