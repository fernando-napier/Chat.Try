IF NOT EXISTS(SELECT * FROM sys.indexes WHERE Name = 'counter_userid_index')
	CREATE UNIQUE INDEX counter_userid_index ON chat.Counter (UserId);