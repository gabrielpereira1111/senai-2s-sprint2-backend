USE Filmes

SELECT * FROM Usuarios

INSERT INTO Filmes (idGenero, Titulo)
VALUES			   (1, 'Velozes e Furiosos')
				  ,(2, 'Indiana Jones')
				  ,(3, 'Titanic')

INSERT INTO Generos (Nome)
VALUES				('A��o')
				   ,('Aventura')
				   ,('Romance')
				   ,('Fic��o Cient�fica')

INSERT INTO Usuarios (email, senha, tipoUsuario)
VALUES				 ('gabriel@email','123','comum')
					,('admin@admin.com','123','administrador')