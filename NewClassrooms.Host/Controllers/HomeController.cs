// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides an implementation of <see cref="Controller"/>.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Provides a method to return a default view.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
