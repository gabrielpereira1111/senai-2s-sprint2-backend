USE SENAI_HROADS_MANHA

SELECT * FROM Personagens
SELECT * FROM Classes
SELECT Nome FROM Classes
SELECT * FROM Habilidades
SELECT * FROM TiposHabilidade
SELECT COUNT(*) AS [Quantidade de Habilidades] FROM Personagens

SELECT Habilidades.Nome, TiposHabilidade.Nome FROM Habilidades
INNER JOIN TiposHabilidade
ON Habilidades.idTipo = TiposHabilidade.idTipo

SELECT Classes.Nome AS Classes, Personagens.Nome AS Personagens FROM Personagens
INNER JOIN Classes
ON Classes.idClasses = Personagens.idClasses

SELECT Classes.Nome AS Classes, Personagens.Nome AS Personagens FROM Personagens
FULL OUTER JOIN Classes
ON Classes.idClasses = Personagens.idClasses

SELECT Classes.Nome AS Classes, Habilidades.Nome AS Habilidades FROM Classes
INNER JOIN ClassesHabilidades
ON Classes.idClasses = ClassesHabilidades.idClasses
INNER JOIN Habilidades
ON ClassesHabilidades.idHabilidades = Habilidades.idHabilidades

SELECT Classes.Nome AS Classes, Habilidades.Nome AS Habilidades FROM Classes
INNER JOIN ClassesHabilidades
ON Classes.idClasses = ClassesHabilidades.idClasses
INNER JOIN Habilidades
ON ClassesHabilidades.idHabilidades = Habilidades.idHabilidades

SELECT Classes.Nome AS Classes, Habilidades.Nome AS Habilidades FROM Classes
FULL OUTER JOIN ClassesHabilidades
ON Classes.idClasses = ClassesHabilidades.idClasses
FULL OUTER JOIN Habilidades
ON ClassesHabilidades.idHabilidades = Habilidades.idHabilidades


SELECT Nome FROM Classes ORDER BY Nome ASC

SELECT * FROM Personagens ORDER BY idClasses ASC


SELECT  * FROM    Personagens INNER JOIN    Classes ON Personagens.idClasses = Classes.idClasses ORDER BY Classes.Nome ASC

SELECT email, titulo FROM Usuarios AS U
INNER JOIN tipoUsuario AS TU
ON U.idTipoUsuario = TU.idTipoUsuario