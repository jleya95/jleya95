USE master
GO

--drop database if it exists
IF DB_ID('record_collection') IS NOT NULL
BEGIN
	ALTER DATABASE record_collection SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE record_collection;
END

CREATE DATABASE record_collection
GO

USE record_collection
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE records (
record_id int IDENTITY(1,1) NOT NULL,
[file] nvarchar(max) NULL,
artist nvarchar(max) NULL,
title nvarchar(max) NULL,
release_year int NULL,
[label] nvarchar(max) NULL,
issue_year int NULL,
serial_number nvarchar(max) NULL,
pressing nvarchar(max) NULL,
disc_number int NULL,
color nvarchar(max) NULL,
notes nvarchar(max) NULL,
needle_info nvarchar(max) NULL
)

--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO