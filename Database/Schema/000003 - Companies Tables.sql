BEGIN TRANSACTION

Create Table Companies.Companies
(
	CompanyID INT NOT NULL Primary Key,
	CompanyName VARCHAR(255) NOT NULL,
	AddressID INT NOT NULL
);
GO

Create Table Companies.CompanyPhones
(
	CompanyPhoneID INT NOT NULL Primary Key,
	CompanyPhoneType INT NOT NULL,
	CompanyID INT NOT NULL,
	CompanyPhoneNumber VARCHAR(50)
);
GO

Create Table Companies.CompanyEmails
(
	CompanyEmailID INT NOT NULL Primary Key,
	CompanyEmailType INT NOT NULL,
	CompanyID INT NOT NULL,
	CompanyEmailAddress VARCHAR(255) NOT NULL
);
GO

ALTER TABLE Companies.Companies ADD CONSTRAINT FK_Companies_Companies_Common_Addresses FOREIGN KEY (AddressID) REFERENCES Common.Addresses(AddressID)
GO
ALTER TABLE Companies.CompanyPhones ADD CONSTRAINT FK_Companies_CompanyPhones_Common_PhoneTypes FOREIGN KEY (CompanyPhoneType) REFERENCES Common.PhoneTypes(PhoneTypeID)
GO
ALTER TABLE Companies.CompanyPhones ADD CONSTRAINT FK_Companies_CompanyPhones_Companies_Companies FOREIGN KEY (CompanyID) REFERENCES Companies.Companies(CompanyID)
GO
ALTER TABLE Companies.CompanyEmails ADD CONSTRAINT FK_Companies_CompanyEmails_Common_EmailTypes FOREIGN KEY (CompanyEmailType) REFERENCES Common.EmailTypes(EmailTypeID)
GO
ALTER TABLE Companies.CompanyEmails ADD CONSTRAINT FK_Companies_CompanyEmails_Companies_Companies FOREIGN KEY (CompanyID) REFERENCES Companies.Companies(CompanyID)
GO

--COMMIT TRANSACTION