FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CognitiveMinion.Api/CognitiveMinion.Api.csproj", "CognitiveMinion.Api/"]
RUN dotnet restore "CognitiveMinion.Api/CognitiveMinion.Api.csproj"
COPY . .
WORKDIR "/src/CognitiveMinion.Api"
RUN dotnet build "CognitiveMinion.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CognitiveMinion.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CognitiveMinion.Api.dll"]