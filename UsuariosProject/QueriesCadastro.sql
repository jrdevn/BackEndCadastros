CREATE TABLE Usuario (
	UsuarioId int  IDENTITY(1,1) NOT NULL,
	Nome varchar(200) NOT NULL,
	DataNascimento DATETIME NOT NULL,
	Email varchar(100),
	Senha varchar(30),
	Ativo bit,
	SexoId int NOT NULL,
	PRIMARY KEY (UsuarioId),
	FOREIGN KEY (SexoId) REFERENCES Sexo(SexoId)
)

CREATE TABLE Sexo (
	SexoId int IDENTITY(1,1) NOT NULL,
	Descricao varchar(15) NOT NULL,
	PRIMARY KEY (SexoId)
)

insert into Sexo (Descricao) values ('Masculino');
insert into Sexo (Descricao) values ('Feminino');
