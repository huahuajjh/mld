--author:jjh
--date:2015-07-24 17:40
--last modify:2015-07-24 17:40

use MLDGYM
go

--�û���Ϣ�� | user information table
create table tbUser
(
	id int primary key identity,	--�û������� | user table's PK
	userTel char(11) not null unique,	--�û���ϵ��ʽ-�ֻ� | user's contact way
	pwd varchar(50) not null,	--���� | password
	name nvarchar(50) null, --���� | name
	del	bit not null --ɾ����ʶ | delete flag
)
go

--�ſ�ԤԼ�� | group course book table
create table tbGroupCourse
(
	id int primary key identity,	--������ | table PK
	name nvarchar(50) not null unique, --�γ̱����� | course table's name
	courseDate date not null,	--�γ̿������� | course start date
	startTime time not null,	--�γ̿�ʼʱ�� | course start time
	endTime time not null,	--�γ̽���ʱ�� | course end time
	maxPersons int not null,	--�γ�ԤԼ������� | course max persons
	img varchar(50) null,	--�γ̱�ͷͼƬ | course head image
	addr nvarchar(50) not null, --�Ͽεص� | study address
	del bit not null,	--ɾ����ʶ | delete flag
	descrp nvarchar(100) null --�γ����� | course description
)
go

--�ſ�ԤԼ��¼�� | group course book record
create table tbGroupCourseBookRecord
(
	id int primary key identity,	--������ | table PK
	userId int not null, --ԤԼ��id | subscriber's id
	grpCrsId int not null,	--�ſα�id | group course table id
	remarks	nvarchar(50) null,	--��ע | remarks
	del bit not null,	--ɾ����ʶ | delete flag
	bookState int --״̬ | state()
)
go