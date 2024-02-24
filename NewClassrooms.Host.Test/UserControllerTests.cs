// -----------------------------------------------------------------------
// <copyright file="UserControllerTests.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Test
{
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NewClassrooms.Core.Interface;
    using NewClassrooms.Core.Model;
    using NewClassrooms.Entity;
    using NewClassrooms.Host.Controllers;

    /// <summary>
    /// Provides unit tests for <see cref="UserController"/>.
    /// </summary>
    public class UserControllerTests
    {
        private readonly Mock<IManageUser> manageUser;
        private readonly Mock<ILogger<UserController>> logger;
        private readonly User[] users;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserControllerTests"/> class.
        /// </summary>
        public UserControllerTests()
        {
            this.logger = new Mock<ILogger<UserController>>();
            this.manageUser = new Mock<IManageUser>();
            this.users = this.GetUsers();
        }

        /// <summary>
        /// Asserts that a <see cref="UserController"/> can be created successfully.
        /// </summary>
        [Fact]
        public void Create_User_Controller_Successfully()
        {
            // Arrange.
            Func<UserController> act = () => new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var controller = act();

            // Assert.
            Assert.NotNull(controller);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetGenderPercentages(User[])"/> can be invoked successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Gender_Percentages_Successfully()
        {
            // Arrange.
            var male = this.users.FirstOrDefault(u => u.Gender.ToLower() == "male");
            var female = this.users.FirstOrDefault(u => u.Gender.ToLower() == "female");
            var users = new List<User> { male, female };
            var expected = new List<GenderPercentageEntity> {
                    new GenderPercentageEntity("male", 50),
                    new GenderPercentageEntity("female", 50),
                };

            this.manageUser.Setup(x => x.GetGenderPercentages(users.ToArray())).ReturnsAsync(expected);
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetGenderPercentages(users.ToArray()) as OkObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetGenderPercentages(User[])"/> will throw an error if the users array is empty.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Gender_Percentages_With_Empty_User_Array_Throws_Error()
        {
            // Arrange.
            var users = new List<User>();

            this.manageUser.Setup(x => x.GetGenderPercentages(users.ToArray())).ThrowsAsync(It.IsAny<Exception>());
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetGenderPercentages(users.ToArray()) as BadRequestObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
        }

        private User[] GetUsers()
        {
            var users = File.ReadAllText(@"Assets/Users.json");
            if (users is not null)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return JsonSerializer.Deserialize<User[]>(users, options);
            }

            throw new Exception("Users string cannot be null or empty.");
        }
    }
}