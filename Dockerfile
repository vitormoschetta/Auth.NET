FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# Receber variaveis do Compose
ARG Email=Email
ENV Email $Email

ARG EmailPassword=EmailPassword
ENV EmailPassword $EmailPassword

COPY Source/*.sln App/
COPY Source/Api/*.csproj App/Api/
COPY Source/Domain/*.csproj App/Domain/
COPY Source/Infra/*.csproj App/Infra/
#COPY Source/Tests/*.csproj App/Tests/

WORKDIR /App
RUN dotnet restore

COPY Source/Api/. ./Api/
COPY Source/Domain/. ./Domain/
COPY Source/Infra/. ./Infra/
#COPY Source/Tests/. ./Tests/

#WORKDIR /App
#RUN dotnet test --logger:trx

WORKDIR /App/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build /App/Api/out ./

ENTRYPOINT ["dotnet", "api.dll"]
