SELECT * FROM Alugueis
SELECT * FROM Cliente
SELECT * FROM Empresa
SELECT * FROM Veiculos

USE Locadora

SELECT DataRetirada, DataEntrega, Veiculos.Modelos AS Modelo, Cliente.Nome AS Cliente FROM Alugueis
INNER JOIN Veiculos
ON Alugueis.idVeiculos = Veiculos.idVeiculos
INNER JOIN Cliente
ON Alugueis.idAlugueis = Cliente.idAlugueis

SELECT DataRetirada, DataEntrega, Veiculos.Modelos AS Modelo, Cliente.Nome AS Cliente FROM Alugueis
INNER JOIN Veiculos
ON Alugueis.idVeiculos = Veiculos.idVeiculos
INNER JOIN Cliente
ON Alugueis.idAlugueis = Cliente.idAlugueis
WHERE idCliente = 12


