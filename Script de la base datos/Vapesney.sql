-- Crear la base de datos
CREATE DATABASE Vapesney;
GO

-- Usar la base de datos creada
USE Vapesney;
GO

-- Crear la tabla cliente
CREATE TABLE cliente
(
    clienteID INT PRIMARY KEY IDENTITY(1,1), -- ID auto incremental
    nombre NVARCHAR(100) NOT NULL,           -- Nombre del cliente
    apellido NVARCHAR(100) NOT NULL,         -- Apellido del cliente
    telefono NVARCHAR(15) NOT NULL           -- Teléfono del cliente
);
GO

-- Insertar datos de ejemplo
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('Jose', 'Alonso', '74723922');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('maicol', 'Alonso', '77777777');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('manuel', 'd', '77777');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('juan', 'leonidas', '44');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('Valentina', 'Ochoa', '48234920');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('marta', 'Montes', '93924832');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('maicol', 'Gutierres', '77777777');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('Carlos', 'Gutierres', '87876565');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('Chepe', 'Alonso', '74723922');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('marcas', 'Gutierres', '77777777');
INSERT INTO cliente (nombre, apellido, telefono) VALUES ('Vale', 'Ochoa', '48234920');
GO
