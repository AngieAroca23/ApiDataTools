CREATE DATABASE DataTools
GO
USE DataTools
GO
CREATE TABLE TipoIdentificacion
(
    Id INT PRIMARY KEY IDENTITY(1,1),
	Descripcion VARCHAR(150)
); 
GO
CREATE TABLE Empresa
(
    NumeroDocumento INT PRIMARY KEY,
	TipoDocumento INT,
	NombreCompleto VARCHAR(500),
	Direccion  VARCHAR(150),
	Ciudad VARCHAR(50),
	Departamento VARCHAR(50),
	Pais VARCHAR(50),
	Telefono VARCHAR(15),
	FOREIGN KEY (TipoDocumento) REFERENCES TipoIdentificacion(Id)
); 
GO
CREATE TABLE RepresentanteLegal
(
    NumeroDocumento INT PRIMARY KEY,
	TipoDocumento INT,
    NombreCompleto VARCHAR(500),
	Direccion  VARCHAR(150),
	Ciudad VARCHAR(50),
	Departamento VARCHAR(50),
	Pais VARCHAR(50),
	Telefono VARCHAR(15),
	PlacaVehiculo VARCHAR(15),
	NumeroDocumentoEmp INT
	FOREIGN KEY (TipoDocumento) REFERENCES TipoIdentificacion(Id),
	FOREIGN KEY (NumeroDocumentoEmp) REFERENCES Empresa(NumeroDocumento)
);
GO
INSERT INTO TipoIdentificacion (Descripcion) VALUES ('Cédula Ciudadanía')
GO
INSERT INTO TipoIdentificacion (Descripcion) VALUES ('Nit')
GO
INSERT INTO TipoIdentificacion (Descripcion) VALUES ('Cédula Extranjeria')
GO
INSERT INTO TipoIdentificacion (Descripcion) VALUES ('Tarjeta Identidad')
GO
CREATE PROC INS_Empresa

@NumeroDocumento INT,
@TipoDocumento INT,
@NombreCompleto VARCHAR(500),
@Direccion  VARCHAR(150),
@Ciudad VARCHAR(50),
@Departamento VARCHAR(50),
@Pais VARCHAR(50),
@Telefono VARCHAR(15)
AS
BEGIN 

IF NOT EXISTS(SELECT TOP 1 * FROM Empresa WHERE NumeroDocumento = @NumeroDocumento)
BEGIN 
INSERT INTO Empresa
  (NumeroDocumento,
	TipoDocumento,
	NombreCompleto,
	Direccion,
	Ciudad,
	Departamento,
	Pais,
	Telefono)
  VALUES
  (@NumeroDocumento,
	@TipoDocumento,
	@NombreCompleto,
	@Direccion,
	@Ciudad,
	@Departamento,
	@Pais,
	@Telefono)
END
ELSE
UPDATE Empresa SET
    Direccion = @Direccion,
	Ciudad = @Ciudad,
	Departamento = @Departamento,
	Pais = @Pais,
	Telefono = @Telefono
WHERE NumeroDocumento = @NumeroDocumento
END
GO
CREATE PROC INS_RepresentanteLegal

@NumeroDocumento INT,
@TipoDocumento INT,
@NombreCompleto VARCHAR(500),
@Direccion  VARCHAR(150),
@Ciudad VARCHAR(50),
@Departamento VARCHAR(50),
@Pais VARCHAR(50),
@Telefono VARCHAR(15),
@PlacaVehiculo VARCHAR(15),
@NumeroDocumentoEmp INT
AS
BEGIN 

IF NOT EXISTS(SELECT TOP 1 * FROM RepresentanteLegal WHERE NumeroDocumento = @NumeroDocumento)
BEGIN 
INSERT INTO RepresentanteLegal
  (NumeroDocumento,
	TipoDocumento,
	NombreCompleto,
	Direccion,
	Ciudad,
	Departamento,
	Pais,
	Telefono,
	PlacaVehiculo,
	NumeroDocumentoEmp)
  VALUES
  (@NumeroDocumento,
	@TipoDocumento,
	@NombreCompleto,
	@Direccion,
	@Ciudad,
	@Departamento,
	@Pais,
	@Telefono,
	@PlacaVehiculo,
	@NumeroDocumentoEmp)
END
ELSE
UPDATE RepresentanteLegal 
SET Direccion = @Direccion,
	Ciudad = @Ciudad,
	Departamento = @Departamento,
	Pais = @Pais,
	Telefono = @Telefono,
	PlacaVehiculo = @PlacaVehiculo,
	NumeroDocumentoEmp = @NumeroDocumentoEmp
WHERE NumeroDocumento = @NumeroDocumento
END
GO
CREATE PROC QRY_ConsultaEmpresaDetalle
AS
BEGIN 
	SELECT R.PlacaVehiculo,  T.Descripcion TipoIdentificacionEmpresa, E.NumeroDocumento, E.NombreCompleto, COUNT(R.NumeroDocumento) Cantidad 
	FROM  RepresentanteLegal R 
	INNER JOIN Empresa E ON E.NumeroDocumento = R.NumeroDocumentoEmp
	INNER JOIN TipoIdentificacion T ON T.Id = E.TipoDocumento
	GROUP BY T.Descripcion, E.NumeroDocumento, E.NombreCompleto, R.PlacaVehiculo
	HAVING COUNT(R.NumeroDocumento) > 2
	ORDER BY R.PlacaVehiculo
END
GO
CREATE PROC QRY_ConsultaEmpresas
AS
BEGIN 
	SELECT NumeroDocumento, NombreCompleto FROM Empresa
END
GO
CREATE PROC QRY_ConsultaTipoIdentificacion
AS
BEGIN 
	SELECT Id, Descripcion FROM TipoIdentificacion
END