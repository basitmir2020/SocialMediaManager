# Use the ASP.NET runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SocialMediaAutoPosterApp.csproj", "./"]
RUN dotnet restore "SocialMediaAutoPosterApp.csproj"
COPY . .
RUN dotnet build "SocialMediaAutoPosterApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SocialMediaAutoPosterApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage: copy the published application to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialMediaAutoPosterApp.dll"]