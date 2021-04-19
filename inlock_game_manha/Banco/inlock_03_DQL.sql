USE inlock_games_manha

SELECT * FROM usuario

SELECT * FROM Estudio

SELECT * FROM Jogo

SELECT nomeJogo, nomeEstudio FROM Jogo 
INNER JOIN Estudio
ON Jogo.idEstudio = Estudio.idEstudio

SELECT nomeJogo, nomeEstudio FROM Jogo 
RIGHT JOIN Estudio
ON Jogo.idEstudio = Estudio.idEstudio

SELECT email, senha, tipoUsuario.titulo FROM usuario 
INNER JOIN tipoUsuario
ON tipoUsuario.idTipoUsuario = usuario.idTipoUsuario

SELECT * FROM Jogo
WHERE idJogo = 2

SELECT * FROM Estudio
WHERE idEstudio = 2