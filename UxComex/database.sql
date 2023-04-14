CREATE DATABASE uxcomex;

USE uxcomex;

CREATE TABLE client (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  Name VARCHAR(100) NOT NULL,
  Telephone VARCHAR(15) NOT NULL,
  Cpf VARCHAR(14) NOT NULL,
  CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
  UpdatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE Address (
  Id INT IDENTITY(1,1) PRIMARY KEY,
  ZipCode VARCHAR(9) NOT NULL,
  Street VARCHAR(50) NOT NULL,
  City VARCHAR(50) NOT NULL,
  State VARCHAR(2) NOT NULL,
  ClientId INT NOT NULL,
  CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
  UpdatedAt DATETIME NOT NULL DEFAULT GETDATE(),
  CONSTRAINT FK_ClientId FOREIGN KEY (ClientId) REFERENCES client(Id) ON DELETE CASCADE
);

INSERT INTO client (Name, Telephone, Cpf)
VALUES 
('Fulano', '(11) 1111-1111', '111.111.111-11'),
('Ciclano', '(22) 2222-2222', '222.222.222-22'),
('Beltrano', '(33) 3333-3333', '333.333.333-33');

INSERT INTO Address (Street, ZipCode, City, State, ClientId)
VALUES
('Rua A, 123', '01234-567', 'São Paulo', 'SP', 1),
('Rua B, 456', '12345-678', 'Rio de Janeiro', 'RJ', 1),
('Rua C, 789', '23456-789', 'Belo Horizonte', 'MG', 2),
('Rua D, 321', '34567-890', 'Porto Alegre', 'RS', 2),
('Rua E, 654', '45678-901', 'Curitiba', 'PR', 3),
('Rua F, 987', '56789-012', 'Salvador', 'BA', 3),
('Rua G, 210', '67890-123', 'Recife', 'PE', 3);
