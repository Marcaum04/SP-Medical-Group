CREATE DATABASE SPMED_MARCAUM
GO

USE SPMED_MARCAUM;
GO

CREATE TABLE Situacao(
	IdSitucao TINYINT PRIMARY KEY IDENTITY,
	Descricao VARCHAR(15)
);
GO

--TIPO DE USUARIO
CREATE TABLE TipoUsuario(
	IdTipoUsuario TINYINT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(20)
);
GO

--USUARIO
CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario TINYINT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	NomeUsuario VARCHAR(20),
	Email VARCHAR(256),
	Senha VARCHAR(9)
);
GO

--PACIENTE
CREATE TABLE Paciente(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	Telefone VARCHAR(14),
	DataNascimento DATE,
	Endereco VARCHAR(150),
	Rg VARCHAR(12),
	Cpf VARCHAR(14)
);
GO

--CLINICA
CREATE TABLE Clinica(
	IdClinica SMALLINT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(20),
	RazaoSocial VARCHAR(50),
	Endereco VARCHAR(150),
	Cnpj VARCHAR(18),
	HorarioFuncionamento
);
GO