create database TeachMe;

 use TeachMe;

CREATE TABLE Categorias(
Id INT NOT NULL IDENTITY(1,1),
Nombre NVARCHAR (50) NOT NULL,
Clasificacion NVARCHAR (50) NOT NULL,
PRIMARY KEY (Id)
);
CREATE TABLE Blogs(
Id INT NOT NULL IDENTITY(1,1),
Autor  nvarchar(100) not null,
IdCategorias INT NOT NULL,
Nombre NVARCHAR (100) NOT NULL,
Descripcion NVARCHAR (200) NOT NULL,
Contenido NVARCHAR (4000) NOT NULL,
FechaCreacion NVARCHAR (20) NOT NULL,
ImagenDescripcion NVARCHAR (500) NOT NULL,
ImagenContenido NVARCHAR (500) NOT NULL,
FOREIGN KEY (IdCategorias) REFERENCES Categorias (Id),
PRIMARY KEY (Id)
);


insert into Blogs (Autor, IdCategorias, Nombre, Descripcion, Contenido, FechaCreacion, ImagenDescripcion, ImagenContenido) 
values ('Byron Marinero',2, 'Trading en la zona','mejora tu estrategia','aqui va el contenido','15-03-2023','https://m.media-amazon.com/images/I/51A45j8MO-L._SY346_.jpg','https://d31dn7nfpuwjnm.cloudfront.net/images/valoraciones/0041/0542/Trading_foro.png?1606858162');

GO
CREATE TABLE Cursos(
Id INT NOT NULL IDENTITY(1,1),
Autor  nvarchar(100) not null,
IdCategorias INT NOT NULL,
Nombre NVARCHAR (100) NOT NULL,
Descripcion NVARCHAR (200) NOT NULL,
Precio NVARCHAR (100) NOT NULL,
PrecioAnterior NVARCHAR (100),
Link NVARCHAR (200) NOT NULL,
Duracion NVARCHAR (50) NOT NULL,
Requisitos NVARCHAR (300) NOT NULL,
FechaCreacion NVARCHAR (20) NOT NULL,
FechaActualizacion NVARCHAR (20) NOT NULL,
Imagen NVARCHAR (500) NOT NULL,
FOREIGN KEY (IdCategorias) REFERENCES Categorias (Id),
PRIMARY KEY (Id)
);
GO
CREATE TABLE Libros(
Id INT NOT NULL IDENTITY(1,1),
Autor nvarchar (100) not null,
IdCategorias INT NOT NULL,
Nombre NVARCHAR (100) NOT NULL,
Descripcion NVARCHAR (200) NOT NULL,
Precio NVARCHAR (100) NOT NULL,
PrecioAnterior NVARCHAR (100),
Link NVARCHAR (200) NOT NULL,
Editorial NVARCHAR (50) NOT NULL,
Edicion INT NOT NULL,
FechaPublicacion NVARCHAR (10) NOT NULL,
CantidadPag INT NOT NULL,
Imagen NVARCHAR (100) NOT NULL,
FOREIGN KEY (IdCategorias) REFERENCES Categorias (Id),
PRIMARY KEY (Id)
);
GO

CREATE TABLE CredencialesPagos(
Id INT NOT NULL IDENTITY(1,1),
NumeroTarjeta NVARCHAR (18) NOT NULL,
Marca NVARCHAR (100) NOT NULL,
Pais NVARCHAR (50) NOT NULL,
CVC INT NOT NULL,
FechaCreacion NVARCHAR (10) NOT NULL,
FechaVencimiento NVARCHAR (10) NOT NULL
PRIMARY KEY (Id)
);
GO
--inicio de tablas agregadas para el segundo sprint--
create table Roles(
Id int not null identity(1,1),
Nombre nvarchar(30) not null,
primary key(Id)
);
go
create table Usuarios(
Id int not null identity (1,1),
RolId int not null,
Nombre nvarchar(30) not null,
Apellido nvarchar(30) not null,
[Login] nvarchar(25) not null,
[Password] nchar(50) not null,
Estatus tinyint not null,
FechaRegistro datetime not null,
Primary Key(Id),
foreign key(RolId )references Roles(Id),
);
GO
--fin de tablas agregadas para el segundo sprint--


CREATE TABLE Compras(
Id INT NOT NULL IDENTITY(1,1),
IdUsuario INT NOT NULL,
IdCredencialesPagos INT NOT NULL,
IdCurso INT NOT NULL,
Monto INT NOT NULL,
FechaCompra NVARCHAR (10)  NOT NULL,
FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id),
FOREIGN KEY (IdCredencialesPagos) REFERENCES CredencialesPagos (Id),
FOREIGN KEY (IdCurso) REFERENCES Cursos (Id),
PRIMARY KEY (Id)
);
GO
CREATE TABLE ComprasLibros(
Id INT NOT NULL IDENTITY(1,1),
IdUsuario INT NOT NULL,
IdCurso INT NOT NULL,
IdCredencialesPagos INT NOT NULL,
Monto INT NOT NULL,
FechaCompra NVARCHAR (10)  NOT NULL,
FOREIGN KEY (IdCredencialesPagos) REFERENCES CredencialesPagos (Id),
FOREIGN KEY (IdUsuario) REFERENCES Usuarios (Id),
FOREIGN KEY (IdCurso) REFERENCES Cursos (Id),
PRIMARY KEY (Id)
);


select *from Usuarios;

insert into Roles (Nombre) values ('Usuario');

insert into Usuarios (RolId,Nombre,Apellido,[Login],[Password],Estatus,FechaRegistro) values (2,'Jose','Perez','jp','07215ef5d2943dad30887d55e0cc3074',1, SYSDATETIME());