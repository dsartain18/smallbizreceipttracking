using System;
using System.Collections.Specialized;

using Xunit;

using SmallBizReceiptTrackingAPI.Entities.Entities;


namespace SmallBizReceiptTrackingAPI.UnitTests.Entities
{
    public class ConfigurationEntityTests
    {
        [Fact]
        public void Constructor_Positive_Good()
        {
            // ARRANGE
            ConfigurationSettingsEntity tester = null;

            NameValueCollection fakeValues = new NameValueCollection();
            fakeValues.Add("APIKey", "6CB7E1F1-B10D-4935-8253-A83E11021F43");
            fakeValues.Add("log4NetConfigurationFile", @"C:\Repository\Small Biz Receipt Tracking\trunk\SmallBizReceiptTrackingAPI\SmallBizReceiptTrackingAPI\bin\log4net.config");
            fakeValues.Add("shouldWatchLog4NetConfigurationFile", "true");

            // ACT
            tester = new ConfigurationSettingsEntity(fakeValues);

            // ASSERT
            Assert.NotNull(tester);
        }

        [Fact]
        public void Constructor_Negative_NullValues()
        {
            // ARRANGE
            const string EXCEPTION_PARAM = "configurationSettings";
            ConfigurationSettingsEntity tester = null;

            NameValueCollection fakeValues = null;

            ArgumentNullException actualException = null;

            // ACT
            actualException = Assert.Throws<ArgumentNullException>(() => tester = new ConfigurationSettingsEntity(fakeValues)) as ArgumentNullException;
            
            
            // ASSERT
            Assert.NotNull(actualException);
            Assert.Equal(EXCEPTION_PARAM, actualException.ParamName);
        }
    }
}
