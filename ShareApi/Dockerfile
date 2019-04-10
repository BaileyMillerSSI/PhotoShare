FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ShareApi/ShareApi.csproj ShareApi/
RUN dotnet restore ShareApi/ShareApi.csproj
COPY . .
WORKDIR /src/ShareApi
RUN dotnet build ShareApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ShareApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShareApi.dll"]
