BEGIN TRANSACTION

DECLARE @AddressID INT
DECLARE @CompanyID INT
DECLARE @UserID INT

INSERT INTO Common.Addresses
(
	AddressLine1,
	City,
	StateCode,
	ZipCode
)
VALUES
(
	'2624 Summertree',
	'Carrollton',
	'TX',
	'75006'
)

SET @AddressID = SCOPE_IDENTITY()

INSERT INTO Companies.Companies
(
	CompanyName,
	AddressID
)
VALUES
(
	'Sartain Woodworking',
	@AddressID
)

SET @CompanyID = SCOPE_IDENTITY();

INSERT INTO Users.Users
(
	FirstName,
	LastName,
	AddressID,
	CompanyID,
	IsPrimaryCompanyContact
)
VALUES
(
	'Don',
	'Sartain',
	@AddressID,
	@CompanyID,
	1
)

SET @UserID = SCOPE_IDENTITY();

INSERT INTO Companies.CompanyEmails
(
	CompanyEmailAddress,
	CompanyEmailType,
	CompanyID
)
VALUES
(
	'dsartain@sartainwoodworking.com',
	2,
	@CompanyID
)

INSERT INTO Companies.CompanyPhones
(
	CompanyPhoneNumber,
	CompanyPhoneType,
	CompanyID
)
VALUES
(
	'214-690-6189',
	1,
	@CompanyID
)

INSERT INTO Users.UserEmails
(
	UserEmailAddress,
	UserEmailType,
	UserID
)
VALUES
(
	'dsartain@sartainwoodworking.com',
	2,
	@UserID
)

INSERT INTO Users.UserPhones
(
	UserPhoneNumber,
	UserPhoneType,
	UserID
)
VALUES
(
	'214-690-6189',
	1,
	@UserID
)

-- ROLLBACK TRANSACTION
-- COMMIT TRANSACTION

