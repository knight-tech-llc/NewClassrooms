// -----------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Extension
{
    using GuardAgainstLib;
    using NewClassrooms.Core;
    using NewClassrooms.Core.Interface;
    using NewClassrooms.Service;
    using NewClassrooms.Service.Interface;

    /// <summary>
    /// Provides extension methods for Service Collections.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Provides a method to add Ports.
        /// </summary>
        /// <param name="services">A value that represents an implementation of <see cref="IServiceCollection"/>.</param>
        /// <returns>A value that represents the extended <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddPorts(this IServiceCollection services)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(services, nameof(services));

            services.AddTransient<IManageUser, ManageUser>();
            return services;
        }

        /// <summary>
        /// Provides a method to add Services.
        /// </summary>
        /// <param name="services">A value that represents an implementation of <see cref="IServiceCollection"/>.</param>
        /// <returns>A value that represents the extended <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            GuardAgainst.ArgumentBeingNullOrEmpty(services, nameof(services));

            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}