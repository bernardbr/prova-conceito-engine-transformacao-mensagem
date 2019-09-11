# PoC para Engine de transformação de mensagens

Repositório de PoC da construção de uma Engine de Transformação de mensagens.

## Conceitos

A ideia do projeto é criar uma API que receba arquivos XML ou JSON com formatos diversos, e que a mesma possa retornar uma estrutura padronizada com os dados relevantes do arquivo. Para implementação da PoC, resolvi utilizar o exemplo de CENSO estadual em que cada estado possui um formato distinto de arquivo.

### Exemplos de arquivos de entrada

#### XML

```xml
<corpo>
    <cidade>
        <nome>Rio de Janeiro</nome>
        <populacao>10345678</populacao>
        <bairros>
            <bairro>
                <nome>Tijuca</nome>
                <regiao>Zona Norte</regiao>
                <populacao>135678</populacao>
            </bairro>
            <bairro>
                <nome>Botafogo</nome>
                <regiao>Zona Sul</regiao>
                <populacao>105711</populacao>
            </bairro>
        </bairros>
    </cidade>
    <cidade>
        <nome>Teresópolis</nome>
        <populacao>182594</populacao>
        <bairros>
            <bairro>
                <nome>Tijuca</nome>
                <regiao>Centro</regiao>
                <populacao>13678</populacao>
            </bairro>
        </bairros>
    </cidade>
</corpo>
```

#### JSON

```json
{
  "cities": [
    {
      "name": "Rio Branco",
      "population": 576589,
      "neighborhoods": [
        {
          "name": "Habitasa",
          "population": 7503
        }
      ]
    }
  ]
}
```

### Exemplo do arquivo de saída

#### Processado a partir do XML

```json
{
  "result": [
    {
      "cidade": "Rio de Janeiro",
      "habitantes": 10345678,
      "bairros": [
        {
          "nome": "Tijuca",
          "habitantes": 135678
        },
        {
          "nome": "Botafogo",
          "habitantes": 105711
        }
      ]
    },
    {
      "cidade": "Teresópolis",
      "habitantes": 182594,
      "bairros": [
        {
          "nome": "Tijuca",
          "habitantes": 13678
        }
      ]
    }
  ]
}
```

#### Processado a partir do JSON

```json
{
  "result": [
    {
      "cidade": "Rio Branco",
      "habitantes": 576589,
      "bairros": [
        {
          "nome": "Habitasa",
          "habitantes": 7503
        }
      ]
    }
  ]
}
```

## Utilização

Para que seja possível transformar cada um dos tipos de arquivo, estabeleceu-se, que os endpoint serão sempre parametrizados com o código da UF, sendo assim, para o envio do arquivo de CENSO, o endpoint ficaria da seguinte forma: `<servidor:porta>/api/v1/censo/rj/dados`.

Desta forma será possível definir a regra de obtenção dos dados dos arquivos de cada estado utilizando-se o endpoint: `<servidor:porta>/api/v1/censo/rj/configuracoes`.

A estrutura de cada um dos endpoints podem ser conferidas em: `<servidor:porta>/docs`. Apesar de não gostar de utilizar muitas `annotations` nas classes, tomei a decisão de utilizar o [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) para agilizar o processo de documentação.

## Docker

A API possui um `Dockerfile` para criação da imagem do container Docker. Para tal, basta acessar o diretório do projeto da API `src\api` e executar a publicação para o diretório `output`. Não foi criado um `docker-compose` pois a ideia é que futuramente utilizemos um CI estilo [Travis](https://travis-ci.org/) que será responsável por todo o trâmite de testes, validação de cobertura, build e compilação do Docker através do `docker-cli`.

Para realizar a criação da imagem docker em sua máquina basta após a publicação em `output` executar os seguites comandos:

```shell
dotnet clean
dotnet test
cd .\src\api
dotnet publish -c Release -o output
docker build -t <seu-usuario>/transformacao-mensagem:<versao> .
docker login
docker push <seu-usuario>/transformacao-mensagem
```
