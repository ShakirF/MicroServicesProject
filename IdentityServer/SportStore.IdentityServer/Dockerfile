FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/SportStore.Shared/*.csproj Shared/SportStore.Shared/
COPY IdentityServer/SportStore.IdentityServer/*.csproj IdentityServer/SportStore.IdentityServer/ 
RUN dotnet restore  IdentityServer/SportStore.IdentityServer/*.csproj
COPY . .
RUN dotnet publish IdentityServer/SportStore.IdentityServer/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","SportStore.IdentityServer.dll" ]