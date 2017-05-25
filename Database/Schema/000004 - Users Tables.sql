BEGIN TRANSACTION

Create Table Users.Users
(
	UserID INT IDENTITY(1,1) NOT NULL Primary Key,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	AddressID INT NOT NULL,
	CompanyID INT NOT NULL,
	IsPrimaryCompanyContact BIT NOT NULL DEFAULT(0)
);
GO

Create Table Users.UserPhones
(
	UserPhoneID INT IDENTITY(1,1) NOT NULL Primary Key,
	UserPhoneType INT NOT NULL, 
	UserID INT NOT NULL,
	UserPhoneNumber VARCHAR(255) NOT NULL
);
GO

Create Table Users.UserEmails
(
	UserEmailID INT IDENTITY(1,1) NOT NULL Primary Key,
	UserEmailType INT NOT NULL,
	UserID INT NOT NULL,
	UserEmailAddress VARCHAR(255) NOT NULL
);
GO

CREATE UNIQUE INDEX IDX_Unique_Company_Contact ON Users.Users(CompanyID, IsPrimaryCompanyContact) WHERE IsPrimaryCompanyContact = 1
GO
CREATE UNIQUE INDEX IDX_Unique_User_Company ON Users.Users(UserID, CompanyID)
GO

ALTER TABLE Users.Users WITH CHECK ADD CONSTRAINT FK_Users_Users_Common_Addresses FOREIGN KEY (AddressID) REFERENCES Common.Addresses(AddressID)
GO
ALTER TABLE Users.Users WITH CHECK ADD CONSTRAINT FK_Users_Users_Companies_Companies FOREIGN KEY (CompanyID) REFERENCES Companies.Companies(CompanyID)
GO
ALTER TABLE Users.UserPhones WITH CHECK ADD CONSTRAINT FK_Users_UserPhones_Common_PhoneTypes FOREIGN KEY (UserPhoneType) REFERENCES Common.PhoneTypes(PhoneTypeID)
GO
ALTER TABLE Users.UserPhones WITH CHECK ADD CONSTRAINT FK_Users_UserPhones_Users_Users FOREIGN KEY (UserID) REFERENCES Users.Users(UserID)
GO
ALTER TABLE Users.UserEmails WITH CHECK ADD CONSTRAINT FK_Users_UserEmails_Common_EmailTypes FOREIGN KEY (UserEmailType) REFERENCES Common.EmailTypes(EmailTypeID)
GO
ALTER TABLE Users.UserEmails WITH CHECK ADD CONSTRAINT FK_Users_UserEmails_Users_Users FOREIGN KEY (UserID) REFERENCES Users.Users(UserID)
GO

--COMMIT TRANSACTION