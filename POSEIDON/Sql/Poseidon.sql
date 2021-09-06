--Creamos la base de datos POSEIDON
CREATE DATABASE POSEIDON
GO
--Creamos un login para el usuario administrador
CREATE LOGIN PoseidonAdmin WITH PASSWORD = 'Pa$$w0rd'
GO
--Creamos un login para el usuario de lectura
CREATE LOGIN PoseidonSystem WITH PASSWORD = 'Pa$$w0rd'
GO
--Cambiamos a la base de datos
USE POSEIDON
GO
--Creamos los usuarios administrador y de sistema
CREATE USER PoseidonAdmin FOR LOGIN PoseidonAdmin;
CREATE USER PoseidonSystem FOR LOGIN PoseidonSystem;
--Agregamos el permiso al usuario administrador de db_owner el cual 
--tiene acceso total a la base de datos
ALTER ROLE db_owner ADD MEMBER PoseidonAdmin;
--Agregamos los roles de escritura y lectura para el 
--usuario de sistema
ALTER ROLE db_datareader ADD MEMBER PoseidonSystem;
ALTER ROLE db_datawriter ADD MEMBER PoseidonSystem;