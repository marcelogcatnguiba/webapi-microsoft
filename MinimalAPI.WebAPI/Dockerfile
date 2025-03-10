FROM mcr.microsoft.com/dotnet/sdk:8.0.201-jammy AS build
WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS relesase
WORKDIR /App
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "MinimalAPI.WebAPI.dll"]