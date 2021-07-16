GO

    CREATE DATABASE [DbCounty]
GO
USE [DbCounty];

GO
PRINT N'Creating [dbo].[County]...';


GO
CREATE TABLE [dbo].[County] (
    [county_fips]                   INT           IDENTITY (1, 1) NOT NULL,
    [county_name]                   VARCHAR (250) NULL,
    [state_name]                    VARCHAR (250) NULL,
    [dateFech]                      DATE          NULL,
    [county_vmt]                    INT           NULL,
    [baseline_jan_vmt]              INT           NULL,
    [percent_change_from_jan]       FLOAT (53)    NULL,
    [mean7_county_vmt]              FLOAT (53)    NULL,
    [mean7_percent_change_from_jan] FLOAT (53)    NULL,
    [date_at_low]                   DATE          NULL,
    [mean7_county_vmt_at_low]       FLOAT (53)    NULL,
    [percent_change_from_low]       FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([county_fips] ASC)
);


GO
PRINT N'Creating [dbo].[SpInsertCounty]...';


GO
CREATE Procedure [dbo].[SpInsertCounty]
@county_name    varchar(250),
@state_name  varchar(250),
@dateFech        date,
@county_vmt     int, 
@baseline_jan_vmt    int ,
@percent_change_from_jan float ,
@mean7_county_vmt float,
@mean7_percent_change_from_jan float,
@date_at_low   date,
@mean7_county_vmt_at_low  float,
@percent_change_from_low  float			
as
BEGIN
Insert into  County 
values
(@county_name    				
,@state_name  					
,@dateFech        				
,@county_vmt     				
,@baseline_jan_vmt    			
,@percent_change_from_jan 		
,@mean7_county_vmt 
,@mean7_percent_change_from_jan 	
,@date_at_low   
,@mean7_county_vmt_at_low  		
,@percent_change_from_low )

Select @@IDENTITY as Resultado
END
GO
PRINT N'Creating [dbo].[SPSelectCounty]...';


GO

CREATE PROCEDURE SPSelectCounty
AS
BEGIN
SELECT *FROM  County
END
GO
PRINT N'Update complete.';


GO
