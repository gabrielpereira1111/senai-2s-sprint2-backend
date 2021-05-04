--CRIA O BANCO DE DADOS "SP_MED_GROUP"
CREATE DATABASE SP_MED_GROUP;
GO 
--"GO" DEFINE A ORDEM DE EXECU��O DO SCRIPT

--"ENTRA" NO BD "SP_MED_GROUP"
USE SP_MED_GROUP;
GO

--UNIQUE significa que o valor s� pode ser registrado de forma �nica 

--Cria a tabela "especialidades", estabelecendo as suas colunas
CREATE TABLE especialidades
(
	idespecialidades	INT PRIMARY KEY IDENTITY
	,nome				VARCHAR(200) NOT NULL
);
GO

--Cria a tabela "clinicas", estabelecendo as suas colunas
CREATE TABLE clinicas
(
	idclinicas			INT PRIMARY KEY IDENTITY
	,nomeFantasia		VARCHAR(200) NOT NULL
	,razaoSocial		VARCHAR(200) UNIQUE NOT NULL
	,CNPJ				CHAR(20) UNIQUE NOT NULL
	,endereco			VARCHAR(200) UNIQUE NOT NULL
);
GO

--Cria a tabela "tiposUsuarios", estabelecendo as suas colunas
CREATE TABLE tiposUsuarios
(
	idtiposUsuarios		INT PRIMARY KEY IDENTITY
	,tipo				VARCHAR(100) UNIQUE NOT NULL
);
GO

--Cria a tabela "usuarios", estabelecendo as suas colunas
CREATE TABLE usuarios
(
	idusuarios			INT PRIMARY KEY IDENTITY
	,idtiposUsuarios	INT FOREIGN KEY REFERENCES tiposUsuarios(idtiposUsuarios)
	,email				VARCHAR(200) UNIQUE NOT NULL
	,senha				VARCHAR(150) NOT NULL
);
GO

--Cria a tabela "medicos", estabelecendo as suas colunas
CREATE TABLE medicos
(
	idmedicos			INT PRIMARY KEY IDENTITY
	,idespecialidades	INT FOREIGN KEY REFERENCES especialidades(idespecialidades)
	,idclinicas			INT FOREIGN KEY REFERENCES clinicas(idclinicas)
	,idusuarios			INT FOREIGN KEY REFERENCES usuarios(idusuarios)		
);
GO

--Cria a tabela "pacientes", estabelecendo as suas colunas
CREATE TABLE pacientes
(
	idpacientes			INT PRIMARY KEY IDENTITY
	,idusuarios			INT FOREIGN KEY REFERENCES usuarios(idusuarios)
	,nome				VARCHAR(200) NOT NULL
	,dataNascimento		DATE NOT NULL
	,telefone			CHAR(20) NULL
	,RG					CHAR(20) NOT NULL
	,CPF				CHAR(20) UNIQUE NOT NULL
	,endereco			VARCHAR(200) NOT NULL
);
GO

--Cria a tabela "consultas", estabelecendo as suas colunas
CREATE TABLE consultas
(
	idconsultas			INT PRIMARY KEY IDENTITY
	,idmedicos			INT FOREIGN KEY REFERENCES medicos(idmedicos)
	,idpacientes		INT FOREIGN KEY REFERENCES pacientes(idpacientes)
	,dataConsulta		SMALLDATETIME NOT NULL
	,situacao			VARCHAR(100) NOT NULL
);
GO

--Altera os dados da tabela "medicos", adicionando as colunas "nome" e "CRM"
ALTER TABLE medicos
ADD nome	VARCHAR(200) NOT NULL
ALTER TABLE medicos
ADD CRM		CHAR(10) NOT NULL

GO


--Cria um procedimento que seleciona as consultas com base no medico e sua situa��o
CREATE PROCEDURE consulta(@Medico	VARCHAR(100), @Situacao		VARCHAR(100))
AS
SELECT P.nome AS Pacientes, M.nome AS [M�dicos], dataConsulta AS [Data da Consulta], situacao AS [Situa��o]  FROM consultas AS C 
INNER JOIN pacientes AS P
ON  C.idpacientes = P.idpacientes 
INNER JOIN medicos AS M
ON M.idmedicos = C.idmedicos 
WHERE M.nome = @Medico AND C.situacao = @Situacao
GO
--Executa esse procedimento, selecionando as consultas do m�dico Roberto Possarle que foram canceladas
EXEC consulta @Medico = 'Roberto Possarle', @Situacao = 'Cancelada'

GO
--Cria uma fun��o para estabelecer a idade de cada paciente
CREATE FUNCTION idade(@dataNascimento AS DATETIME)
RETURNS INT												--Retorna dados tipo inteiros
AS
BEGIN
DECLARE @Anos AS INT									--declara a vari�vel "Anos" como inteira
DECLARE @Aniversario AS DATETIME						--Declara a vari�vel "Anivers�rio" como data
DECLARE @Idade AS INT									--Declara a vari�vel "Idade" como inteira
SET @Anos = DATEDIFF(YY,@dataNascimento,GETDATE())		--Estabelece que a vari�vel "Anos" � a diferen�a entre a vari�vel "dataNascimento" com a data atual
SET @Aniversario = DATEADD(YY,@Anos,@dataNascimento)	--Estabelece que a vari�vel "Anivers�rio" � a soma entre a vari�vel "Anos" e a vari�vel "dataNascimento", sendo o ano atual
SET @Idade = @Anos -									--Estabelece que a vari�vel "Idade" � igual a diferen�a entre "Anos" e "Aniversario", caso "Anivers�rio" for maior que a data atual
	CASE
		WHEN @Aniversario > GETDATE() THEN 1
		ELSE 0
	END
RETURN @Idade											--Retorna a vari�vel "Idade"
END
GO

SELECT nome, dataNascimento, dbo.idade(dataNascimento) AS Idade FROM pacientes		--Seleciona a idade dos pacientes














