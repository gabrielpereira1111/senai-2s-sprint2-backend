insert into Empresa (Endereco, CNPJ)
values				('R.Dom Manuel - Vila Monumento, São Paulo - SP','53.421.499/002-12')

insert into Veiculos (idEmpresa, Placas, Modelos, Marcas)
values				 (1,'OLA-0123','Onix Plus 2021','Chevrolet')
					,(1,'HEL-4568','Jetta','Volkswagen')
					,(1,'ALD-7898','Mustang Black Shadow','Ford')
					,(1,'BIW-8895','Joy Plus','Chevrolet')
					,(1,'WLK-9710','Virtus','Volkswagen')
					,(1,'FUK-9855','Nissan Frontier','Nissan')
insert into Alugueis (DataRetirada, DataEntrega, ValorAluguel, idVeiculos)
values				 ('15-01-2021','10-02-2021',68.15 ,5)
					,('10-02-2021','28-02-2021',70.35 ,1)
					,('22-02-2021','10-03-2021',96.10 ,3)
					,('23-02-2021','15-03-2021',59.60 ,4)
insert into Cliente (Nome,Telefones,CPF,RG,idAlugueis)
values				 ('Manuel Silveira','(11) 98642-1144','313.656.639-96','50.527.271-2',2)
					,('Ingrid Guimarães','(11) 94623-1265','125.468.923-63','21.358.698-2',7)
					,('Lucas Oliveira','(11) 91534-4426','260.452.365-98','12.658.498-2',3)
					,('Gustavo Santos','(11) 98753-1574','110.235.684-65','10.356.795-2',4)


DELETE FROM Alugueis WHERE idAlugueis = 5
DELETE FROM Cliente WHERE idCliente = 14
DELETE FROM Cliente WHERE idCliente = 15
DELETE FROM Cliente WHERE idCliente = 16
DELETE FROM Cliente WHERE idCliente = 17

UPDATE	Alugueis
SET		idVeiculos = 6
WHERE	idAlugueis = 7



SELECT * FROM Cliente
SELECT * FROM Alugueis
SELECT * FROM Veiculos