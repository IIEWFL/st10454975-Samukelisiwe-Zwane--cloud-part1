use master
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EventEaseDB')
DROP DATABASE EventEaseDB
CREATE DATABASE EventEaseDB
USE EventEaseDB
--TABLE CREATION SECTION--

CREATE TABLE Venues (

VenueID INT PRIMARY KEY IDENTITY(1,1),
VenueName VARCHAR(255) NOT NULL,
[Location] VARCHAR(255),
ImageURL VARCHAR(MAX)

);

CREATE TABLE [Event] (
EventID INT PRIMARY KEY IDENTITY(1,1),
EventName VARCHAR(255) NOT NULL,
EventDate DATETIME,
[Description] VARCHAR (MAX),
VenueID INT FOREIGN KEY (VenueID) REFERENCES Venues(VenueID)

);

CREATE TABLE Booking(
BookingID INT PRIMARY KEY IDENTITY (1,1),
EventID INT FOREIGN KEY (EventID) REFERENCES [Event](EventID),
VenueID INT FOREIGN KEY (VenueID) REFERENCES Venues(VenueID),
BookingDate DATETIME NOT NULL,
CONSTRAINT CK_UniqueVenueBookingTime UNIQUE (VenueID,BookingDate)

);

--TABLE ALTERATION SECTION--

--TABLE INSERTION SECTION--
INSERT INTO Venues (VenueName, [Location],ImageURL)
VALUES('Venue1','Sydney','https://static.vecteezy.com/system/resources/thumbnails/036/324/708/small/ai-generated-picture-of-a-tiger-walking-in-the-forest-photo.jpg')

INSERT INTO [Event](EventName,EventDate,[Description],VenueID)
VALUES ('JamesBondEvent','12 feb 2024','behindajfajeofihh',3)

INSERT INTO Booking(EventID,VenueID,BookingDate)
VALUES (4,2,'11 feb 2024')

--table manipulation section--
SELECT * FROM Venues
SELECT * FROM [Event]
SELECT * FROM Booking
--stored procedures section--