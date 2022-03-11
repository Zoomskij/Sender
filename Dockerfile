FROM node:16
COPY package*.json ./
RUN npm install

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /source
COPY ["PrintLayer.csproj", "/source/"]
RUN dotnet restore "/source/PrintLayer.csproj"
COPY . .
WORKDIR "/source/PrintLayer"
RUN dotnet build "/source/PrintLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/source/PrintLayer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PrintLayer.dll"]