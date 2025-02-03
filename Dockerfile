FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

HEALTHCHECK CMD curl --fail http://localhost:8000/health || exit 1

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SocialMediaAutoPosterApp.csproj", "./"]
RUN dotnet restore "SocialMediaAutoPosterApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SocialMediaAutoPosterApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SocialMediaAutoPosterApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialMediaAutoPosterApp.dll"]
