# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src

# Copy everything else and build
COPY ServerRoomLibrary ServerRoomLibrary
COPY ServerRoomMonitoring.Web ServerRoomMonitoring.Web

WORKDIR /src/ServerRoomMonitoring.Web
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://*:80
COPY --from=build-env /src/ServerRoomMonitoring.Web/out .
ENTRYPOINT ["dotnet", "ServerRoomMonitoring.Web.dll"]