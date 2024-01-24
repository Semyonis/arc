################################################################################
# BUILD
################################################################################
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

WORKDIR /source
COPY . .
RUN dotnet restore 
RUN dotnet build \
    --no-restore 
    
################################################################################
# TEST
################################################################################
FROM build AS test

WORKDIR /source

RUN dotnet test \
    --no-build \
    --verbosity normal


################################################################################
# MIGRATION
################################################################################
FROM build AS migration

WORKDIR /source/Arc.Executable.Migration/bin/Debug/net8.0

COPY ./Arc.Executable.Migration/appsettings.json ./appsettings.json

ENTRYPOINT ["dotnet", "Arc.Executable.Migration.dll"]


################################################################################
# WEB API
################################################################################
FROM build AS webapi

WORKDIR /source/Arc.Executable.WebApi

RUN dotnet publish \
    -c Release \
    --output /out

WORKDIR /out

COPY ./Arc.Executable.WebApi/appsettings.json ./appsettings.json

ENV ASPNETCORE_URLS=http://*:8080 \
    DOTNET_RUNNING_IN_CONTAINER=true

ENTRYPOINT ["dotnet", "Arc.Executable.WebApi.dll"]