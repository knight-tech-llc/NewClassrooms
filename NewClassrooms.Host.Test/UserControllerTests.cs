// -----------------------------------------------------------------------
// <copyright file="UserControllerTests.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Test
{
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NewClassrooms.Core.Interface;
    using NewClassrooms.Core.Model;
    using NewClassrooms.Entity;
    using NewClassrooms.Host.Controllers;
    using NewClassrooms.Service.Enum;

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
            if (male is null || female is null)
            {
                throw new Exception("Users cannot be null.");
            }

            var users = new List<User> { male, female };
            var expected = new List<GenderPercentageEntity>
            {
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

        /// <summary>
        /// Asserts that a <see cref="UserController.GetFirstNamePercentages(User[])"/> can be invoked successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_First_Name_Percentages_Successfully()
        {
            // Arrange.
            var am = this.users.FirstOrDefault(u => u.Name.First.StartsWith("A"));
            var nz = this.users.FirstOrDefault(u => u.Name.First.StartsWith("N"));
            if (am is null || nz is null)
            {
                throw new Exception("Ranges cannot be null.");
            }

            var users = new List<User> { am, nz };
            var expected = new List<NamePercentageEntity>
            {
               new NamePercentageEntity("A-M", 50),
               new NamePercentageEntity("N-Z", 50),
            };

            this.manageUser.Setup(x => x.GetFirstNamePercentages(users.ToArray())).ReturnsAsync(expected);
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetFirstNamePercentages(users.ToArray()) as OkObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetFirstNamePercentages(User[])"/> will throw an error if the users array is empty.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_First_Name_Percentages_With_Empty_User_Array_Throws_Error()
        {
            // Arrange.
            var users = new List<User>();

            this.manageUser.Setup(x => x.GetFirstNamePercentages(users.ToArray())).ThrowsAsync(It.IsAny<Exception>());
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetFirstNamePercentages(users.ToArray()) as BadRequestObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetLastNamePercentages(User[])"/> can be invoked successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Last_Name_Percentages_Successfully()
        {
            // Arrange.
            var am = this.users.FirstOrDefault(u => u.Name.First.StartsWith("A"));
            var nz = this.users.FirstOrDefault(u => u.Name.First.StartsWith("N"));
            if (am is null || nz is null)
            {
                throw new Exception("Ranges cannot be null.");
            }

            var users = new List<User> { am, nz };
            var expected = new List<NamePercentageEntity>
            {
               new NamePercentageEntity("A-M", 50),
               new NamePercentageEntity("N-Z", 50),
            };

            this.manageUser.Setup(x => x.GetLastNamePercentages(users.ToArray())).ReturnsAsync(expected);
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetLastNamePercentages(users.ToArray()) as OkObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetLastNamePercentages(User[])"/> will throw an error if the users array is empty.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Last_Name_Percentages_With_Empty_User_Array_Throws_Error()
        {
            // Arrange.
            var users = new List<User>();

            this.manageUser.Setup(x => x.GetLastNamePercentages(users.ToArray())).ThrowsAsync(It.IsAny<Exception>());
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetLastNamePercentages(users.ToArray()) as BadRequestObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetStatePopulationPercentages(User[])"/> can be invoked successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_State_Population_Percentages_Successfully()
        {
            // Arrange.
            var userOne = this.users.FirstOrDefault(u => u.Location.State == "Montana");
            var userTwo = this.users.FirstOrDefault(u => u.Location.State == "Alaska");
            if (userOne is null || userTwo is null)
            {
                throw new Exception("Users cannot be null.");
            }

            var users = new List<User> { userOne, userTwo };
            var expected = new List<StatePopulationPercentageEntity>
            {
               new StatePopulationPercentageEntity("Montana", 50),
               new StatePopulationPercentageEntity("Alaska", 50),
            };

            this.manageUser.Setup(x => x.GetStatePopulationPercentages(users.ToArray())).ReturnsAsync(expected);
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetStatePopulationPercentages(users.ToArray()) as OkObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetStatePopulationPercentages(User[])"/> will throw an error if the users array is empty.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_State_Population_Percentages_With_Empty_User_Array_Throws_Error()
        {
            // Arrange.
            var users = new List<User>();

            this.manageUser.Setup(x => x.GetStatePopulationPercentages(users.ToArray())).ThrowsAsync(It.IsAny<Exception>());
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetStatePopulationPercentages(users.ToArray()) as BadRequestObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetFemalePopulationPercentages(User[])"/> can be invoked successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Female_Population_Percentages_Successfully()
        {
            // Arrange.
            var userOne = this.users.FirstOrDefault(u => u.Location.State == "Montana" && u.Gender.ToLower() == Gender.Female.ToString().ToLower());
            var userTwo = this.users.FirstOrDefault(u => u.Location.State == "Alaska" && u.Gender.ToLower() == Gender.Male.ToString().ToLower());
            if (userOne is null || userTwo is null)
            {
                throw new Exception("Users cannot be null.");
            }

            var users = new List<User> { userOne, userTwo };

            var expected = new List<StatePopulationPercentageEntity>
            {
               new StatePopulationPercentageEntity("Montana", 50),
               new StatePopulationPercentageEntity("Alaska", 0),
            };

            this.manageUser.Setup(x => x.GetFemalePopulationPercentages(users.ToArray())).ReturnsAsync(expected);
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetFemalePopulationPercentages(users.ToArray()) as OkObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetFemalePopulationPercentages(User[])"/> will throw an error if the users array is empty.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Female_Population_Percentages_With_Empty_User_Array_Throws_Error()
        {
            // Arrange.
            var users = new List<User>();

            this.manageUser.Setup(x => x.GetFemalePopulationPercentages(users.ToArray())).ThrowsAsync(It.IsAny<Exception>());
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetFemalePopulationPercentages(users.ToArray()) as BadRequestObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetMalePopulationPercentages(User[])"/> can be invoked successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Male_Population_Percentages_Successfully()
        {
            // Arrange.
            var userOne = this.users.FirstOrDefault(u => u.Location.State == "Montana" && u.Gender.ToLower() == Gender.Female.ToString().ToLower());
            var userTwo = this.users.FirstOrDefault(u => u.Location.State == "Alaska" && u.Gender.ToLower() == Gender.Male.ToString().ToLower());
            if (userOne is null || userTwo is null)
            {
                throw new Exception("Users cannot be null.");
            }

            var users = new List<User> { userOne, userTwo };

            var expected = new List<StatePopulationPercentageEntity>
            {
               new StatePopulationPercentageEntity("Montana", 0),
               new StatePopulationPercentageEntity("Alaska", 50),
            };

            this.manageUser.Setup(x => x.GetMalePopulationPercentages(users.ToArray())).ReturnsAsync(expected);
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetMalePopulationPercentages(users.ToArray()) as OkObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetMalePopulationPercentages(User[])"/> will throw an error if the users array is empty.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Male_Population_Percentages_With_Empty_User_Array_Throws_Error()
        {
            // Arrange.
            var users = new List<User>();

            this.manageUser.Setup(x => x.GetMalePopulationPercentages(users.ToArray())).ThrowsAsync(It.IsAny<Exception>());
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetMalePopulationPercentages(users.ToArray()) as BadRequestObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetAgeRangePercentages(User[])"/> can be invoked successfully.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Age_Range_Percentages_Successfully()
        {
            // Arrange.
            var zeroToTwenty = this.users.FirstOrDefault(u => u.Dob.Age == 0 && u.Dob.Age <= 20);
            var twentyOneToForty = this.users.FirstOrDefault(u => u.Dob.Age >= 21 && u.Dob.Age <= 40);
            if (zeroToTwenty is null || twentyOneToForty is null)
            {
                throw new Exception("Ranges cannot be null.");
            }

            var users = new List<User> { zeroToTwenty, twentyOneToForty };
            var expected = new List<AgeRangePercentageEntity>
            {
               new AgeRangePercentageEntity("0-20", 50),
               new AgeRangePercentageEntity("21-40", 50),
            };

            this.manageUser.Setup(x => x.GetAgeRangePercentages(users.ToArray())).ReturnsAsync(expected);
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetAgeRangePercentages(users.ToArray()) as OkObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.Equal(expected, actual.Value);
        }

        /// <summary>
        /// Asserts that a <see cref="UserController.GetAgeRangePercentages(User[])"/> will throw an error if the users array is empty.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Fact]
        public async Task Invoke_Get_Age_Range_Percentages_With_Empty_User_Array_Throws_Error()
        {
            // Arrange.
            var users = new List<User>();

            this.manageUser.Setup(x => x.GetAgeRangePercentages(users.ToArray())).ThrowsAsync(It.IsAny<Exception>());
            var controller = new UserController(this.manageUser.Object, this.logger.Object);

            // Act.
            var actual = await controller.GetAgeRangePercentages(users.ToArray()) as BadRequestObjectResult;

            // Assert.
            Assert.NotNull(actual);
            Assert.NotNull(actual.Value);
        }

        private User[] GetUsers()
        {
            var users = File.ReadAllText(@"Assets/Users.json") ?? string.Empty;
            if (users is not null)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                return JsonSerializer.Deserialize<User[]>(users, options) ?? new User[0];
            }

            throw new Exception("Users string cannot be null or empty.");
        }
    }
}