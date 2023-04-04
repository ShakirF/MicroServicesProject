
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SportStore.Shared/*.csproj Shared/SportStore.Shared/
COPY Services/Catalog/SportStore.Services.Catalog/*.csproj Services/Catalog/SportStore.Services.Catalog/
RUN dotnet restore Services/Catalog/SportStore.Services.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/SportStore.Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","SportStore.Services.Catalog.dll" ]


