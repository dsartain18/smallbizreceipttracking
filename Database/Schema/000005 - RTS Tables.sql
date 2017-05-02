BEGIN TRANSACTION

Create Table RTS.Receipts
(
	ReceiptID INT NOT NULL Primary Key,
	CompanyID INT NOT NULL,
	UploadedByUserID INT NOT NULL,
	BlobID INT NOT NULL,
	SalesTax DECIMAL NULL,
	TotalAmount DECIMAL NOT NULL
);

ALTER TABLE RTS.Receipts WITH CHECK ADD CONSTRAINT FK_RTS_Receipts_Companies_Companies FOREIGN KEY (CompanyID) REFERENCES Companies.Companies(CompanyID)
GO
ALTER TABLE RTS.Receipts WITH CHECK ADD CONSTRAINT FK_RTS_Receipts_Users_Users FOREIGN KEY (UploadedByUserID) REFERENCES Users.Users(UserID)
GO
ALTER TABLE RTS.Receipts WITH CHECK ADD CONSTRAINT FK_RTS_Receipts_Common_Blobs FOREIGN KEY (BlobID) REFERENCES Common.Blobs(BlobID)
GO

--ROLLBACK TRANSACTION
--COMMIT TRANSACTION