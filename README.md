# Auth.NET

API NET Core com autenticação JWT, validação de e-mail e recuperação de senha.  


<br>
<br>

## Início Rápido:

**Docker**: Não existe forma mais simples de executar qualquer aplicação, em qualquer ambiente.

Se ainda não possui o Docker instalado segue o link:

<https://www.docker.com/products/docker-desktop/>


<br>

Na raiz do projeto executar o comando docker:
```
docker-compose up -d --build
```

Pode demorar alguns minutos, pois se você ainda não tiver as imagens já baixadas na máquina, o Docker tratará de fazer o download.

Ao terminar o processo esta aplicação estará disponivel localmente na seguinte url:

<http://localhost:6060/index.html>



<br>
<br>


## Autenticação para envio de e-mails

#### Container
Se a aplicação for executado em container, siga os passos abaixo:

Crie um arquivo na raiz do projeto chamado **email.env** contendo o seguinte conteúdo:
```
Email='xpto@email.com'
EmailPassword='xtopass'
``` 

<br>

#### VSCode Launch.json

Para executar pelo launch do vscode siga os passos abaixo:

No arquivo `launch.json` gerado pelo vscode, existe uma parte de variável de ambientes, mais ou menos como a baixo:
```
"env": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "Email": "xpto@email.com",
        "EmailPassword": "xptopass*"
    }
``` 

<br>


#### Linha de comando

Para executar pela linha de comando `dotnet run`, siga os passos abaixo:

Dentro da camada de API existe o seguinte diretório:

`Api/Properties/` que possui o seguinte arquivo: `launchSettings.json`. Nesse arquivo existe também um local para adicionar variáveis de ambiente, algo como a baixo:

No arquivo `launch.json` gerado pelo vscode, existe uma parte de variável de ambientes, mais ou menos como a baixo:
```
"environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "Email": "xpto@email.com",
        "EmailPassword": "xptopass*"
      }
``` 

<br>

**Informe um email e senha válidos!**

**Detalhe**: O email que você informar nesse arquivo precisa estar configurado para aceitar **aplicativos menos seguros**. 








