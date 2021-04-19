USE M_Peoples


SELECT * FROM Funcionarios


SELECT Nome, Sobrenome, DataNascimento FROM Funcionarios 
WHERE Nome = 'Catarina'

SELECT Nome, Sobrenome, DataNascimento FROM Funcionarios
ORDER BY Nome ASC

SELECT CONCAT(Nome, ' ',Sobrenome) AS [Nome Completo], DataNascimento FROM Funcionarios


SELECT idFuncionarios, CONCAT(Nome,' ',Sobrenome) AS [Nome Completo] FROM Funcionarios

