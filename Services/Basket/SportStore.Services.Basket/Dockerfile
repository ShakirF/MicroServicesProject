FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY Shared/SportStore.Shared/*.csproj Shared/SportStore.Shared/
COPY Services/Basket/SportStore.Services.Basket/*.csproj Services/Basket/SportStore.Services.Basket/
RUN dotnet restore Services/Basket/SportStore.Services.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/SportStore.Services.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","SportStore.Services.Basket.dll" ]
