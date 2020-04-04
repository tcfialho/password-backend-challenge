#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["Password.Api/Password.Api.csproj", "Password.Api/"]
COPY ["Password.Domain/Password.Domain.csproj", "Password.Domain/"]
RUN dotnet restore "Password.Api/Password.Api.csproj"
COPY . .
WORKDIR "/src/Password.Api"
RUN dotnet build "Password.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Password.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Password.Api.dll"]