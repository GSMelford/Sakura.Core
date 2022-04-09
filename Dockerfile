FROM mcr.microsoft.com/dotnet/aspnet:6.0.3-bullseye-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0.201-bullseye-slim-arm64v8 AS build
WORKDIR /src
COPY ["Sakura.Core/Sakura.Core.csproj", "Sakura.Core/"]
RUN dotnet restore "Sakura.Core/Sakura.Core.csproj"
COPY . .
WORKDIR "/src/Sakura.Core"
RUN dotnet build "Sakura.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sakura.Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sakura.Core.dll"]
