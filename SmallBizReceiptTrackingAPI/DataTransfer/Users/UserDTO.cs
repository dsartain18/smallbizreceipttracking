using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallBizReceiptTrackingAPI.DataTransfer.Users
{
    /// <summary>
    /// Contains the properties for a User DTO
    /// </summary>
    public class UserDTO
    {
        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Company ID
        /// </summary>
        public int CompanyID { get; set; }

        /// <summary>
        /// Address ID
        /// </summary>
        public int AddressID { get; set; }

        /// <summary>
        /// Whether the user is the Primary Company Contact
        /// </summary>
        public bool IsPrimaryCompanyContact { get; set; }
    }
}
