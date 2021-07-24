FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore
COPY . .
WORKDIR "/src/ThinkBridge.ShopBridge.ProductService.Api"
RUN dotnet build "ThinkBridge.ShopBridge.ProductService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ThinkBridge.ShopBridge.ProductService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThinkBridge.ShopBridge.ProductService.Api.dll"]