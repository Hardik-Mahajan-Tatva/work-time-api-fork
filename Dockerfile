# Use ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
# Use Render's PORT environment variable
ENV ASPNETCORE_URLS=http://+:$PORT

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["WorkTimeAPI.API/WorkTimeAPI.API.csproj", "WorkTimeAPI.API/"]
RUN dotnet restore "WorkTimeAPI.API/WorkTimeAPI.API.csproj"

# Copy the rest of the solution
COPY . .

# Publish the API project
RUN dotnet publish "WorkTimeAPI.API/WorkTimeAPI.API.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app

# Copy published files
COPY --from=build /app/publish .

# Entry point
ENTRYPOINT ["dotnet", "WorkTimeAPI.API.dll"]
