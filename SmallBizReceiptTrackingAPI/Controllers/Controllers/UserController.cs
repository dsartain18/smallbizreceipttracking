using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AutoMapper;

using SmallBizReceiptTrackingAPI.DataTransfer.Users;
using SmallBizReceiptTrackingAPI.Entities.Entities;
using SmallBizReceiptTrackingAPI.Managers.Interfaces;


namespace SmallBizReceiptTrackingAPI.Controllers.Controllers
{
    /// <summary>
    /// Contains the endpoints for the User Controller
    /// </summary>
    [RoutePrefix("api/1/User")]
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IUserManager _usermanager;

        /// <summary>
        /// Constructs a new instance of the User Controller
        /// </summary>
        /// <param name="mapper">Implementation of the IMapper interface to user</param>
        /// <param name="userManager">Implementation of the IUserManager interface to user</param>
        public UserController(IMapper mapper, IUserManager userManager)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException("mapper");
            }

            if (userManager == null)
            {
                throw new ArgumentNullException("userManager");
            }

            _mapper = mapper;
            _usermanager = userManager;
        }

        /// <summary>
        /// Gets a list of users
        /// </summary>
        /// <returns>List of UserDTO objects</returns>
        [Route("GetUsers")]
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            List<UserDTO> userDTOList = null;

            try
            {
                List<UserEntity> userEntities = _usermanager.GetUsers();

                userDTOList = _mapper.Map<List<UserDTO>>(userEntities);
            }
            catch (Exception ex)
            {

            }

            return Request.CreateResponse(HttpStatusCode.OK, userDTOList);
        }
    }
}
