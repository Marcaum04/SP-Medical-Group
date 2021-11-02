USE SPMED_MARCAUM;
GO

--Criou uma função para retornar a quantidade de médicos de uma determinada especialidade
SELECT COUNT(IdMedico)
FROM Medico
WHERE IdEspecialidade = 17
GO

--Criou uma função para retornar a quantidade de médicos de uma determinada especialidade
CREATE PROCEDURE P_Idade
AS  
SELECT  NomeUsuario, DATEDIFF(YEAR, (DataNascimento), GETDATE()) AS 'Idade'
FROM Paciente
INNER JOIN Usuario 
ON Paciente.IdUsuario = Usuario.IdUsuario
GO

EXEC P_Idade;
GO

--Converteu a data de nascimento do usuário para o formato (mm-dd-yyyy) na exibição
SELECT  NomeUsuario 'Nome', FORMAT (DataNascimento, 'dd-MM-yyyy') 'Data Nascimento' FROM Paciente 
INNER JOIN Usuario
ON Usuario.IdUsuario = Paciente.IdUsuario

--Mostrou a quantidade de usuários após realizar a importação do banco de dados
SELECT COUNT(IdUsuario) 'Quantidade de usuários' FROM Usuario;
GO

SELECT * FROM Consulta

SELECT * FROM Situacao

UPDATE Consulta
SET IdMedico = 3,
IdPaciente = 3,
IdSituacao = 2,
DataeHora = '20/10/2020 13:00'
WHERE IdConsulta = 1003