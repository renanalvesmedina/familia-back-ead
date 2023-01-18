FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /
RUN ls
COPY ["nuget.config", "."]
COPY ["src/Familia.Ead.Api/Familia.Ead.Api.csproj", "src/Familia.Ead.Api/"]
COPY ["src/Familia.Ead.Application/Familia.Ead.Application.csproj", "src/Familia.Ead.Application/"]
COPY ["src/Familia.Ead.Infrastructure/Familia.Ead.Infrastructure.csproj", "src/Familia.Ead.Infrastructure/"]
COPY ["src/Familia.Ead.Domain/Familia.Ead.Domain.csproj", "src/Familia.Ead.Domain/"]
WORKDIR /src
RUN ls
WORKDIR /src/Familia.Ead.Api
RUN ls
WORKDIR /
RUN dotnet restore "src/Familia.Ead.Api/Familia.Ead.Api.csproj"
COPY . .
WORKDIR /
RUN dotnet build "src/Familia.Ead.Api/Familia.Ead.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Familia.Ead.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Familia.Ead.Api.dll"]