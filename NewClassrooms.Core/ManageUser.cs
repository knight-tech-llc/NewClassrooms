// -----------------------------------------------------------------------
// <copyright file="ManageUser.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using GuardAgainstLib;
    using NewClassrooms.Core.Interface;
    using NewClassrooms.Core.Model;
    using NewClassrooms.Entity;
    using NewClassrooms.Service.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="IManageUser"/>.
    /// </summary>
    public class ManageUser : IManageUser
    {
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageUser"/> class.
        /// </summary>
        /// <param name="userService">A value that represents an implementation of <see cref="IUserService"/>.</param>
        public ManageUser(IUserService userService)
        {
            this.userService = GuardAgainst.ArgumentBeingNull(userService, nameof(userService));
        }

        /// <inheritdoc/>
        public async Task<List<NamePercentageEntity>> GetFirstNamePercentages(User[] users)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(users, nameof(users));
            var userEntities = users.ToList().ConvertAll(x => new UserEntity(
                x.Name.First,
                x.Name.Last,
                x.Dob.Age,
                x.Gender,
                x.Location.State)
            { });

            return await this.userService.GetFirstNamePercentages(userEntities);
        }

        /// <inheritdoc/>
        public async Task<List<NamePercentageEntity>> GetLastNamePercentages(User[] users)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(users, nameof(users));
            var userEntities = users.ToList().ConvertAll(x => new UserEntity(
                x.Name.First,
                x.Name.Last,
                x.Dob.Age,
                x.Gender,
                x.Location.State)
            { });

            return await this.userService.GetLastNamePercentages(userEntities);
        }

        /// <inheritdoc/>
        public async Task<List<GenderPercentageEntity>> GetGenderPercentages(User[] users)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(users, nameof(users));
            var userEntities = users.ToList().ConvertAll(x => new UserEntity(
                x.Name.First,
                x.Name.Last,
                x.Dob.Age,
                x.Gender,
                x.Location.State)
            { });

            return await this.userService.GetGenderPercentages(userEntities);
        }

        /// <inheritdoc/>
        public async Task<List<StatePopulationPercentageEntity>> GetStatePopulationPercentages(User[] users)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(users, nameof(users));
            var userEntities = users.ToList().ConvertAll(x => new UserEntity(
                x.Name.First,
                x.Name.Last,
                x.Dob.Age,
                x.Gender,
                x.Location.State)
            { });

            return await this.userService.GetStatePopulationPercentages(userEntities);
        }
    }
}