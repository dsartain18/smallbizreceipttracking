using System;

namespace SmallBizReceiptTrackingAPI.Entities.Entities
{
    /// <summary>
    /// Contains the properties necessary for a User Entity
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; protected set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; protected set; }

        /// <summary>
        /// Company ID
        /// </summary>
        public int CompanyID { get; protected set; }

        /// <summary>
        /// Address ID
        /// </summary>
        public int AddressID { get; protected set; }

        /// <summary>
        /// Whether the user is the Primary Company Contact
        /// </summary>
        public bool IsPrimaryCompanyContact { get; protected set; }


        /// <summary>
        /// Constructs a new instance of the UserEntity object
        /// </summary>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="companyID">Company ID</param>
        /// <param name="addressID">Address ID</param>
        /// <param name="isPrimaryCompanyContact">Whether the user is the Primary Company Contact</param>
        public UserEntity(string firstName, string lastName, int companyID, int addressID, bool isPrimaryCompanyContact)
        {
            FirstName = firstName;
            LastName = lastName;
            CompanyID = companyID;
            AddressID = addressID;
            IsPrimaryCompanyContact = isPrimaryCompanyContact;
        }
    }
}
