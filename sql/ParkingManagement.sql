CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Password VARCHAR(255) NOT NULL,
    Type INT NOT NULL
);

CREATE TABLE ParkingZone (
    ParkingZoneID INT IDENTITY(1,1) PRIMARY KEY,
    ParkingZoneTitle VARCHAR(255) NOT NULL
);

CREATE TABLE ParkingSpace (
    ParkingSpaceID INT IDENTITY(1,1) PRIMARY KEY,
    ParkingSpaceTitle VARCHAR(255) NOT NULL,
    ParkingZoneID INT,
	ParkingAvailability INT Default 1, 
    FOREIGN KEY (ParkingZoneID) REFERENCES ParkingZone(ParkingZoneID)
);


CREATE TABLE VehicleParking (
    VehicleParkingID INT IDENTITY(1,1) PRIMARY KEY,
    ParkingZoneID INT,
    ParkingSpaceID INT,
    VehicleID INT, 
    BookingDateTime DATETIME NOT NULL,
    ReleaseDateTime DATETIME,
    FOREIGN KEY (ParkingZoneID) REFERENCES ParkingZone(ParkingZoneID),
    FOREIGN KEY (ParkingSpaceID) REFERENCES ParkingSpace(ParkingSpaceID),
    FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID)
);

drop table VehicleParking;


CREATE TABLE Vehicle (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    RegistrationNumber VARCHAR(20) UNIQUE NOT NULL
);


INSERT INTO Users (Name, Email, Password, Type)
VALUES ('ffff', 'ffff@example.com', 'ffff', 2);

-- Add 3 parking zones
INSERT INTO ParkingZone (ParkingZoneTitle) VALUES ('A'), ('B'), ('C');

-- Add 30 parking spaces for each zone
DECLARE @ZoneIdA INT, @ZoneIdB INT, @ZoneIdC INT;
SELECT @ZoneIdA = ParkingZoneID FROM ParkingZone WHERE ParkingZoneTitle = 'A';
SELECT @ZoneIdB = ParkingZoneID FROM ParkingZone WHERE ParkingZoneTitle = 'B';
SELECT @ZoneIdC = ParkingZoneID FROM ParkingZone WHERE ParkingZoneTitle = 'C';

-- Add parking spaces for Zone A
INSERT INTO ParkingSpace (ParkingSpaceTitle, ParkingZoneID) VALUES
    ('A01', @ZoneIdA), ('A02', @ZoneIdA), ('A03', @ZoneIdA), ('A04', @ZoneIdA), ('A05', @ZoneIdA),
    ('A06', @ZoneIdA), ('A07', @ZoneIdA), ('A08', @ZoneIdA), ('A09', @ZoneIdA), ('A10', @ZoneIdA);

-- Add parking spaces for Zone B
INSERT INTO ParkingSpace (ParkingSpaceTitle, ParkingZoneID) VALUES
    ('B01', @ZoneIdB), ('B02', @ZoneIdB), ('B03', @ZoneIdB), ('B04', @ZoneIdB), ('B05', @ZoneIdB),
    ('B06', @ZoneIdB), ('B07', @ZoneIdB), ('B08', @ZoneIdB), ('B09', @ZoneIdB), ('B10', @ZoneIdB);

-- Add parking spaces for Zone C
INSERT INTO ParkingSpace (ParkingSpaceTitle, ParkingZoneID) VALUES
    ('C01', @ZoneIdC), ('C02', @ZoneIdC), ('C03', @ZoneIdC), ('C04', @ZoneIdC), ('C05', @ZoneIdC),
    ('C06', @ZoneIdC), ('C07', @ZoneIdC), ('C08', @ZoneIdC), ('C09', @ZoneIdC), ('C10', @ZoneIdC);


select * from ParkingZone;

select * from ParkingSpace;