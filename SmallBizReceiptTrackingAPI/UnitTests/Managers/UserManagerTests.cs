﻿using System;
using System.Collections.Generic;

using AutoMapper;
using FakeItEasy;
using Xunit;

using SmallBizReceiptTrackingAPI.Entities.Entities;
using SmallBizReceiptTrackingAPI.Managers.Managers;
using SmallBizReceiptTrackingAPI.Repositories.Interfaces;


namespace SmallBizReceiptTrackingAPI.UnitTests.Managers
{
    public class UserManagerTests
    {
        [Fact]
        public void GetUsers_Positive_Good()
        {
            // ARRANGE
            IUserRepository fakeUserRepository = A.Fake<IUserRepository>();

            UserManager tester = new UserManager(fakeUserRepository);

            UserEntity fakeUser1 = new UserEntity
                (
                    "Test",
                    "User",
                    1,
                    1,
                    true
                );            

            List<UserEntity> fakeUserList = new List<UserEntity>();
            fakeUserList.Add(fakeUser1);

            A.CallTo(() => fakeUserRepository.GetUsers()).Returns(fakeUserList);

            List<UserEntity> result = null;

            // ACT
            result = tester.GetUsers();

            // ASSERT            
            Assert.NotNull(result);
            Assert.Equal(1, result.Count);
        }
    }
}
