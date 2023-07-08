#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Apollo_Carter.API.BankManager.API/Apollo_Carter.API.BankManager.API.csproj", "Apollo_Carter.API.BankManager.API/"]
RUN dotnet restore "Apollo_Carter.API.BankManager.API/Apollo_Carter.API.BankManager.API.csproj"
COPY . .
WORKDIR "/src/Apollo_Carter.API.BankManager.API"
RUN dotnet build "Apollo_Carter.API.BankManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Apollo_Carter.API.BankManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Apollo_Carter.API.BankManager.API.dll"]