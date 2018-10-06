use master
create database Torbellino
use Torbellino
create table Raza(
	RazaID int IDENTITY(1,1) not null,
	Nombre nvarchar(60) not null,
	Detalle nvarchar(200) not null,
	CONSTRAINT PK_Raza PRIMARY KEY CLUSTERED
	( 
	    RazaID ASC
	)
)

create table Color(
	ColorID int IDENTITY(1,1) not null,
	Nombre nvarchar(60) not null,
	CONSTRAINT PK_Color PRIMARY KEY CLUSTERED
	( 
	    ColorID ASC
	)
)

create table Animal(
	AnimalID int IDENTITY(1,1) not null,
	Nombre nvarchar(60) not null,
	RazaID int not null,
	FechaNac DateTime,
	ColorID int not null,
	Peso int,
	Valor money,
	CONSTRAINT PK_Animal PRIMARY KEY CLUSTERED
	( 
	    AnimalID ASC
	)
)

ALTER TABLE Animal WITH CHECK ADD  CONSTRAINT FK_Animal_Color_ColorID FOREIGN KEY(ColorID)
REFERENCES Color (ColorID)
ON DELETE CASCADE

ALTER TABLE Animal CHECK CONSTRAINT FK_Animal_Color_ColorID

ALTER TABLE Animal  WITH CHECK ADD  CONSTRAINT FK_Animal_Raza_RazaID FOREIGN KEY(RazaID)
REFERENCES Raza (RazaID)
ON DELETE CASCADE

ALTER TABLE Animal CHECK CONSTRAINT FK_Animal_Raza_RazaID





