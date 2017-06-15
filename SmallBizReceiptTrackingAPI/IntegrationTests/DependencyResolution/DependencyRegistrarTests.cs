using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FakeItEasy;
using Ninject;
using Ninject.Modules;
using Xunit;

using SmallBizReceiptTrackingAPI.DependencyResolution;
using SmallBizReceiptTrackingAPI.Entities.Entities;

namespace SmallBizReceiptTrackingAPI.IntegrationTests.DependencyResolution
{
    public class DependencyRegistrarTests
    {
        #region Load Tests

        [Fact]
        public void Load_Positive_Good()
        {
            // ARRANGE
            ConfigurationSettingsEntity configurationSettings = new ConfigurationSettingsEntity(ConfigurationManager.AppSettings);

            DependencyRegistrar tester = new DependencyRegistrar(configurationSettings);
            
            var modules = new INinjectModule[] { tester };

            // ACT
            var kernel = new StandardKernel(modules);

            // ASSERT
            Assert.NotNull(kernel);
            
        }
        #endregion
    }
}
