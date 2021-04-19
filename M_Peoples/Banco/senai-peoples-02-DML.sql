USE M_Peoples
GO

INSERT INTO Funcionarios (Nome, Sobrenome)
VALUES					 ('Catarina','Strada')
						,('Tadeu','Vitelli')
GO

UPDATE Funcionarios SET DataNascimento = '11-08-1980' WHERE idFuncionarios = 1
UPDATE Funcionarios SET DataNascimento = '02-11-1975' WHERE idFuncionarios = 2

					
GO

