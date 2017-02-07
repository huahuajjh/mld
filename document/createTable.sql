--author:jjh
--date:2015-07-24 17:40
--last modify:2015-07-24 17:40

use MLDGYM
go

--用户信息表 | user information table
create table tbUser
(
	id int primary key identity,	--用户表主键 | user table's PK
	userTel char(11) not null unique,	--用户联系方式-手机 | user's contact way
	pwd varchar(50) not null,	--密码 | password
	name nvarchar(50) null, --姓名 | name
	del	bit not null --删除标识 | delete flag
)
go

--团课预约表 | group course book table
create table tbGroupCourse
(
	id int primary key identity,	--表主键 | table PK
	name nvarchar(50) not null unique, --课程表名称 | course table's name
	courseDate date not null,	--课程开课日期 | course start date
	startTime time not null,	--课程开始时间 | course start time
	endTime time not null,	--课程结束时间 | course end time
	maxPersons int not null,	--课程预约最大人数 | course max persons
	img varchar(50) null,	--课程表头图片 | course head image
	addr nvarchar(50) not null, --上课地点 | study address
	del bit not null,	--删除标识 | delete flag
	descrp nvarchar(100) null --课程描述 | course description
)
go

--团课预约记录表 | group course book record
create table tbGroupCourseBookRecord
(
	id int primary key identity,	--表主键 | table PK
	userId int not null, --预约者id | subscriber's id
	grpCrsId int not null,	--团课表id | group course table id
	remarks	nvarchar(50) null,	--备注 | remarks
	del bit not null,	--删除标识 | delete flag
	bookState int --状态 | state()
)
go