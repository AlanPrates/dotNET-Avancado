# Dapper Cache MySQL Project

Este projeto é um exemplo de implementação de um repositório utilizando Dapper e cache com .NET 7 para um banco de dados MySQL. A aplicação expõe um endpoint para buscar usuários por ID utilizando cache para otimização de desempenho.

## Requisitos

- .NET 7 SDK
- MySQL

## Configuração do Banco de Dados

1. Certifique-se de que o servidor MySQL está em execução.
2. Crie um banco de dados para o projeto (por exemplo, `meu_banco`).
3. Execute os seguintes comandos SQL para criar a tabela `Usuarios` e inserir dados de exemplo:

```sql
CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL
);

INSERT INTO Usuarios (Nome, Email) VALUES ('João Silva', 'joao.silva@example.com');
INSERT INTO Usuarios (Nome, Email) VALUES ('Maria Oliveira', 'maria.oliveira@example.com');
INSERT INTO Usuarios (Nome, Email) VALUES ('Carlos Souza', 'carlos.souza@example.com');
INSERT INTO Usuarios (Nome, Email) VALUES ('Ana Costa', 'ana.costa@example.com');

