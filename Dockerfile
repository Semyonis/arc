################################################################################
# BUILD
################################################################################
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /source
COPY . .
RUN dotnet restore 
RUN dotnet build --no-restore


################################################################################
# TEST
################################################################################
FROM build AS test
WORKDIR /source
RUN dotnet test  --no-build --verbosity normal


################################################################################
# MIGRATION
################################################################################
FROM build AS migration
WORKDIR /source/Arc.Executable.Migration/bin/Debug/net8.0
COPY ./Arc.Executable.Migration/appsettings.json ./appsettings.json

ENTRYPOINT ["dotnet", "Arc.Executable.Migration.dll"]


################################################################################
# DEVELOPMENT
################################################################################
FROM build AS development
WORKDIR /source/Arc.Executable.WebApi/bin/Debug/net8.0
COPY ./Arc.Executable.WebApi/appsettings.json ./appsettings.json

ENTRYPOINT ["dotnet", "Arc.Executable.WebApi.dll"]
