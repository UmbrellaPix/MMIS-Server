IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='members' AND xtype='U')
	CREATE TABLE members(
	id int IDENTITY(1,1) NOT NULL,
    first_name VARCHAR(1000) NOT NULL,
    last_name VARCHAR(1000) NOT NULL,
    age INT NOT NULL,
    member_login VARCHAR(1000) UNIQUE NOT NULL,
    member_password VARCHAR(1000) NOT NULL
	)
go

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='messages' AND xtype='U')
	CREATE TABLE messages(
	id int IDENTITY(1,1) NOT NULL,
	member_id INT NOT NULL,
	date_time VARCHAR(1000) NOT NULL,
	content VARCHAR(1000) NOT NULL
	)
go

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='sessions' AND xtype='U')
	CREATE TABLE sessions(
	id int IDENTITY(1,1) NOT NULL,
	uuid VARCHAR(1000) NOT NULL,
	date_deactivation VARCHAR(1000) NOT NULL,
	member_id INT NOT NULL
	)
go

