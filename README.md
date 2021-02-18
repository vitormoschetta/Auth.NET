# Auth.NET

API NET Core com autenticação JWT, validação de e-mail e recuperação de senha.  


<br>

## Início Rápido:

**Docker**: Não existe forma mais simples de executar qualquer aplicação, em qualquer ambiente.

Se ainda não possui o Docker instalado segue o link:

<https://www.docker.com/products/docker-desktop/>



<br>

Crie um arquivo na raiz do projeto chamado **email.env** contendo o seguinte conteúdo:
```
Email='youremail@email.com'
EmailPassword='pass123'
``` 
Informe um email e senha válidos!

**Detalhe**: O email que você informar nesse arquivo precisa estar configurado para aceitar **aplicativos menos seguros**. 



<br>

Na raiz do projeto executar o comando docker:
```
docker-compose up -d
```


<br>

Pode demorar alguns minutos, pois se você ainda não tiver as imagens já baixadas na máquina, o Docker tratará de fazer o download.

Ao terminar o processo esta aplicação estará disponivel localmente na seguinte url:

<http://localhost:5000/index.html>




