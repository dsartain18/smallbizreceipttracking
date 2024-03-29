SELECT 
	u.FirstName,
	u.LastName,	
	u.IsPrimaryCompanyContact,
	u.AddressID as [UserAddressID],
	a1.AddressLine1 as [UserAddressLine1],
	a1.AddressLine2 as [UserAddressLine2],
	a1.City as [UserCity],
	a1.StateCode as [UserStateCode],
	a1.ZipCode as [UserZipCode],
	ue.UserEmailAddress,
	ue.UserEmailType,
	et1.EmailTypeDesc,
	up.UserPhoneNumber,
	up.UserPhoneType,
	pt1.PhoneTypeDesc,
	u.CompanyID,
	c.CompanyName ,
	c.AddressID as [CompanyAddressID],
	a2.AddressLine1 as [CompanyAddressLine1],
	a2.AddressLine2 as [CompanyAddressLine2],
	a2.City as [CompanyCity],
	a2.StateCode as [CompanyStateCode],
	a2.ZipCode as [CompanyZipCode],
	ce.CompanyEmailAddress,
	ce.CompanyEmailType,
	et2.EmailTypeDesc,
	cp.CompanyPhoneNumber,
	cp.CompanyPhoneType,
	pt2.PhoneTypeDesc
FROM
	Users.Users u
LEFT JOIN
	Companies.Companies c ON c.CompanyID = u.CompanyID
LEFT JOIN 
	Common.Addresses a1 ON a1.AddressID = u.AddressID
LEFT JOIN 
	Common.Addresses a2 ON a2.AddressID = c.AddressID
LEFT JOIN
	Companies.CompanyEmails ce ON ce.CompanyID = c.CompanyID
LEFT JOIN
	Companies.CompanyPhones cp ON cp.CompanyID = c.CompanyID
LEFT JOIN
	Users.UserEmails ue ON ue.UserID = u.UserID
LEFT JOIN 
	Users.UserPhones up ON up.UserID = u.UserID
LEFT JOIN
	Common.EmailTypes et1 ON et1.EmailTypeID = ue.UserEmailType
LEFT JOIN 
	Common.PhoneTypes pt1 ON pt1.PhoneTypeID = up.UserPhoneType
LEFT JOIN
	Common.EmailTypes et2 ON et2.EmailTypeID = ce.CompanyEmailType
LEFT JOIN 
	Common.PhoneTypes pt2 ON pt2.PhoneTypeID = cp.CompanyPhoneType

