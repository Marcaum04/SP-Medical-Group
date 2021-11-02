USE SPMED_MARCAUM;
GO

--Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
SELECT COUNT(IdMedico)
FROM Medico
WHERE IdEspecialidade = 17
GO

--Criou uma fun��o para retornar a quantidade de m�dicos de uma determinada especialidade
CREATE PROCEDURE P_Idade
AS  
SELECT  NomeUsuario, DATEDIFF(YEAR, (DataNascimento), GETDATE()) AS 'Idade'
FROM Paciente
INNER JOIN Usuario 
ON Paciente.IdUsuario = Usuario.IdUsuario
GO

EXEC P_Idade;
GO

--Converteu a data de nascimento do usu�rio para o formato (mm-dd-yyyy) na exibi��o
SELECT  NomeUsuario 'Nome', FORMAT (DataNascimento, 'dd-MM-yyyy') 'Data Nascimento' FROM Paciente 
INNER JOIN Usuario
ON Usuario.IdUsuario = Paciente.IdUsuario

--Mostrou a quantidade de usu�rios ap�s realizar a importa��o do banco de dados
SELECT COUNT(IdUsuario) 'Quantidade de usu�rios' FROM Usuario;
GO

SELECT * FROM Consulta

SELECT * FROM Situacao

UPDATE Consulta
SET IdMedico = 3,
IdPaciente = 3,
IdSituacao = 2,
DataeHora = '20/10/2020 13:00'
WHERE IdConsulta = 1003