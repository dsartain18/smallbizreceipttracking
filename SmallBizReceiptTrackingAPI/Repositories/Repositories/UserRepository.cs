using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using SmallBizReceiptTrackingAPI.Entities.Entities;
using SmallBizReceiptTrackingAPI.Repositories.Interfaces;
using SmallBizReceiptTrackingAPI.Repositories.Models;

namespace SmallBizReceiptTrackingAPI.Repositories.Repositories
{
    /// <summary>
    /// Contains the methods to retrieve and save information about users
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructs a new instance of the UserRepository
        /// </summary>
        /// <param name="mapper">Implementation of the IMapper interface to use</param>
        public UserRepository(IMapper mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            _mapper = mapper;
        }

        /// <summary>
        /// Gets a list of users
        /// </summary>
        /// <returns>List of UserEntity objects</returns>
        public List<UserEntity> GetUsers()
        {
            List<UserEntity> userEntities = null;

            try
            {
                using (SmallBizReceiptTrackingEntities db = new SmallBizReceiptTrackingEntities())
                {
                    List<DBUser> dbUsers = db.GetUsers().ToList();

                    userEntities = _mapper.Map<List<UserEntity>>(dbUsers);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return userEntities;
        }
    }
}
