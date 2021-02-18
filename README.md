# Auth.NET

API NET Core com autenticação JWT, validação de e-mail e recuperação de senha.  


<br>

## Início Rápido:
Produzindo..

<br>

## Configuração de Email

Email e senha do remetente é definido no arquivo _appsettings.json_ no seguinte diretório:
``` 
src/Api/appsettings.json
```

Atenção: Não é necessário expor esses dados preenchendo diretamente no arquivo. Podemos usar variáveis de ambiente na inicialização da aplicação. 

O seguinte comando inicializa a aplicação passando os valores de email e senha do remetente:

```
dotnet run Email="exemplo@email.com" EmailPassword="pass123"
```

