USE MASTER
GO

CREATE DATABASE BDD_UFG
GO

USE BDD_UFG
GO

CREATE TABLE Persona (
    id int Primary Key,
    nombre varchar(50),
    correo varchar(50),
    fecha_nacimiento datetime
)