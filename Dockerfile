FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
EXPOSE 80 
EXPOSE 443
COPY . .
RUN dotnet test
WORKDIR "/app/src/Pokespeare.Api"
RUN dotnet publish "Pokespeare.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Pokespeare.Api.dll"]
