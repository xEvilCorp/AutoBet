using AutoBet.Domain.Entities;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutoBet.Tests.Fixtures
{
    [CollectionDefinition(nameof(UserFixtureCollection))]
    public class UserFixtureCollection : ICollectionFixture<UserFixture> { }

    public class UserFixture
    {
        public User Valid()
        {
            Faker<User> faker = new Faker<User>();

            faker.CustomInstantiator(x =>
                new User(
                    name: x.Internet.UserName(),
                    password: x.Internet.Password()
            ));

            User user = faker.Generate();

            return user;
        }

        public User Empty()
        {
            User user = new User("", "");
            return user;
        }
    }
}
