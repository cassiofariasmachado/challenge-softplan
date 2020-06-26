FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY src/CalculoJuros.Api/*.csproj ./src/CalculoJuros.Api/
COPY test/CalculoJuros.Api.Test/*.csproj ./test/CalculoJuros.Api.Test/
COPY CalculoJuros.sln ./

RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build /app/out .

HEALTHCHECK CMD curl --fail http://localhost:80/health || exit

ENTRYPOINT ["dotnet", "CalculoJuros.Api.dll"]