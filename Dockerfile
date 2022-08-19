#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VulnerableApp4Kubernetes.csproj", "."]
RUN dotnet restore "./VulnerableApp4Kubernetes.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "VulnerableApp4Kubernetes.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VulnerableApp4Kubernetes.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VulnerableApp4Kubernetes.dll"]
