FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/SportStore.Shared/*.csproj Shared/SportStore.Shared/
COPY Services/Discount/SportStore.Services.Discount/*.csproj Services/Discount/SportStore.Services.Discount/
RUN dotnet restore Services/Discount/SportStore.Services.Discount/*.csproj
COPY . .
RUN dotnet publish Services/Discount/SportStore.Services.Discount/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","SportStore.Services.Discount.dll" ]

