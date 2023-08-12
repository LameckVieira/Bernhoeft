--Criar o Banco de dados
CREATE DATABASE Teste;
GO

--Para acessar o Banco de dados
USE Teste;
GO

--Criar tabela de produtos
CREATE TABLE Produtos
(
	idProduto INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES Usuario (idUsuario),
	idCategoria INT FOREIGN KEY REFERENCES Categorias (idCategoria),
	nome VARCHAR (200)NOT NULL,
	descricao VARCHAR (200)NOT NULL,
	preco FLOAT NOT NULL,
	situacao BIT NOT NULL
);
GO

--Criar tabela de Categorias
CREATE TABLE Categorias
(
	idCategoria INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES Usuario (idUsuario),
	nome VARCHAR (200)NOT NULL,
	situacao BIT NOT NULL,
);
GO

--Criar tabela de TipoUsuario
CREATE TABLE TipoUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tipoUsusario VARCHAR (200) NOT NULL
);
GO

--Criar tabela de Usuario
CREATE TABLE Usuario
(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario),
	nome VARCHAR (200) NOT NULL,
	email VARCHAR (200) NOT NULL UNIQUE,
	senha VARCHAR (200) NOT NULL
);
GO

--Consultar as Tabelas

SELECT * FROM Produtos
SELECT * FROM Categorias
SELECT * FROM Usuario
SELECT * FROM TipoUsuario

INSERT INTO Produtos (idProduto,idUsuario,idCategoria,nome,descricao,situacao)VALUES (1,1,'Lameck','lameck@gmail.com','lameck123')

INSERT INTO Usuario (idUsuario,idTipoUsuario,nome,email,senha)VALUES (1,1,'Lameck','lameck@gmail.com','lameck123')

INSERT INTO TipoUsuario (idTipoUsuario,tipoUsusario)VALUES (1,'Admin')