using AutoBet.Tests.Fixtures;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AutoBet.Tests.Domain
{
    [Collection(nameof(UserFixtureCollection))]
    public class UserTests : IClassFixture<UserFixture>
    {
        private readonly UserFixture fix;
        public UserTests(UserFixture fixture)
        {
            fix = fixture;
        }

        [Fact]
        [Trait("User", "User_ValidUser")]
        public void User_CheckForValidUser()
        {
            var user = fix.Valid();
            var validation = user.Valid();

            validation.Should().BeTrue(because: "the user is valid.");
            user.ErrorMessages.Should().BeEmpty(because: "there are no errors.");
        }

        [Fact]
        [Trait("User", "User_EmptyFields")]
        public void User_CheckForEmptyFields()
        {
            var user = fix.Empty();
            var validation = user.Valid();

            validation.Should().BeFalse(because: "required fields are empty.");
            user.ErrorMessages.Should().HaveCount(2, because: "both the username and the password are empty.");
        }
    }
}
