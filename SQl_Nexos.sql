create database Nexos
go
use Nexos
go

create table Libro(
IdLibro int identity (1,1) primary key,
Titulo varchar (30),
Año date,
Genero varchar (30),
NumeroPagina int,
IdAutor int
)

insert into Libro(Titulo, Año, Genero, NumeroPagina, IdAutor)
values
('Cien Años de soledad', '1998/01/01', 'Drama', 300, 1),
('La bruja', '2000/01/01', 'Terror', 500, 2),
('Cuentos de los hermanos green', '1995/01/01', 'Infantil', 700, 3)

create table Autores(
IdAutor int Identity(1,1) primary key,
Nombres varchar (30),
FechaNacimiento date,
CiudadNacimiento varchar(30),
Correo varchar(30))

insert into Autores(Nombres, FechaNacimiento, CiudadNacimiento, Correo)
values 
('Gabriel Garcia Maquez', '1961/12/10', 'Aracataca', 'gabriel@hotmail.com'),
('German Castro Caycedo', '1983/10/10', 'Lima', 'German@hotmail.com'),
('Rafael Pomvo', '1970/09/30', 'Buenos aires', 'Rafael@hotmail.com')