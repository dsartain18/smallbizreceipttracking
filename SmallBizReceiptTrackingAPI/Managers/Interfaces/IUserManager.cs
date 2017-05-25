using System;
using System.Collections.Generic;

using SmallBizReceiptTrackingAPI.Entities.Entities;

namespace SmallBizReceiptTrackingAPI.Managers.Interfaces
{
    /// <summary>
    /// Contains the methods to retrieve and save information about users
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Gets a list of users
        /// </summary>
        /// <returns>List of UserEntity objects</returns>
        List<UserEntity> GetUsers();
    }
}
