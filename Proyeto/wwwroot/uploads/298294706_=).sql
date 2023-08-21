select* from dbo.Autor
select* from dbo.Estudios_R
select* from dbo.HistorialDoc
select* from dbo.Usuario
go

use SisCADTIC
go
CREATE TABLE [dbo].[HistorialDoc](
	[IdAutor] [int] NULL,
	[TipoDoc] [varchar](20) NULL,
	[IdDoc] [int] NULL,
	[Fecha] [date] NULL,
	[Accion] [varchar](10) NULL,
	[Nombre] [varchar](100) NULL,
	[NombreDocMat] [varchar](50) NULL
);
GO


--agregar y eliminar en estudios r
create trigger tr_DocuemntoSubDel_Estudio on dbo.Estudios_R after insert, delete
as
begin
declare @IdEstudio_R int
declare @IdAutor int
declare @NombreAu varchar(40)
declare @ApePaterno varchar(15)
declare @ApeMaterno varchar(15)
declare @NombreDoc varchar(50)
if exists (select IdEstudio_R from inserted)
	begin
		select @IdEstudio_R = IdEstudio_R, @IdAutor = IdAutor1, @NombreDoc = NombreCurso from inserted
		select @NombreAu = Nombre, @ApePaterno = ApePaterno, @ApeMaterno = ApeMaterno from dbo.Autor where IdAutor = @IdAutor
		insert into dbo.HistorialDoc values(@IdAutor,'EstudioR' ,@IdEstudio_R, GETDATE(), 'Subir',@NombreAu+' '+@ApePaterno+' '+@ApeMaterno, @NombreDoc)
	end
if exists (select IdEstudio_R from deleted)
	begin
		select @IdEstudio_R = IdEstudio_R, @IdAutor = IdAutor1, @NombreDoc = NombreCurso from deleted
		select @NombreAu = Nombre, @ApePaterno = ApePaterno, @ApeMaterno = ApeMaterno from dbo.Autor where IdAutor = @IdAutor
		insert into dbo.HistorialDoc values(@IdAutor,'EstudioR', @IdEstudio_R ,GETDATE(), 'Eliminar', @NombreAu+' '+@ApePaterno+' '+@ApeMaterno, @NombreDoc)
	end
end
go


--materia im
create trigger tr_DocuemntoSubDel_Materia on dbo.MateriaImpartida after insert, delete
as
begin
declare @IdMateria int
declare @IdAutor int
declare @NombreAu varchar(40)
declare @ApePaterno varchar(15)
declare @ApeMaterno varchar(15)
declare @NombreMat varchar(70)
declare @IdAdminMateria int
if exists (select IdMateria from inserted)
	begin
		select @IdMateria = IdMateria, @IdAutor = IdAutor1 from inserted
		select @NombreAu = Nombre, @ApePaterno = ApePaterno, @ApeMaterno = ApeMaterno from dbo.Autor where IdAutor = @IdAutor
		select @NombreMat = NombreMat from dbo.AdminMateria where @IdAdminMateria = @IdAdminMateria
		insert into dbo.HistorialDoc values(@IdAutor, 'MateriaImpartida' ,@IdMateria, GETDATE(), 'Subir', @NombreAu+' '+@ApePaterno+' '+@ApeMaterno, @NombreMat)
	end
if exists (select IdMateria from deleted)
	begin
		select @IdMateria = IdMateria, @IdAutor = IdAutor1 from deleted
		select @NombreAu = Nombre, @ApePaterno = ApePaterno, @ApeMaterno = ApeMaterno from dbo.Autor where IdAutor = @IdAutor
		insert into dbo.HistorialDoc values(@IdAutor,'MateriaImpartida', @IdMateria ,GETDATE(), 'Eliminar', @NombreAu+' '+@ApePaterno+' '+@ApeMaterno, @NombreMat)
	end
end


insert into HistorialDoc values(1,'MateriaImpartida',2,'2023-08-18','Subir','Juan','hola')



CREATE PROCEDURE sp_ListarHistorialDoc
AS
BEGIN
		SELECT * FROM HistorialDoc
END