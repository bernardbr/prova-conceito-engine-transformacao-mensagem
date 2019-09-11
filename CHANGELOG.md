# Changelog

Todas as alterações importantes neste projeto serão documentadas neste arquivo.

O formato é baseado em [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
e este projeto segue o [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

- Testes de integração e carga.

## [1.0.1]

### [Added]

- Testes unitários.
- Criada exceção específica `UfNaoConfiguradaException` para indicar que uma uf não foi configurada.

### [Changed]

- As configurações foram implementadas como interface para permitir Mock.
- O contrato de configuração foi alterado.
- Alterada classe de parse para utilizar a nova exceção.

## [1.0.0]

### Added

- Endpoint com capacidade de receber um arquivo através de um POST com form-data retornando um formato padrão com os dados do arquivo.
- Endpoint de configuração para transformação da estrutura do arquivo.
- Inclusão de documentação com swagger.
- Arquivo Dockerfile já configurado.
- Disponibilizada imagem Docker no [DockerHub](https://cloud.docker.com/u/bernardbr/repository/docker/bernardbr/transformacao-mensagem).
