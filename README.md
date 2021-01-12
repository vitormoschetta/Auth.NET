# Auth.NET

API NET Core com autenticação JWT, validação de e-mail e recuperação de senha.  
<br>


## Início Rápido:

Necessário ter o SQLServer LocalDB instalado.  [Link](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15)

Se ainda não possui o .NET Core SDK instalado, segue o link de suporte a instalação:   
<https://docs.microsoft.com/pt-br/dotnet/core/install/windows?tabs=netcore31>

Obs: instale a versão 3.1

No Prompt de comando, dentro da pasta **Api**, executar os seguintes comandos:
```
dotnet dev-certs https --trust

dotnet restore

dotnet run
```

Se tudo ocorreu bem, a seguinte URL ficará disponível:   
https://localhost:5001

Para acessar a documentação da API:  
https://localhost:5001/index.html

