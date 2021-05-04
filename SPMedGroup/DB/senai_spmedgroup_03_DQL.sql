USE SP_MED_GROUP

SELECT * FROM clinicas			--Seleciona tudo da tabela "clinicas"
SELECT * FROM consultas			--Seleciona tudo da tabela "consultas"
SELECT * FROM especialidades	--Seleciona tudo da tabela "especialidades"
SELECT * FROM medicos			--Seleciona tudo da tabela "medicos"
SELECT * FROM pacientes			--Seleciona tudo da tabela "pacientes"
SELECT * FROM tiposUsuarios		--Seleciona tudo da tabela "tiposUsuarios"
SELECT * FROM usuarios			--Seleciona tudo da tabela "usuarios"


SELECT COUNT(idusuarios) AS [Quantidade de usu�rios] FROM usuarios		--Seleciona a quantidade de usu�rios da tabela "usuarios"

SELECT nome, U.email FROM pacientes AS P					--Seleciona o nome e o email dos pacientes
INNER JOIN usuarios AS U									--Faz a jun��o das tabelas "pacientes" e "usu�rios"
ON U.idusuarios = P.idusuarios								--Estabelece a rela��o entre as duas tabelas

SELECT P.nome AS Pacientes, M.nome AS [M�dicos], dataConsulta AS [Data da Consulta], situacao AS [Situa��o]  FROM consultas AS C		--Seleciona os dados das consultas, retornando os pacientes, m�dicos, a sua data e situa��o
INNER JOIN pacientes AS P																												--Faz a jun��o com a tabela "pacientes"
ON  C.idpacientes = P.idpacientes																										--Estabelece a rela��o entre as duas tabelas
INNER JOIN medicos AS M																													--Faz a jun��o com a tabela "medicos"
ON M.idmedicos = C.idmedicos																											--Estabelece a rela��o entre as duas tabelas

SELECT M.nome AS [M�dicos], E.nome AS Especialidades FROM medicos AS M				--Seleciona o nome e a especialidade dos medicos da tabela "medicos"
INNER JOIN especialidades AS E														--Faz a jun��o entre as tabelas "medicos" e "especialidades"
ON M.idespecialidades = E.idespecialidades											--Estabelece a rela��o entre as duas tabelas







