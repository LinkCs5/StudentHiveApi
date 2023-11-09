
create table Inquilino (
ID_Inquilino int not null primary key identity,
nombreInquilino varchar(250) not null,
Genero varchar (50),
NumeroTelefono varchar (100),
Edad int, 
);
go 

create table Arrendador(
ID_Anfitrion int not null primary key identity,
nombreAnfitrion varchar(250) not null,
Genero varchar (50),
NumeroTelefono varchar (100),
Edad int, 
);

create table Publicaciones (
ID_Publicacion int not null primary key identity,
Titulo varchar (500),
Imagenes varchar (250),
NumeroDeCuartos_Habitacion int, 
Ubicacion_Habitacion varchar (250),
Precio_Habitacion decimal(8,2),
FechaPublicacion datetime, 
Estatus varchar(255),
ID_Anfitrion int,
foreign key (ID_Anfitrion) references Arrendador (ID_Anfitrion)
);
go 

create table Reservas (
ID_Reserva int not null identity primary key, 
ID_Inquilino int, 
ID_Publicacion int, 
CantidadDeReservas int,
foreign key (ID_Inquilino) references Inquilino (ID_Inquilino),
foreign key (ID_Publicacion) references Publicaciones(ID_Publicacion)
);
go 

create table Match (
ID_Match int not null identity primary key,
ID_Reserva  int, 

);