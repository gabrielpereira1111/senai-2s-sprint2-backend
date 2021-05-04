USE SP_MED_GROUP

SELECT * FROM clinicas			--Seleciona tudo da tabela "clinicas"
SELECT * FROM consultas			--Seleciona tudo da tabela "consultas"
SELECT * FROM especialidades	--Seleciona tudo da tabela "especialidades"
SELECT * FROM medicos			--Seleciona tudo da tabela "medicos"
SELECT * FROM pacientes			--Seleciona tudo da tabela "pacientes"
SELECT * FROM tiposUsuarios		--Seleciona tudo da tabela "tiposUsuarios"
SELECT * FROM usuarios			--Seleciona tudo da tabela "usuarios"


SELECT COUNT(idusuarios) AS [Quantidade de usuários] FROM usuarios		--Seleciona a quantidade de usuários da tabela "usuarios"

SELECT nome, U.email FROM pacientes AS P					--Seleciona o nome e o email dos pacientes
INNER JOIN usuarios AS U									--Faz a junção das tabelas "pacientes" e "usuários"
ON U.idusuarios = P.idusuarios								--Estabelece a relação entre as duas tabelas

SELECT P.nome AS Pacientes, M.nome AS [Médicos], dataConsulta AS [Data da Consulta], situacao AS [Situação]  FROM consultas AS C		--Seleciona os dados das consultas, retornando os pacientes, médicos, a sua data e situação
INNER JOIN pacientes AS P																												--Faz a junção com a tabela "pacientes"
ON  C.idpacientes = P.idpacientes																										--Estabelece a relação entre as duas tabelas
INNER JOIN medicos AS M																													--Faz a junção com a tabela "medicos"
ON M.idmedicos = C.idmedicos																											--Estabelece a relação entre as duas tabelas

SELECT M.nome AS [Médicos], E.nome AS Especialidades FROM medicos AS M				--Seleciona o nome e a especialidade dos medicos da tabela "medicos"
INNER JOIN especialidades AS E														--Faz a junção entre as tabelas "medicos" e "especialidades"
ON M.idespecialidades = E.idespecialidades											--Estabelece a relação entre as duas tabelas







