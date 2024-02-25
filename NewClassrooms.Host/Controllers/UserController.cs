// -----------------------------------------------------------------------
// <copyright file="UserController.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Controllers
{
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml.Serialization;
    using GuardAgainstLib;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using NewClassrooms.Core.Interface;
    using NewClassrooms.Core.Model;
    using NewClassrooms.Entity;
    using NewClassrooms.Entity.DTO;
    using NewClassrooms.Entity.Interface;
    using NewClassrooms.Host.Extension;

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

                var results = await this.manageUser.GetGenderPercentages(users);
                if (this.GetFormat() == "application/json" || this.GetFormat() == "*/*")
                {
                    return this.Ok(results);
                }
                else if (this.GetFormat() == "application/xml" || this.GetFormat() == "text/xml")
                {
                    var result = this.ConvertToXml(results);
                    return this.Ok(result);
                }
                else
                {
                    var result = this.CreateFormat(results);
                    return this.Ok(result);
                }
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

                var results = await this.manageUser.GetFirstNamePercentages(users);

                if (this.GetFormat() == "application/json" || this.GetFormat() == "*/*")
                {
                    return this.Ok(results);
                }
                else if (this.GetFormat() == "application/xml" || this.GetFormat() == "text/xml")
                {
                    var result = this.ConvertToXml(results);
                    return this.Ok(result);
                }
                else
                {
                    var result = this.CreateFormat(results);
                    return this.Ok(result);
                }
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

                var results = await this.manageUser.GetLastNamePercentages(users);

                if (this.GetFormat() == "application/json" || this.GetFormat() == "*/*")
                {
                    return this.Ok(results);
                }
                else if (this.GetFormat() == "application/xml" || this.GetFormat() == "text/xml")
                {
                    var result = this.ConvertToXml(results);
                    return this.Ok(result);
                }
                else
                {
                    var result = this.CreateFormat(results);
                    return this.Ok(result);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Provides a method to retrieve state population percentages.
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

                var results = await this.manageUser.GetStatePopulationPercentages(users);

                if (this.GetFormat() == "application/json" || this.GetFormat() == "*/*")
                {
                    return this.Ok(results);
                }
                else if (this.GetFormat() == "application/xml" || this.GetFormat() == "text/xml")
                {
                    var result = this.ConvertToXml(results);
                    return this.Ok(result);
                }
                else
                {
                    var result = this.CreateFormat(results);
                    return this.Ok(result);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Provides a method to retrieve male state population percentages.
        /// </summary>
        /// <param name="users">A value that represents a list of users in JSON format.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><b>Remarks:</b><br/><br/>To use this endpoint, one must provide a list of users in JSON format.</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("GetMalePopulationPercentages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/JSON")]
        public async Task<IActionResult> GetMalePopulationPercentages(User[] users)
        {
            try
            {
                GuardAgainst.ArgumentBeingNull(users, nameof(users));

                var results = await this.manageUser.GetMalePopulationPercentages(users);

                if (this.GetFormat() == "application/json" || this.GetFormat() == "*/*")
                {
                    return this.Ok(results);
                }
                else if (this.GetFormat() == "application/xml" || this.GetFormat() == "text/xml")
                {
                    var result = this.ConvertToXml(results);
                    return this.Ok(result);
                }
                else
                {
                    var result = this.CreateFormat(results);
                    return this.Ok(result);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Provides a method to retrieve female state population percentages.
        /// </summary>
        /// <param name="users">A value that represents a list of users in JSON format.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><b>Remarks:</b><br/><br/>To use this endpoint, one must provide a list of users in JSON format.</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("GetFemalePopulationPercentages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/JSON")]
        public async Task<IActionResult> GetFemalePopulationPercentages(User[] users)
        {
            try
            {
                GuardAgainst.ArgumentBeingNull(users, nameof(users));

                var results = await this.manageUser.GetFemalePopulationPercentages(users);

                if (this.GetFormat() == "application/json" || this.GetFormat() == "*/*")
                {
                    return this.Ok(results);
                }
                else if (this.GetFormat() == "application/xml" || this.GetFormat() == "text/xml")
                {
                    var result = this.ConvertToXml(results);
                    return this.Ok(result);
                }
                else
                {
                    var result = this.CreateFormat(results);
                    return this.Ok(result);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Provides a method to retrieve age range percentages.
        /// </summary>
        /// <param name="users">A value that represents a list of users in JSON format.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks><b>Remarks:</b><br/><br/>To use this endpoint, one must provide a list of users in JSON format.</remarks>
        [AllowAnonymous]
        [HttpPost]
        [Route("GetAgeRangePercentages")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        [Consumes("application/JSON")]
        public async Task<IActionResult> GetAgeRangePercentages(User[] users)
        {
            try
            {
                GuardAgainst.ArgumentBeingNull(users, nameof(users));

                var results = await this.manageUser.GetAgeRangePercentages(users);

                if (this.GetFormat() == "application/json" || this.GetFormat() == "*/*")
                {
                    return this.Ok(results);
                }
                else if (this.GetFormat() == "application/xml" || this.GetFormat() == "text/xml")
                {
                    var result = this.ConvertToXml(results);
                    return this.Ok(result);
                }
                else
                {
                    var result = this.CreateFormat(results);
                    return this.Ok(result);
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return this.BadRequest(ex.Message);
            }
        }

        private List<PercentageEntity> ConvertToXml<T>(List<T> results)
             where T : IPercentageEntity
        {
            var percentageEntities = new List<PercentageEntity>();

            foreach (var item in results)
            {
                percentageEntities.Add(new PercentageEntity() { Name = item.Name.ToProper(), Percentage = $"{Math.Round(item.Percentage, 2)}%" });
            }

            return percentageEntities;
        }

        private string ConvertToString<T>(List<T> results)
            where T : IPercentageEntity
        {
            var stringBuilder = new StringBuilder();
            var header = this.GetHeader(typeof(T).Name);
            stringBuilder.AppendLine(header);
            stringBuilder.AppendLine(new string('-', header.Length));
            foreach (var item in results)
            {
                var name = item.Name.ToProper();
                var percentage = $"{Math.Round(item.Percentage, 2)}%";
                stringBuilder.AppendLine($"{name}: {percentage}");
            }

            return stringBuilder.ToString();
        }

        private string ConvertToHtmlString<T>(List<T> results)
           where T : IPercentageEntity
        {
            var stringBuilder = new StringBuilder();
            var header = this.GetHeader(typeof(T).Name);
            stringBuilder.AppendLine("<!DOCTYPE html>");
            stringBuilder.AppendLine("<html>");
            stringBuilder.AppendLine("<head>");
            stringBuilder.AppendLine($"<title>{header}</title>");
            stringBuilder.AppendLine("<style>");
            stringBuilder.AppendLine("table {");
            stringBuilder.AppendLine("border-collapse: collapse; }");
            stringBuilder.AppendLine(" th, td {");
            stringBuilder.AppendLine(" border: 1px solid black;");
            stringBuilder.AppendLine(" padding: 8px;");
            stringBuilder.AppendLine(" text-align: left; }");
            stringBuilder.AppendLine("</style>");
            stringBuilder.AppendLine("</head>");
            stringBuilder.AppendLine("<body>");
            stringBuilder.AppendLine($"<div>{header}</div><br/>");
            stringBuilder.AppendLine("<table>");
            stringBuilder.AppendLine("<tr><th>Name</th><th>Percentage</th></tr>");
            foreach (var item in results)
            {
                var name = item.Name.ToProper();
                var percentage = $"{Math.Round(item.Percentage, 2)}%";
                stringBuilder.AppendLine("<tr>");
                stringBuilder.AppendLine($"<td>{name}</td><td>{percentage}</td>");
                stringBuilder.AppendLine("</tr>");
            }

            stringBuilder.AppendLine("</table>");
            stringBuilder.AppendLine("</body>");
            stringBuilder.AppendLine("</html>");
            return stringBuilder.ToString();
        }

        private string GetHeader(string name)
        {
            switch (name)
            {
                case nameof(GenderPercentageEntity):
                    return "Percentage of female versus male";

                case nameof(AgeRangePercentageEntity):
                    return "Percentage of people in the following age ranges: 0-20, 21-40, 41-60, 61-80, 81-100, 100+";

                case nameof(LastNamePercentageEntity):
                    return $"Percentage of last names that start with A-M versus N-Z";

                case nameof(FirstNamePercentageEntity):
                    return $"Percentage of first names that start with A-M versus N-Z";

                case nameof(StatePopulationPercentageEntity):
                    return "Percentage of people in each state up to the 10 most populous states.";

                case nameof(FemalePopulationPercentageEntity):
                    return "Percentage of females in each state up to the 10 most populous states.";

                case nameof(MalePopulationPercentageEntity):
                    return "Percentage of males in each state up to the 10 most populous states.";

                default:
                    throw new ArgumentException($"{name} is not supported.");
            }
        }

        private string GetFormat()
        {
            string format = "application/json";
            if (this.Request is not null)
            {
                this.Request.Headers.TryGetValue("Accept", out var acceptHeaderValue);
                format = acceptHeaderValue.ToString();
            }

            return format;
        }

        private string CreateFormat<T>(List<T> results)
            where T : IPercentageEntity
        {
            if (this.GetFormat() == "text/plain")
            {
                return this.ConvertToString(results);
            }
            else if (this.GetFormat() == "text/html")
            {
                return this.ConvertToHtmlString(results);
            }

            throw new Exception("Format not supported.");
        }
    }
}