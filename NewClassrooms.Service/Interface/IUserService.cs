﻿// -----------------------------------------------------------------------
// <copyright file="IUserService.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Service.Interface
{
    using NewClassrooms.Entity;

    /// <summary>
    /// Provides an interface for user service.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Provides a method to retrieve the gender percentage.
        /// </summary>
        /// <param name="userEntities">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<GenderPercentageEntity>> GetGenderPercentages(List<UserEntity> userEntities);

        /// <summary>
        /// Provides a method to retrieve first name percentages.
        /// </summary>
        /// <param name="userEntities">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<NamePercentageEntity>> GetFirstNamePercentages(List<UserEntity> userEntities);

        /// <summary>
        /// Provides a method to retrieve last name percentages.
        /// </summary>
        /// <param name="userEntities">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<NamePercentageEntity>> GetLastNamePercentages(List<UserEntity> userEntities);

        /// <summary>
        /// Provides a method to retrieve state population percentage.
        /// </summary>
        /// <param name="userEntities">A value that represents a collection of <see cref="UserEntity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<StatePopulationPercentageEntity>> GetStatePopulationPercentages(List<UserEntity> userEntities);

        /// <summary>
        /// Provides a method to retrieve the female populations percentage per state.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        int GetFemalePopulationPercentage();

        /// <summary>
        /// Provides a method to retrieve the male population percentage per state.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        int GetMalePopulationPercentage();

        /// <summary>
        /// Provides a method to retrieve age range percentages.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        int GetAgeRangePercentages();
    }
}
