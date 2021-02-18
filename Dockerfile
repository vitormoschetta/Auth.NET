FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

COPY src/*.sln App/
COPY src/Api/*.csproj App/Api/
COPY src/Domain/*.csproj App/Domain/
COPY src/Infra/*.csproj App/Infra/
COPY src/Shared/*.csproj App/Shared/
#COPY src/Tests/*.csproj App/Tests/

WORKDIR /App
RUN dotnet restore

COPY src/Api/. ./Api/
COPY src/Domain/. ./Domain/
COPY src/Infra/. ./Infra/
COPY src/Shared/. /Shared/
#COPY src/Tests/. ./Tests/

#WORKDIR /App
#RUN dotnet test --logger:trx

WORKDIR /App/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build /App/Api/out ./

ENTRYPOINT ["dotnet", "api.dll"]