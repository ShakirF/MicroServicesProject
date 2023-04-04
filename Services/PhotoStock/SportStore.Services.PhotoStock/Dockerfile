FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/SportStore.Shared/*.csproj Shared/SportStore.Shared/
COPY Services/PhotoStock/SportStore.Services.PhotoStock/*.csproj Services/PhotoStock/SportStore.Services.PhotoStock/
RUN dotnet restore Services/PhotoStock/SportStore.Services.PhotoStock/*.csproj
COPY . .
RUN dotnet publish Services/PhotoStock/SportStore.Services.PhotoStock/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","SportStore.Services.PhotoStock.dll" ]
