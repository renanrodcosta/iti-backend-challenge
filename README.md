# 🚧 Resolvendo Iti Backend Challenge

## Como utilizar:
- Baixar a versão 3.1.101 do .NET Core SDK em https://dotnet.microsoft.com/download/dotnet-core/3.1

## Tecnoligias utilizadas:
- C#
- ASP.NET Core 3.1

## Executando a aplicação

### Docker

 ```
 cd  src/Iti.BackendChallenge.WebAPI
 docker build -t itichallengewebapi:1.0.0 .
 docker run --rm -it -p 5000:80 -e ASPNETCORE_URLS="http://+" -e ASPNETCORE_ENVIRONMENT=Development itichallengewebapi:1.0.0
 ```
 ----------------------------------------------------------------------------------------------------------------------------------------

### CLI

 ```
 dotnet run --project ./src/Iti.BackendChallenge.WebAPI
 ```
 ----------------------------------------------------------------------------------------------------------------------------------------

## Executando Testes

### Unidade

 ```
 dotnet test ./tests/Iti.BackendChallenge.Tests.Unit
 ```
 ----------------------------------------------------------------------------------------------------------------------------------------


### Integração

 ```
 dotnet test ./tests/Iti.BackendChallenge.Tests.Integration
 ```
 ----------------------------------------------------------------------------------------------------------------------------------------
