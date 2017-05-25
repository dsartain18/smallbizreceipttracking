BEGIN TRANSACTION 

INSERT INTO Common.EmailTypes
(
	EmailTypeDesc
)
VALUES
('Home'),
('Work')

INSERT INTO Common.PhoneTypes
(
	PhoneTypeDesc
)
VALUES
('Work'),
('Mobile'),
('Home'),
('Fax')

-- ROLLBACK TRANSACTION
-- COMMIT TRANSACTION