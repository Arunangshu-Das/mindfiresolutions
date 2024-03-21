CREATE TABLE [User] (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL
);

CREATE TABLE [Category] (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryTitle VARCHAR(255) NOT NULL
);

CREATE TABLE [Agency] (
    AgencyId INT IDENTITY(1,1) PRIMARY KEY,
    AgencyName VARCHAR(255) NOT NULL,
    AgencyLogoPath VARCHAR(255) NOT NULL
);

CREATE TABLE [AgencyFeed] (
    AgencyFeedId INT IDENTITY(1,1) PRIMARY KEY,
    AgencyFeedUrl VARCHAR(255) NOT NULL,
    AgencyId INT NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (AgencyId) REFERENCES [Agency](AgencyId),
    FOREIGN KEY (CategoryId) REFERENCES [Category](CategoryId)
);

CREATE TABLE [News] (
    NewsId INT IDENTITY(1,1) PRIMARY KEY,
    NewsTitle VARCHAR(255) NOT NULL,
    NewsDescription TEXT,
    NewsPublishDateTime DATETIME NOT NULL,
    NewsLink VARCHAR(255) UNIQUE NOT NULL,
    ClickCount INT DEFAULT 0,
    CategoryId INT NOT NULL,
    AgencyId INT NOT NULL,
    FOREIGN KEY (CategoryId) REFERENCES [Category](CategoryId),
    FOREIGN KEY (AgencyId) REFERENCES [Agency](AgencyId)
);



DROP TABLE IF EXISTS [User];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [Agency];
DROP TABLE IF EXISTS [AgencyFeed];
DROP TABLE IF EXISTS [News];
