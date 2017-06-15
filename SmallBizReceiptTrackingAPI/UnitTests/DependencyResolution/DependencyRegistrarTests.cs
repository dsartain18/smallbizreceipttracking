using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FakeItEasy;
using Ninject;
using Ninject.Web.Common;
using Xunit;

using SmallBizReceiptTrackingAPI.DependencyResolution;
using SmallBizReceiptTrackingAPI.Entities.Entities;

namespace SmallBizReceiptTrackingAPI.UnitTests.DependencyResolution
{
    public class DependencyRegistrarTests
    {
        #region Constructor Tests

        [Fact]
        public void Constructor_Positive_Good()
        {
            // ARRANGE
            NameValueCollection fakeValues = new NameValueCollection();
            fakeValues.Add("APIKey", "6CB7E1F1-B10D-4935-8253-A83E11021F43");
            fakeValues.Add("log4NetConfigurationFile", @"C:\Repository\Small Biz Receipt Tracking\trunk\SmallBizReceiptTrackingAPI\SmallBizReceiptTrackingAPI\bin\log4net.config");
            fakeValues.Add("shouldWatchLog4NetConfigurationFile", "true");

            ConfigurationSettingsEntity configurationSettings = new ConfigurationSettingsEntity(fakeValues);

            // ACT
            DependencyRegistrar tester = new DependencyRegistrar(configurationSettings);

            // ASSERT
            Assert.NotNull(tester);
        }

        [Fact]
        public void Constructor_Negative_NullConfigurationSettingsEntity()
        {
            // ARRANGE
            const string EXPECTED_EXCEPTION_PARAM = "configurationSettings";
            ConfigurationSettingsEntity configurationSettings = null;
            DependencyRegistrar tester = null;

            ArgumentNullException actualException = null;

            // ACT
            actualException = Assert.Throws<ArgumentNullException>(() => tester = new DependencyRegistrar(configurationSettings)) as ArgumentNullException;

            // ASSERT
            Assert.NotNull(actualException);
            Assert.Equal(EXPECTED_EXCEPTION_PARAM, actualException.ParamName);
        }

        #endregion                
    }
}
