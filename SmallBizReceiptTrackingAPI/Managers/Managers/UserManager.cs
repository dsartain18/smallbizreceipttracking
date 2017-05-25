using System;
using System.Collections.Generic;

using SmallBizReceiptTrackingAPI.Entities.Entities;
using SmallBizReceiptTrackingAPI.Managers.Interfaces;
using SmallBizReceiptTrackingAPI.Repositories.Interfaces;

namespace SmallBizReceiptTrackingAPI.Managers.Managers
{
    /// <summary>
    /// Contains the methods to retrieve and save information about users
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Constructs a new instance of the UserManager
        /// </summary>
        /// <param name="userRepository">Implementation of the IUserRepository interface to use</param>
        public UserManager(IUserRepository userRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException("userRepository");
            }

            _userRepository = userRepository;
        }

        /// <summary>
        /// Gets a list of users
        /// </summary>
        /// <returns>List of UserEntity objects</returns>
        public List<UserEntity> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
