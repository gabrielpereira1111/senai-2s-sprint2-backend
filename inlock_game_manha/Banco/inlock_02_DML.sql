USE inlock_games_manha
GO

INSERT INTO tipoUsuario (titulo)
VALUES					('Administrador')
				       ,('Cliente')
GO

INSERT INTO usuario (email, senha, idTipoUsuario)
VALUES				('admin@admin.com','admin', 1)
				   ,('cliente@cliente.com','cliente',2)
GO

INSERT INTO Estudio (nomeEstudio)
VALUES				('Blizzard')
				   ,('Rockstar Studios')
				   ,('Square Enix')
GO

INSERT INTO Jogo (nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Diablo 3','� um jogo que cont�m bastantea��o e � viciante, seja voc� um novato ou um f�','15/05/2012',99.00,1)
				,('Red Dead Redemption II','jogo eletr�nico de a��o-aventura western','26/10/2018',120.00,2)
GO

