/*BEGIN TRANSACTION trans1
BEGIN TRY
INSERT INTO [User] (Firstname,Lastname,City,[Address],Birthdate,Username,Password,Lastlogin,Userrole,PhoneNumber,fk_SchoolId)
VALUES('bus22','bus','bus','bus','bus','bus','buspass','2001-01-01 00:00:00.000',1,111,1);
INSERT INTO [Parent] (Id)
VALUES(193);
COMMIT TRANSACTION trans1
END TRY
BEGIN CATCH
ROLLBACK TRANSACTION trans
return;
END CATCH*/

SELECT * FROM [User] WHERE [User].Firstname like 'Adam'