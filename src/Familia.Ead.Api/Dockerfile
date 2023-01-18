FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /
COPY ["nuget.config", "."]
COPY ["src/Familia.Ead.Api/Familia.Ead.Api.csproj", "src/"]
COPY ["src/Familia.Ead.Application/Familia.Ead.Application.csproj", "src/"]
COPY ["src/Familia.Ead.Infrastructure/Familia.Ead.Infrastructure.csproj", "src/"]
COPY ["src/Familia.Ead.Domain/Familia.Ead.Domain.csproj", "src/"]
RUN dotnet restore "src/Familia.Ead.Api.csproj"
COPY . .
WORKDIR /src
RUN ls
RUN dotnet build "Familia.Ead.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Familia.Ead.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Familia.Ead.Api.dll"]