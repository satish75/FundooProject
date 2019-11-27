CREATE PROCEDURE [dbo].[SpAddNotes]
      @userId			VARCHAR(50),
	  @title			VARCHAR(50)=NULL,
      @description      VARCHAR(150)=NULL,
	  @color            VARCHAR(10), 
      @createdDate      DATETIME,
	  @modifiedDate     DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Notes(UserId,
	                  Title,
                      Description,
					  Color,
                      CreatedDate,
					  ModifiedDate) 
					  
					  VALUES(@userId ,
					         @title ,
                             @description ,
							 @color,
                             @createdDate,
							 @modifiedDate)
                     END
GO
