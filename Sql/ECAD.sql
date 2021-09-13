--begin transaction

--create table AUTHOR (
--	ID_AUTHOR int not null primary key identity,
--	NAME varchar(200),
--	CREATED datetime not null
--)

--create table MUSIC_AUTHOR (
--	ID_AUTHOR int not null,
--	ID_MUSIC int not null,
--	CREATED datetime not null
--)

--create table MUSIC (
--	ID_MUSIC int not null primary key identity,
--	NAME varchar(200),
--	CREATED datetime not null,
--	ID_TYPE_MUSIC INT NOT NULL
--)

--create table TYPE_MUSIC (
--	ID_TYPE int not null primary key identity,
--	NAME varchar(200),
--	CREATED datetime not null
--)

--create table CATEGORY (
--	ID_CATEGORY int not null primary key identity,
--	NAME varchar(200),
--	CREATED datetime not null
--)

--go
--alter table MUSIC_AUTHOR
--add constraint FK_AUTHOR_AUTHORID Foreign Key (ID_AUTHOR) references AUTHOR (ID_AUTHOR)
--alter table MUSIC_AUTHOR
--add constraint FK_MUSIC_MUSICID Foreign Key (ID_MUSIC) references MUSIC (ID_MUSIC)

--alter table MUSIC
--add constraint FK_MUSICTYPE_MUSICTYPEID Foreign Key (ID_TYPE_MUSIC) references TYPE_MUSIC (ID_TYPE)

--alter table AUTHOR
--add constraint FK_CATEGORY_CATEGORYID Foreign Key (ID_CATEGORY) references CATEGORY (ID_CATEGORY)

--alter table AUTHOR
--add ID_CATEGORY int

--INSERT INTO TYPE_MUSIC VALUES ('Axé', GETDATE())
--INSERT INTO TYPE_MUSIC VALUES ('Black Music.', GETDATE())
--INSERT INTO TYPE_MUSIC VALUES ('Blues.', GETDATE())
--INSERT INTO TYPE_MUSIC VALUES ('Bossa Nova.', GETDATE())
--INSERT INTO TYPE_MUSIC VALUES ('Chillout.', GETDATE())
--INSERT INTO TYPE_MUSIC VALUES ('Classic Rock.', GETDATE())
--INSERT INTO TYPE_MUSIC VALUES ('Clássico.', GETDATE())
--INSERT INTO TYPE_MUSIC VALUES ('Country.', GETDATE())


--INSERT INTO CATEGORY VALUES ('Compositor', GETDATE())
--INSERT INTO CATEGORY VALUES ('Autor', GETDATE())
--INSERT INTO CATEGORY VALUES ('intérprete', GETDATE())
--INSERT INTO CATEGORY VALUES ('músico', GETDATE())


--commit

----rollback


