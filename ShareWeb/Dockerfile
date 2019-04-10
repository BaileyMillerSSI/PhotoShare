FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM node:10.15-alpine as webbuild
COPY ["Angular", "ShareWeb/web"]
WORKDIR /ShareWeb/web
RUN npm install
RUN npm install -g @angular/cli
RUN npm install -g sass
RUN npm rebuild node-sass
RUN ng build --prod


FROM microsoft/dotnet:2.2-sdk AS hostbuild
WORKDIR /src
COPY ["ShareWeb.csproj", "ShareWeb/"]
RUN dotnet restore "ShareWeb/ShareWeb.csproj"
COPY . ./ShareWeb
WORKDIR "/src/ShareWeb"
COPY --from=webbuild ShareWeb/web/dist ./wwwroot/
RUN ls
RUN dotnet build "ShareWeb.csproj" -c Release -o /app

FROM hostbuild AS publish
RUN dotnet publish "ShareWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN ls ./wwwroot
RUN rm -r Angular
ENTRYPOINT ["dotnet", "ShareWeb.dll"]