FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY ["src/Pokespeare.Api/Pokespeare.Api.csproj", "src/Pokespeare.Api/"]
RUN dotnet restore "src/Pokespeare.Api/Pokespeare.Api.csproj"
COPY . .
WORKDIR "/app/src/Pokespeare.Api"
RUN dotnet publish "Pokespeare.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Pokespeare.Api.dll"]
