FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY src/TaxaJuros.Api/*.csproj ./src/TaxaJuros.Api/
COPY test/TaxaJuros.Api.Test/*.csproj ./test/TaxaJuros.Api.Test/
COPY TaxaJuros.sln ./

RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build /app/out .

HEALTHCHECK CMD curl --fail http://localhost:80/health || exit

ENTRYPOINT ["dotnet", "TaxaJuros.Api.dll"]