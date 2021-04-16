USE Filmes

SELECT * FROM Filmes
SELECT * FROM Generos
SELECT * FROM Usuarios

SELECT Titulo, Nome  FROM Filmes
INNER JOIN Generos
ON Generos.idGenero = Filmes.idGenero

SELECT idFilmes, idGenero, Titulo FROM Filmes 
WHERE idFilmes = 2

SELECT idUsuario, email, senha, tipoUsuario FROM Usuarios 
WHERE email = 'admin@admin.com' AND senha = '123'
