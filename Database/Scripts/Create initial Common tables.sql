BEGIN TRANSACTION

CREATE TABLE Common.MimeTypes
(
	MimeTypeID INT IDENTITY(1,1) NOT NULL Primary Key,
	MimeTypeDesc VARCHAR(100) NOT NULL,
	MimeTypeExt VARCHAR(100) NOT NULL
);

Create Table Common.Blobs
(
	BlobID INT IDENTITY(1,1) NOT NULL Primary Key,
	Blob VARBINARY(MAX) NOT NULL,
	MimeTypeID INT NOT NULL
);

Create Table Common.Addresses
(
	AddressID INT IDENTITY(1,1) NOT NULL Primary Key,
	AddressLine1 VARCHAR(50) NOT NULL,
	AddressLine2 VARCHAR(50) NULL,
	City VARCHAR(50) NOT NULL,
	StateCode CHAR(2) NOT NULL,
	ZipCode VARCHAR(10) NOT NULL
);

Create Table Common.PhoneTypes
(
	PhoneTypeID INT IDENTITY(1,1) NOT NULL Primary Key,
	PhoneTypeDesc VARCHAR(20) NOT NULL
);

Create Table Common.EmailTypes
(
	EmailTypeID INT IDENTITY(1,1) NOT NULL Primary Key,
	EmailTypeDesc VARCHAR(20) NOT NULL
);

ALTER TABLE Common.Blobs WITH CHECK ADD CONSTRAINT FK_Common_Blobs_Common_MimeTypes FOREIGN KEY(MimeTypeID) REFERENCES Common.MimeTypes(MimeTypeID)

--COMMIT TRANSACTION