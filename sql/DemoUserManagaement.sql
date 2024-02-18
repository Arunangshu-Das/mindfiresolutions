CREATE TABLE UserDetails (    UserID INT IDENTITY(1,1) PRIMARY KEY,    FirstName VARCHAR(255),    MiddleName VARCHAR(255),    LastName VARCHAR(255),    FatherFirstName VARCHAR(255),    FatherMiddleName VARCHAR(255),    FatherLastName VARCHAR(255),    MotherFirstName VARCHAR(255),    MotherMiddleName VARCHAR(255),    MotherLastName VARCHAR(255),    Email VARCHAR(255),	ContactNumber VARCHAR(15),    Gender VARCHAR(10),    DateOfBirth DATE,	Password varchar(255),    HighestEducation VARCHAR(255),    Branch VARCHAR(255),    YearOfPassout VARCHAR(255),    SecondarySchoolName VARCHAR(255),    HigherSecondarySchoolName VARCHAR(255),    BTechCollegeName VARCHAR(255),    MTechCollegeName VARCHAR(255),	SecondaryMarks VARCHAR(255),    HigherSecondaryMarks VARCHAR(255),    BTechMarks VARCHAR(255),    MTechMarks VARCHAR(255),	ProfilePhoto VARCHAR(255),	Aadharcard VARCHAR(255),	MyResume VARCHAR(255),	GuidProfilePhoto VARCHAR(255),	GuidAadharcard VARCHAR(255),	GuidMyResume VARCHAR(255),	AboutMyself VARCHAR(255),    Hobbies VARCHAR(MAX));Drop table AddressDetails;CREATE TABLE AddressDetails (    AddressID INT IDENTITY(1,1) PRIMARY KEY,	UserID Int,	AddressType Int,	StateId int,    AddressField VARCHAR(255),    Pincode VARCHAR(255),	);--drop table AddressDetails;create table Country(	CountryId Int IDENTITY(1,1) PRIMARY KEY,	CountryName varchar(255),)create table State(	StateId Int IDENTITY(1,1) PRIMARY KEY,	CountryId Int FOREIGN KEY REFERENCES Country(CountryID),	StateName varchar(255),)Select * from UserDetails;insert into Country(CountryName) values ('USA');insert into State(Countryid, Statename) values (3,'Select here');insert into State(Countryid, Statename) values (4,'West Bengal');insert into State(Countryid, Statename) values (5,'California');select * from AddressDetails;select * from State;CREATE TABLE Note (
    NoteID INT IDENTITY(1,1) PRIMARY KEY,
    ObjectID INT,
    ObjectType Int,
    NoteText TEXT,
    TimeStamp datetime
);


create table Document (
	DocumentID int IDENTITY(1,1) PRIMARY KEY,
	ObjectID int not null,
	ObjectType int not null,
	DocumentType int not null,
	DocumentOriginalName varchar(255) not null,
	DocumentGuidName varchar(255) not null,
	TimeStamp datetime not null
);

create table DocumentType(
	DocumentTypeID int IDENTITY(1,1) PRIMARY KEY,
	DocumentTypeFor int not null,
	DocumentTypeName varchar(255) not null
);

insert into DocumentType(DocumentTypeFor, DocumentTypeName) values (1,'Pan');


select * from UserDetails;

create table Role(
	RoleID int IDENTITY(1,1) PRIMARY KEY,
	RoleName varchar(255) not null,
	IsDefault bit not null,
	IsAdmin bit not null
);

create table UserRole(
	UserRoleID int IDENTITY(1,1) PRIMARY KEY,
	UserId int not null,
	RoleID int not null,
);

insert into UserRole (UserId,RoleID) values (1,1);


