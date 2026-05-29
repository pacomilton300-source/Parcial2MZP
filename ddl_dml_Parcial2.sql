CREATE DATABASE Parcial2MZP;
GO

USE master
GO

CREATE LOGIN usrparcial2 
WITH PASSWORD = '12345678',
DEFAULT_DATABASE = Parcial2MZP,
CHECK_EXPIRATION = OFF,
CHECK_POLICY = ON
GO

USE Parcial2MZP
GO

CREATE USER usrparcial2 
FOR LOGIN usrparcial2
GO

ALTER ROLE db_owner 
ADD MEMBER usrparcial2
GO

DROP TABLE IF EXISTS VentaDetalle;
DROP TABLE IF EXISTS Venta;

CREATE TABLE Canal(
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50),
    frecuencia VARCHAR(20),
    estado SMALLINT
);


CREATE TABLE Programa(
    id INT IDENTITY(1,1) PRIMARY KEY,
    idCanal INT,
    titulo VARCHAR(100),
    descripcion VARCHAR(250),
    duracion INT,
    productor VARCHAR(100),
    fechaEstreno DATE,
    estado SMALLINT,

    CONSTRAINT FK_Programa_Canal
    FOREIGN KEY(idCanal)
    REFERENCES Canal(id)
);

-- Insertar canales
INSERT INTO Canal (nombre, frecuencia, estado)
VALUES 
('Canal 7', 'VHF-7', 1),
('Canal Cultural', 'UHF-21', 1),
('Canal Deportes', 'UHF-15', 1);

-- Insertar programas asociados a los canales
INSERT INTO Programa (idCanal, titulo, descripcion, duracion, productor, fechaEstreno, estado)
VALUES
(1, 'Noticias de la Mañana', 'Resumen informativo diario', 60, 'Juan Pérez', '2026-05-01', 1),
(1, 'Cine Clásico', 'Películas clásicas de los años 80 y 90', 120, 'María López', '2026-05-10', 1),
(2, 'Documentales del Mundo', 'Exploración de culturas y naturaleza', 90, 'Carlos Gómez', '2026-05-15', 1),
(2, 'Arte y Cultura', 'Programa sobre arte contemporáneo', 45, 'Ana Torres', '2026-05-20', 1),
(3, 'Fútbol en Vivo', 'Transmisión de partidos nacionales', 120, 'Luis Fernández', '2026-05-25', 1),
(3, 'Deportes Extremos', 'Cobertura de deportes de aventura', 60, 'Pedro Ramírez', '2026-05-28', 1);

SELECT * FROM Programa;

SELECT * FROM canal;