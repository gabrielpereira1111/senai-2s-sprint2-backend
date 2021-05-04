USE SP_MED_GROUP;
GO

--Inseri os dados na tabela "clinicas"
INSERT INTO clinicas (nomeFantasia, razaoSocial, CNPJ, endereco)
VALUES				 ('Clinica Possarle ','SP Medical Group','86.400.902/0001-30','Av. Barão Limeira, 532, São Paulo, SP')

--Inseri os dados na tabela "especialidades"
INSERT INTO especialidades (nome)
 VALUES					   ('Acupuntura')
						  ,('Anestesiologia')
						  ,('Angiologia')
						  ,('Cardiologia')
						  ,('Cirurgia Cardiovascular')
						  ,('Cirurgia da Mão')
						  ,('Cirurgia do Aparelho Digestivo')
						  ,('Cirurgia Geral')
						  ,('Cirurgia Pediátrica')
						  ,('Cirurgia Plástica')
						  ,('Cirurgia Torácica')
						  ,('Cirurgia Vascular')
						  ,('Dermatologia')
						  ,('Radioterapia')
						  ,('Urologia')
						  ,('Pediatria')
						  ,('Psiquiatria')

--Inseri os dados na tabela "tiposUsuarios"
INSERT INTO  tiposUsuarios (tipo)
VALUES					   ('Administrador')
						  ,('Paciente')
						  ,('Medico')

--Inseri os dados na tabela "usuarios"
INSERT INTO usuarios (idtiposUsuarios, email, senha)
VALUES				 (3,'ricardo.lemos@spmedicalgroup.com.br','RLEMOS**7510')
					,(3,'roberto.possarle@spmedicalgroup.com.br','R.Possarle48622')
					,(3,'helena.souza@spmedicalgroup.com.br','Helena.Strada.22')
					,(1,'administrador.adm@spmedicalgroup.com.br','ADM-ADM**12858795')
					,(2,'alexandre@gmail.com','Alexxandre88//')
					,(2,'fernando@gmail.com','00-FeRnAnDo-00')
					,(2,'henrique@gmail.com','HENRIQUe-9-')
					,(2,'joao@hotmail.com','Joao**4*7')
					,(2,'bruno@gmail.com','Brunnooo55')
					,(2,'mariana@outlook.com','Mariana489*')
					,(2,'ligia@gmail.com','Ligia**1234')

--Inseri os dados na tabela "medicos"
INSERT INTO medicos (idespecialidades, idclinicas, idusuarios, nome, CRM)
VALUES				(2, 1, 1, 'Ricardo Lemos', '54356-SP')
				   ,(17, 1, 2, 'Roberto Possarle', '53452-SP')
				   ,(16, 1, 3, 'Helena Strada', '65463-SP')

--Inseri os dados na tabela "pacientes"
INSERT INTO pacientes (idusuarios, nome, dataNascimento, telefone, RG, CPF, endereco)
VALUES				  (11, 'Ligia', '13/10/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000')
					 ,(5, 'Alexandre', '23/7/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200')
					 ,(6 , 'Fernando', '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200')
					 ,(7 , 'Henrique', '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
					 ,(8 , 'João', '27/8/1975', '11 7656-6377', '532544444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380')
					 ,(9 , 'Bruno', '21/3/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001')
					 ,(10 , 'Mariana', '5/3/2018', '', '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140')

--Inseri os dados na tabela "consultas"
INSERT INTO consultas (idmedicos, idpacientes, dataConsulta, situacao)
VALUES				  (3, 7, '20/01/20 15:00', 'Realizada')
					 ,(2, 2, '06/01/20 10:00', 'Cancelada')
					 ,(2, 3, '07/02/20 11:00', 'Realizada')
					 ,(2, 2, '06/02/18 10:00', 'Realizada')
					 ,(1, 4, '07/02/19 11:00', 'Cancelada')
					 ,(3, 7, '08/03/20 15:00', 'Agendada')
					 ,(1, 4, '09/03/20 11:00', 'Agendada')


