#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GameRentalInvillia/GameRentalInvillia.csproj", "GameRentalInvillia/"]
RUN dotnet restore "GameRentalInvillia/GameRentalInvillia.csproj"
COPY . .
WORKDIR "/src/GameRentalInvillia"
RUN dotnet build "GameRentalInvillia.csproj" -c Release -o /app/build
RUN dotnet ef database update

FROM build AS publish
RUN dotnet publish "GameRentalInvillia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameRentalInvillia.dll"]