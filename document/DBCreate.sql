--author:jjh
--date:2015-07-24 17:32
--last modify:2015-07-24 17:32
if exists(select * from sysdatabases where name = 'MLDGYM') drop database MLDGYM
go
create database MLDGYM
on
(
	name = MLDGYM_DB,
	filename = 'D:\document\gym\document\MLDGYM.mdf',
	size = 5mb,
	maxsize = 500mb,
	filegrowth = 4mb
)
log on
(
	name = MLDGYM_LOG,
	filename = 'D:\document\gym\document\MLDGYM.ldf',
	size = 1mb,
	maxsize = 100mb,
	filegrowth = 2mb
)