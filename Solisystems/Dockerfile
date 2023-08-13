
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Solisystems.csproj"
RUN dotnet build "Solisystems.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Solisystems.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
ENV IN_DOCKER_CONTAINER=True
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Solisystems.dll"]