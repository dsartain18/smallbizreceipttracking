using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using FakeItEasy;
using Xunit;

using SmallBizReceiptTrackingAPI.DependencyResolution;
using SmallBizReceiptTrackingAPI.Entities.Entities;
using SmallBizReceiptTrackingAPI.Repositories.Repositories;

namespace SmallBizReceiptTrackingAPI.IntegrationTests.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public void GetUsers_Positive_Good()
        {
            // ARRANGE
            var automapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMapperProfile>(); });
            automapperConfig.AssertConfigurationIsValid();
            var mapper = automapperConfig.CreateMapper();
                        
            UserRepository tester = new UserRepository(mapper);

            List<UserEntity> results = null;

            // ACT
            results = tester.GetUsers();

            // ASSERT
            Assert.NotNull(results);
            Assert.Equal(1, results.Count);
        }
    }
}
