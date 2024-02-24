// -----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Controllers
{
    using GuardAgainstLib;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NewClassrooms.Core.Interface;
    using NewClassrooms.Core.Model;

    /// <summary>
    /// Provides an implementaton of <see cref="ControllerBase"/>.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IManageUser manageUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="manageUser">A value that represents an implementation of <see cref="IManageUser"/>.</param>
        /// <param name="logger">A value that represents an instance of <see cref="ILogger"/>.</param>
        public UserController(IManageUser manageUser, ILogger<UserController> logger)
        {
            this.manageUser = GuardAgainst.ArgumentBeingNull(manageUser, nameof(manageUser));
            this.logger = GuardAgainst.ArgumentBeingNull(logger, nameof(logger));
        }

        /// <summary>
        /// Provides a method to retrieve gender percentages.
        /// </summary>
        /// <param name="users">A value that represents a list of users in JSON format.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><b>Remarks:</b><br/><br/>To use this endpoint, one must provide a list of users in JSON format.</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("GetGenderPercentages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/JSON")]
        public async Task<IActionResult> GetGenderPercentages(User[] users)
        {
            try
            {
                GuardAgainst.ArgumentBeingNull(users, nameof(users));
                var result = await this.manageUser.GetGenderPercentages(users);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Provides a method to retrieve first name percentages.
        /// </summary>
        /// <param name="users">A value that represents a list of users in JSON format.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><b>Remarks:</b><br/><br/>To use this endpoint, one must provide a list of users in JSON format.</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("GetFirstNamePercentages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/JSON")]
        public async Task<IActionResult> GetFirstNamePercentages(User[] users)
        {
            try
            {
                GuardAgainst.ArgumentBeingNull(users, nameof(users));
                var result = await this.manageUser.GetFirstNamePercentages(users);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Provides a method to retrieve last name percentages.
        /// </summary>
        /// <param name="users">A value that represents a list of users in JSON format.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><b>Remarks:</b><br/><br/>To use this endpoint, one must provide a list of users in JSON format.</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("GetLastNamePercentages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/JSON")]
        public async Task<IActionResult> GetLastNamePercentages(User[] users)
        {
            try
            {
                GuardAgainst.ArgumentBeingNull(users, nameof(users));
                var result = await this.manageUser.GetLastNamePercentages(users);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Provides a method to retrieve last name percentages.
        /// </summary>
        /// <param name="users">A value that represents a list of users in JSON format.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><b>Remarks:</b><br/><br/>To use this endpoint, one must provide a list of users in JSON format.</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("GetStatePopulationPercentages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/JSON")]
        public async Task<IActionResult> GetStatePopulationPercentages(User[] users)
        {
            try
            {
                GuardAgainst.ArgumentBeingNull(users, nameof(users));
                var result = await this.manageUser.GetStatePopulationPercentages(users);
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }
    }
}