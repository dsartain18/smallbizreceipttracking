using System;

using AutoMapper;
using FakeItEasy;
using Xunit;

using SmallBizReceiptTrackingAPI.Repositories.Repositories;

namespace SmallBizReceiptTrackingAPI.UnitTests.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Constructor_Negative_NullMapper()
        {
            // ARRANGE
            const string EXCEPTION_PARAM = "mapper";

            IMapper fakeMapper = null;
            UserRepository tester = null;
            
            ArgumentNullException actualException = null;

            // ACT
            try
            {
                tester = new UserRepository(fakeMapper);
            }
            catch(ArgumentNullException ex)
            {
                actualException = ex;
            }

            // ASSERT
            Assert.NotNull(actualException);
            Assert.Equal(EXCEPTION_PARAM, actualException.ParamName);
        }
    }
}
