IF (NOT EXISTS(
    SELECT 1
    FROM information_schema.referential_constraints 
    WHERE constraint_name  = 'FK_Counter_On_User'
))
BEGIN
    ALTER TABLE chat.Counter
	ADD CONSTRAINT FK_Counter_On_User
	FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id);
END
	