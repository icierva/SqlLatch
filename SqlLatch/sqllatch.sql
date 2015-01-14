CREATE ASSEMBLY [System.Web] AUTHORIZATION dbo 
FROM 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.Web.dll'
WITH PERMISSION_SET = UNSAFE 

CREATE ASSEMBLY [fastJSON] AUTHORIZATION dbo 
FROM 'C:\temp\fastJSON.dll'
WITH PERMISSION_SET = UNSAFE 

CREATE ASSEMBLY [LatchSDK] AUTHORIZATION dbo 
FROM 'C:\temp\LatchSDK.dll'
WITH PERMISSION_SET = UNSAFE 



-- Hay que crear el ensamblado del clr de Sql latch con UNSAFE

ALTER DATABASE [Prueba] SET TRUSTWORTHY ON 
GO

-- Trigger de Servidor

CREATE TRIGGER logon_trigger
ON ALL SERVER
FOR LOGON
AS
BEGIN
IF not (SUSER_NAME()= 'sa' or (select prueba.dbo.latchStatus())='on')
    ROLLBACK;

END;
go