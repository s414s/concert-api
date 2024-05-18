FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY Application/*.csproj Application/
COPY Domain/*.csproj Domain/
COPY Infraestructure/*.csproj Infraestructure/
COPY WebApi/*.csproj WebApi/
RUN dotnet restore WebApi/WebApi.csproj

COPY . .
RUN dotnet publish concert-api.sln -c Release -o API/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/API/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "WebApi.dll"]