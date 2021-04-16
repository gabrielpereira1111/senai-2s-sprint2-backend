CREATE DATABASE M_Peoples
GO

USE M_Peoples
GO

CREATE TABLE Funcionarios (
idFuncionarios				INT PRIMARY KEY IDENTITY
,Nome						VARCHAR(200) NOT NULL
,Sobrenome					VARCHAR(255) NOT NULL
)


ALTER TABLE Funcionarios
ADD dataNascimento DATE;

