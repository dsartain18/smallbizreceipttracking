using System;

using AutoMapper;
using Ninject.Modules;

using SmallBizReceiptTrackingAPI.Entities.Entities;
using SmallBizReceiptTrackingAPI.Managers.Interfaces;
using SmallBizReceiptTrackingAPI.Managers.Managers;
using SmallBizReceiptTrackingAPI.Repositories.Interfaces;
using SmallBizReceiptTrackingAPI.Repositories.Repositories;

namespace SmallBizReceiptTrackingAPI.DependencyResolution
{
    /// <summary>
    /// Registers the dependencies for the solution
    /// </summary>
    public class DependencyRegistrar : NinjectModule
    {
        private readonly ConfigurationSettingsEntity _configurationSettings;

        /// <summary>
        /// Constructs a new instance of the DependencyRegistrar class
        /// </summary>
        /// <param name="configurationSettings">Configuration settings needed for creating instances</param>
        public DependencyRegistrar(ConfigurationSettingsEntity configurationSettings)
        {
            if (configurationSettings == null)
            {
                throw new ArgumentNullException("configurationSettings");
            }

            _configurationSettings = configurationSettings;
        }

        /// <summary>
        /// Binds interfaces to their implementations with any constructor arguments needed
        /// </summary>
        public override void Load()
        {
            var automapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
            automapperConfig.AssertConfigurationIsValid();
            var mapper = automapperConfig.CreateMapper();

            Bind<IMapper>().ToConstant(mapper).InSingletonScope();
            Bind<IUserManager>().To<UserManager>().InTransientScope();
            Bind<IUserRepository>().To<UserRepository>().InTransientScope();
        }
    }
}
