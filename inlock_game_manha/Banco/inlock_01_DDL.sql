CREATE DATABASE inlock_games_manha
GO

USE inlock_games_manha
GO

CREATE TABLE Estudio
(
	idEstudio			INT PRIMARY KEY IDENTITY
	,nomeEstudio		VARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Jogo
(
	idJogo				INT PRIMARY KEY IDENTITY
	,nomeJogo			VARCHAR(50) NOT NULL UNIQUE
	,descricao			VARCHAR(300) NOT NULL
	,dataLancamento		DATE NOT NULL
	,valor				DECIMAL(5,2) NOT NULL
	,idEstudio			INT FOREIGN KEY REFERENCES Estudio(idEstudio)
);
GO


CREATE TABLE tipoUsuario
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,titulo				VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE usuario
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,email				VARCHAR(150) NOT NULL UNIQUE
	,senha				VARCHAR(100) NOT NULL
	,idTipoUsuario		INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
);
GO





