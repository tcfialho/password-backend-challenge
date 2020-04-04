![Status](https://github.com/tcfialho/password-backend-challenge/workflows/password-backend-challenge/badge.svg) [![Coverage](https://codecov.io/gh/tcfialho/password-backend-challenge/branch/master/graph/badge.svg)](https://codecov.io/gh/tcfialho/password-backend-challenge)

# Como executar
Temos duas opções para rodar o projeto, uma dependente da instalação do docker e outra dependente da instalação do .NET Core 3.1 SDK na maquina.

Executando em um container (Docker requerido):
1- Instale o docker https://docs.docker.com/
2- Va até a pasta password-api\src\Password.Docker e execute o comando:
   docker-compose up
3- Abra o swagger da aplicação: http://localhost:5000/swagger e utilize a interface do swagger para testar a API.

Executando localmente (.NET Core 3.1 SDK requerido):
1- Instale o .NET Core 3.1 SDK https://dotnet.microsoft.com/download
2- Va até a pasta password-api\src e execute o comando 
   dotnet run
3- Abra o swagger da aplicação: http://localhost:5000/swagger e utilize a interface do swagger para testar a API.

# Descrição
Considere uma senha sendo válida quando a mesma possuir as seguintes definições:
- Nove ou mais caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial

Exemplo:  
```
IsValid("") -> false  
IsValid("aa") -> false  
IsValid("ab") -> false  
IsValid("AAAbbbCc") -> false  
IsValid("AbTp9!foo") -> true  
```

## Problema
Construa uma aplicação que exponha uma api web que valide se uma senha é válida.

Input: Uma senha (string).  
Output: Um boolean indicando se a senha é válida.

Você pode fazer na linguagem de programação que considera ter mais conhecimento.

# Pontos que daremos maior atenção
Queremos que você escreva essa solução pensando que ao nos enviar ela estará "pronta para produção". Alguns itens que serão avaliados são:

- Testes de unidade / integração
- Abstração, acoplamento e coesão
- Design de API
- Clean Code
- SOLID