CREATE DATABASE ClinicaDB
GO
USE ClinicaDB
GO

CREATE TABLE pacientes (
  id_paciente INT PRIMARY KEY IDENTITY (1,1),
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  dni VARCHAR(12) NOT NULL UNIQUE,
  fecha_nacimiento DATE NOT NULL,
  direccion VARCHAR(255) NOT NULL,
  email VARCHAR(255) UNIQUE NOT NULL,
  telefono VARCHAR(50),
  activo BIT NOT NULL DEFAULT 1,
  CONSTRAINT CHK_fecha_nacimiento CHECK (fecha_nacimiento <= GETDATE())
);

GO

CREATE TABLE profesionales (
  id_profesional INT PRIMARY KEY IDENTITY (1,1),
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  dni VARCHAR(12) NOT NULL UNIQUE,
  fecha_nacimiento DATE NOT NULL,
  direccion VARCHAR(255) NOT NULL,
  email VARCHAR(255) UNIQUE NOT NULL,
  telefono VARCHAR(50),
  matricula VARCHAR (20) NOT NULL,
  fecha_ingreso DATE NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  CONSTRAINT CHK_fecha_nacimiento_profesional CHECK (fecha_nacimiento <= GETDATE()),
  CONSTRAINT CHK_fecha_ingreso CHECK (fecha_ingreso <= GETDATE())
);

GO

CREATE TABLE administradores (
  id_administrador INT PRIMARY KEY IDENTITY (1,1),
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  fecha_ingreso DATE NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  CONSTRAINT CHK_fecha_ingreso_administrador CHECK (fecha_ingreso <= GETDATE())
);

GO

CREATE TABLE especialidades (
  id_especialidad INT PRIMARY KEY IDENTITY (1,1),
  nombre VARCHAR(100) NOT NULL UNIQUE,
  activo BIT NOT NULL DEFAULT 1
);

GO

CREATE TABLE instituciones (
  id_institucion INT PRIMARY KEY IDENTITY (1,1),
  nombre VARCHAR(100) NOT NULL UNIQUE,
  direccion VARCHAR(255) NOT NULL,
  fecha_apertura DATE NOT NULL,
  activo BIT NOT NULL DEFAULT 1,
  CONSTRAINT CHK_fecha_apertura CHECK (fecha_apertura <= GETDATE())
);

GO

CREATE TABLE profesionales_especialidades (
  id INT PRIMARY KEY IDENTITY (1,1),
  id_profesional INT NOT NULL,
  id_especialidad INT NOT NULL,
  FOREIGN KEY (id_profesional) REFERENCES profesionales (id_profesional),
  FOREIGN KEY (id_especialidad) REFERENCES especialidades (id_especialidad),
  CONSTRAINT UQ_profesional_especialidad UNIQUE (id_profesional, id_especialidad),
  activo BIT NOT NULL DEFAULT 1
);

GO

CREATE TABLE profesionales_instituciones (
  id INT PRIMARY KEY IDENTITY (1,1),
  id_profesional INT NOT NULL,
  id_institucion INT NOT NULL,
  FOREIGN KEY (id_profesional) REFERENCES profesionales (id_profesional),
  FOREIGN KEY (id_institucion) REFERENCES instituciones (id_institucion),
  CONSTRAINT UQ_profesional_institucion UNIQUE (id_profesional, id_institucion),
  activo BIT NOT NULL DEFAULT 1
);

GO

CREATE TABLE turnos (
  id_turno INT PRIMARY KEY IDENTITY (1,1),
  id_paciente INT NOT NULL,
  id_profesional INT NOT NULL,
  id_especialidad INT NOT NULL, 
  id_institucion INT NOT NULL,
  fecha DATE NOT NULL,
  hora TIME  NOT NULL,
  observaciones VARCHAR (MAX),
   estado VARCHAR(20) NOT NULL DEFAULT 'disponible' CHECK (
    estado IN ('disponible', 'reservado', 'cancelado')
  ),
  FOREIGN KEY (id_paciente) REFERENCES pacientes (id_paciente),
  FOREIGN KEY (id_profesional) REFERENCES profesionales (id_profesional),
  FOREIGN KEY (id_especialidad) REFERENCES especialidades (id_especialidad),
  FOREIGN KEY (id_institucion) REFERENCES instituciones (id_institucion),
  CONSTRAINT CHK_fecha CHECK (fecha >= GETDATE())
 );

 GO


CREATE TABLE usuarios (
  id_usuarios INT PRIMARY KEY IDENTITY (1,1),
  usuario VARCHAR(100) UNIQUE NOT NULL,
  contraseña VARCHAR(255) NOT NULL,
  tipo_usuario VARCHAR(20) NOT NULL CHECK (
    tipo_usuario IN ('paciente', 'profesional', 'administrador')
  ),
  id_paciente INT,
  id_profesional INT,
  id_administrador INT,
  activo BIT NOT NULL DEFAULT 1,
  FOREIGN KEY (id_paciente) REFERENCES pacientes (id_paciente),
  FOREIGN KEY (id_profesional) REFERENCES profesionales (id_profesional),
  FOREIGN KEY (id_administrador) REFERENCES administradores (id_administrador),
  CONSTRAINT CK_tipo_usuario_valido CHECK (
    (tipo_usuario = 'paciente' AND id_paciente IS NOT NULL AND id_profesional IS NULL AND id_administrador IS NULL) OR
    (tipo_usuario = 'profesional' AND id_profesional IS NOT NULL AND id_paciente IS NULL AND id_administrador IS NULL) OR
    (tipo_usuario = 'administrador' AND id_administrador IS NOT NULL AND id_paciente IS NULL AND id_profesional IS NULL)
  )
);

GO

INSERT INTO pacientes (nombre, apellido, dni, fecha_nacimiento, direccion, email, telefono, activo)
VALUES
('Juan', 'Pérez', '12345678', '1990-05-20', 'Calle Ficticia 123', 'juanperez@example.com', '1112345678', 1),
('Ana', 'Gómez', '23456789', '1985-03-15', 'Avenida Libertador 456', 'anagomez@example.com', '1123456789', 1),
('Carlos', 'Díaz', '34567890', '1980-01-10', 'Calle Sol 789', 'carlosdiaz@example.com', '1134567890', 1),
('María', 'Martínez', '45678901', '1995-07-25', 'Avenida Córdoba 101', 'mariamartinez@example.com', '1145678901', 1),
('Pedro', 'Lopez', '56789012', '1988-11-30', 'Calle Luna 202', 'pedrolopez@example.com', '1156789012', 1);

GO

INSERT INTO profesionales (nombre, apellido, dni, fecha_nacimiento, direccion, email, telefono, matricula, fecha_ingreso, activo)
VALUES
('María', 'Sánchez', '12345678', '1980-02-20', 'Calle Nueva 123', 'mariasanchez@example.com', '1123456789', 'MATRICULA001', '2010-03-12', 1),
('Luis', 'Torres', '23456789', '1975-08-15', 'Avenida 9 de Julio 456', 'luistorres@example.com', '1134567890', 'MATRICULA002', '2012-06-01', 1),
('Laura', 'Fernández', '34567890', '1985-01-22', 'Calle Libertad 789', 'laurafernandez@example.com', '1145678901', 'MATRICULA003', '2014-09-05', 1),
('Fernando', 'Pérez', '45678901', '1990-12-11', 'Calle de la Paz 101', 'fernandoperez@example.com', '1156789012', 'MATRICULA004', '2016-11-17', 1),
('Gabriela', 'González', '56789012', '1992-03-14', 'Avenida Santa Fe 202', 'gabrielagonzalez@example.com', '1167890123', 'MATRICULA005', '2018-02-18', 1);

GO

INSERT INTO administradores (nombre, apellido, fecha_ingreso, activo)
VALUES
('Carlos', 'Ramírez', '2015-06-20', 1),
('Laura', 'Vega', '2016-04-12', 1),
('José', 'Martínez', '2014-09-30', 1),
('Raquel', 'Álvarez', '2017-01-08', 1),
('Patricia', 'Gómez', '2019-03-05', 1);

GO

INSERT INTO especialidades (nombre, activo)
VALUES
('Cardiología', 1),
('Dermatología', 1),
('Pediatría', 1),
('Ginecología', 1),
('Neurología', 1);

GO

INSERT INTO instituciones (nombre, direccion, fecha_apertura, activo)
VALUES
('Hospital Central', 'Avenida 9 de Julio 1000', '2005-03-10', 1),
('Clínica San Juan', 'Calle San Juan 2500', '2010-06-15', 1),
('Instituto Médico Los Andes', 'Avenida de los Andes 1200', '2012-11-21', 1),
('Centro de Salud Zona Norte', 'Calle Norte 300', '2015-09-01', 1),
('Clínica del Sol', 'Avenida Sol 400', '2018-04-30', 1);

GO

INSERT INTO profesionales_especialidades (id_profesional, id_especialidad, activo)
VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1),
(4, 4, 1),
(5, 5, 1);

GO

INSERT INTO profesionales_instituciones (id_profesional, id_institucion, activo)
VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1),
(4, 4, 1),
(5, 5, 1);

GO

INSERT INTO turnos (id_paciente, id_profesional, id_especialidad, id_institucion, fecha, hora, observaciones, estado)
VALUES
(2, 1, 1, 1, '2024-12-14', '09:00', 'Revisión de rutina', 'disponible'),
(2, 2, 2, 2, '2024-11-12', '11:30', 'Consulta dermatológica', 'disponible'),
(3, 3, 3, 3, '2024-11-14', '09:00', 'Revisión pediátrica', 'reservado'),
(4, 4, 4, 4, '2024-11-15', '13:00', 'Consulta ginecológica', 'cancelado'),
(5, 5, 5, 5, '2024-11-17', '15:30', 'Revisión neurológica', 'disponible');

GO

INSERT INTO usuarios (usuario, contraseña, tipo_usuario, id_paciente, id_profesional, id_administrador, activo)
VALUES
('juanperez', 'password123', 'paciente', 1, NULL, NULL, 1),
('luistorres', 'password456', 'profesional', NULL, 2, NULL, 1),
('mariasanchez', 'password789', 'profesional', NULL, 1, NULL, 1),
('admin1', 'adminpass', 'administrador', NULL, NULL, 1, 1),
('admin2', 'adminpass2', 'administrador', NULL, NULL, 2, 1),
('anagomez', '123', 'paciente', 2, NULL, NULL, 1),
('carlosdiaz', '123', 'paciente', 3, NULL, NULL, 1),
('mariamartinez', '123', 'paciente', 4, NULL, NULL, 1),
('pedrolopez', '123', 'paciente', 5, NULL, NULL, 1),
('laurafernadez', '456', 'profesional', NULL, 3, NULL, 1),
('fernandoperez', '456', 'profesional', NULL, 4, NULL, 1),
('gabrielagonzalez', '456', 'profesional', NULL, 5, NULL, 1),
('admin3', '123', 'administrador', NULL, NULL, 3, 1),
('admin4', '123', 'administrador', NULL, NULL, 4, 1),
('admin5', '123', 'administrador', NULL, NULL, 5, 1);


GO

CREATE PROCEDURE SP_BAJA_LOGICA_PROFESIONAL
    @IDPROFESIONAL INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE turnos
    SET estado = 'cancelado'  
    WHERE id_profesional = @IDPROFESIONAL;

    UPDATE profesionales_especialidades
    SET activo = 0
    WHERE id_profesional = @IDPROFESIONAL;
    UPDATE profesionales_instituciones
    SET activo = 0
    WHERE id_profesional = @IDPROFESIONAL;
    UPDATE profesionales
    SET activo = 0
    WHERE id_profesional = @IDPROFESIONAL;
END

GO

CREATE PROCEDURE SP_AGREGAR_PROFESIONAL
    @NOMBRE VARCHAR(100),          
    @APELLIDO VARCHAR(100),        
    @DNI VARCHAR(12),              
    @FECHA_NACIMIENTO DATE,        
    @DIRECCION VARCHAR(255),       
    @EMAIL VARCHAR(255),           
    @TELEFONO VARCHAR(50),         
    @MATRICULA VARCHAR(20),        
    @FECHA_INGRESO DATE,           
    @ESPECIALIDADES NVARCHAR(MAX), 
    @INSTITUCIONES NVARCHAR(MAX),  
    @USUARIO VARCHAR(100),         
    @CONTRASENA VARCHAR(255),      
    @TIPO_USUARIO VARCHAR(20)      
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO profesionales (nombre, apellido, dni, fecha_nacimiento, direccion, email, telefono, matricula, fecha_ingreso, activo)
    VALUES (@NOMBRE, @APELLIDO, @DNI, @FECHA_NACIMIENTO, @DIRECCION, @EMAIL, @TELEFONO, @MATRICULA, @FECHA_INGRESO, 1);

    DECLARE @IDPROFESIONAL INT;
    SET @IDPROFESIONAL = SCOPE_IDENTITY();

    INSERT INTO usuarios (usuario, contraseña, tipo_usuario, id_profesional, activo)
    VALUES (@USUARIO, @CONTRASENA, @TIPO_USUARIO, @IDPROFESIONAL, 1);

    IF (@ESPECIALIDADES IS NOT NULL AND @ESPECIALIDADES <> '')
    BEGIN
        DECLARE @ESPECIALIDADID INT;
        DECLARE @POSI INT;
        
        WHILE LEN(@ESPECIALIDADES) > 0
        BEGIN
            SET @POSI = CHARINDEX(',', @ESPECIALIDADES);
            
            IF @POSI > 0
            BEGIN
                SET @ESPECIALIDADID = CAST(SUBSTRING(@ESPECIALIDADES, 1, @POSI - 1) AS INT);
                SET @ESPECIALIDADES = SUBSTRING(@ESPECIALIDADES, @POSI + 1, LEN(@ESPECIALIDADES));
            END
            ELSE
            BEGIN
                SET @ESPECIALIDADID = CAST(@ESPECIALIDADES AS INT);
                SET @ESPECIALIDADES = '';
            END
            INSERT INTO profesionales_especialidades (id_profesional, id_especialidad, activo)
            VALUES (@IDPROFESIONAL, @ESPECIALIDADID, 1);
        END
    END

    IF (@INSTITUCIONES IS NOT NULL AND @INSTITUCIONES <> '')
    BEGIN
        DECLARE @INSTITUCIONID INT;
        DECLARE @POS INT;
        
        WHILE LEN(@INSTITUCIONES) > 0
        BEGIN
            SET @POS = CHARINDEX(',', @INSTITUCIONES);
            
            IF @POS > 0
            BEGIN
                SET @INSTITUCIONID = CAST(SUBSTRING(@INSTITUCIONES, 1, @POS - 1) AS INT);
                SET @INSTITUCIONES = SUBSTRING(@INSTITUCIONES, @POS + 1, LEN(@INSTITUCIONES));
            END
            ELSE
            BEGIN
                SET @INSTITUCIONID = CAST(@INSTITUCIONES AS INT);
                SET @INSTITUCIONES = '';
            END
            
            INSERT INTO profesionales_instituciones (id_profesional, id_institucion, activo)
            VALUES (@IDPROFESIONAL, @INSTITUCIONID, 1);
        END
    END
END

GO

CREATE PROCEDURE SP_AGREGAR_ESPECIALIDAD
    @ESPECIALIDAD VARCHAR(100)
AS
BEGIN
    BEGIN TRY
       
        BEGIN TRANSACTION;
        
      
        INSERT INTO especialidades (nombre)
        VALUES (@ESPECIALIDAD)
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorNumber INT = ERROR_NUMBER();
        DECLARE @ErrorLine INT = ERROR_LINE();
        
        RAISERROR ('Error al intentar agregar especialidad. Error %d en la línea %d: %s', 
                   16, 1, @ErrorNumber, @ErrorLine, @ErrorMessage);
    END CATCH;
END;

GO

CREATE PROCEDURE SP_AGREGAR_INSTITUCION
    @NOMBRE_INSTITUCION VARCHAR(100),
    @FECHA_APERTURA DATE,
    @DIRECCION VARCHAR(200)
AS
BEGIN
    BEGIN TRY
       
        BEGIN TRANSACTION;
        
      
        INSERT INTO instituciones(nombre, fecha_apertura, direccion)
        VALUES (@NOMBRE_INSTITUCION, @FECHA_APERTURA, @DIRECCION);
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorNumber INT = ERROR_NUMBER();
        DECLARE @ErrorLine INT = ERROR_LINE();
        
        RAISERROR ('Error al intentar agregar institución. Error %d en la línea %d: %s', 
                   16, 1, @ErrorNumber, @ErrorLine, @ErrorMessage);
    END CATCH;
END;

GO

CREATE PROCEDURE SP_ELIMINAR_PACIENTE_PERSONA
    @ID_PACIENTE INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE pacientes
    SET activo = 0
    WHERE id_paciente = @ID_PACIENTE;

    UPDATE usuarios
    SET activo = 0
    WHERE id_paciente = @ID_PACIENTE AND tipo_usuario = 'paciente';

    UPDATE turnos
    SET estado = 'cancelado'
    WHERE id_paciente = @ID_PACIENTE AND estado <> 'cancelado';
END;

GO

CREATE PROCEDURE SP_AGREGAR_PACIENTE
    @NOMBRE VARCHAR(100),           
    @APELLIDO VARCHAR(100),         
    @DNI VARCHAR(12),               
    @FECHA_NACIMIENTO DATE,         
    @DIRECCION VARCHAR(255),        
    @EMAIL VARCHAR(255),            
    @TELEFONO VARCHAR(50),          
    @USUARIO VARCHAR(100),          
    @CONTRASENA VARCHAR(255) = NULL 
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO pacientes (nombre, apellido, dni, fecha_nacimiento, direccion, email, telefono, activo)
    VALUES (@NOMBRE, @APELLIDO, @DNI, @FECHA_NACIMIENTO, @DIRECCION, @EMAIL, @TELEFONO, 1);

    DECLARE @ID_PACIENTE INT;
    SET @ID_PACIENTE = SCOPE_IDENTITY();

    IF (@USUARIO IS NOT NULL AND @CONTRASENA IS NOT NULL)
    BEGIN
        INSERT INTO usuarios (usuario, contraseña, tipo_usuario, id_paciente, activo)
        VALUES (@USUARIO, @CONTRASENA, 'paciente', @ID_PACIENTE, 1);
    END
END;


GO

CREATE PROCEDURE SP_MODIFICAR_PACIENTE
    @ID_PACIENTE INT,                  
    @NOMBRE VARCHAR(100) = NULL,       
    @APELLIDO VARCHAR(100) = NULL,     
    @DNI VARCHAR(12) = NULL,           
    @FECHA_NACIMIENTO DATE = NULL,     
    @DIRECCION VARCHAR(255) = NULL,    
    @EMAIL VARCHAR(255) = NULL,        
    @TELEFONO VARCHAR(50) = NULL       
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM pacientes WHERE id_paciente = @ID_PACIENTE)
    BEGIN
        PRINT 'El paciente con el ID especificado no existe.';
        RETURN;
    END

    UPDATE pacientes
    SET 
        nombre = COALESCE(@NOMBRE, nombre),
        apellido = COALESCE(@APELLIDO, apellido),
        dni = COALESCE(@DNI, dni),
        fecha_nacimiento = COALESCE(@FECHA_NACIMIENTO, fecha_nacimiento),
        direccion = COALESCE(@DIRECCION, direccion),
        email = COALESCE(@EMAIL, email),
        telefono = COALESCE(@TELEFONO, telefono)
    WHERE id_paciente = @ID_PACIENTE;

END;

