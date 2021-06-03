ARG  DOTNET_VERSION=3.1
FROM mcr.microsoft.com/dotnet/core/sdk:${DOTNET_VERSION} AS build

#Variaveis de ambiente
ARG Email=Email
ENV Email $Email
ARG EmailPassword=EmailPassword
ENV EmailPassword $EmailPassword

COPY src /app/src
RUN dotnet publish /app/src/Api/api.csproj -c Release -o /app/bin

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
WORKDIR /app/bin
COPY --from=build /app/bin .

EXPOSE 6060

ENTRYPOINT ["dotnet", "api.dll"]
