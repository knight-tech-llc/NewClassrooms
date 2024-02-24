// -----------------------------------------------------------------------
// <copyright file="IManageUser.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Core.Interface
{
    using NewClassrooms.Core.Model;
    using NewClassrooms.Entity;

    /// <summary>
    /// Provides an interface for manage user.
    /// </summary>
    public interface IManageUser
    {
        /// <summary>
        /// Provides a method to retrieve the percentage of genders.
        /// </summary>
        /// <param name="users">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<GenderPercentageEntity>> GetGenderPercentages(User[] users);

        /// <summary>
        /// Provides a method to retrieve the percentage of first names that start with A-M versus N-Z.
        /// </summary>
        /// <param name="users">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<NamePercentageEntity>> GetFirstNamePercentages(User[] users);

        /// <summary>
        /// Provides a method to retrieve the percentage of last names that start with A-M versus N-Z.
        /// </summary>
        /// <param name="users">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<NamePercentageEntity>> GetLastNamePercentages(User[] users);

        /// <summary>
        /// Provides a method to retrieve the percentage of users in each state.
        /// </summary>
        /// <param name="users">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<StatePopulationPercentageEntity>> GetStatePopulationPercentages(User[] users);

        /// <summary>
        /// Provides a method to retrieve the female population percentage per state.
        /// </summary>
        /// <param name="users">A value that represents a collection of <see cref="User"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<StatePopulationPercentageEntity>> GetFemalePopulationPercentages(User[] users);

        /// <summary>
        /// Provides a method to retrieve the male population percentage per state.
        /// </summary>
        /// <param name="users">A value that represents a collection of <see cref="User"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<StatePopulationPercentageEntity>> GetMalePopulationPercentages(User[] users);

        /// <summary>
        /// Provides a method to retrieve the age range percentage per state.
        /// </summary>
        /// <param name="users">A value that represents a collection of <see cref="User"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<AgeRangePercentageEntity>> GetAgeRangePercentages(User[] users);
    }
}
