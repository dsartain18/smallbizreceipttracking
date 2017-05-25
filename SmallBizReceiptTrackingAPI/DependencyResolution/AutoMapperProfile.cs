using System;

using AutoMapper;

using SmallBizReceiptTrackingAPI.Repositories.Models;
using SmallBizReceiptTrackingAPI.DataTransfer.Users;
using SmallBizReceiptTrackingAPI.Entities.Entities;


namespace SmallBizReceiptTrackingAPI.DependencyResolution
{
    /// <summary>
    /// Sets up automapper registrations
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Registers the configuration
        /// </summary>
        protected override void Configure()
        {
            CreateMap<DBUser, UserEntity>();
            CreateMap<UserDTO, UserEntity>();
        }
    }
}
