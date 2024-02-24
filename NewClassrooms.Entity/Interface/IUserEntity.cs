// -----------------------------------------------------------------------
// <copyright file="IUserEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity.Interface
{
    /// <summary>
    /// Provides an interface for user entity.
    /// </summary>
    public interface IUserEntity
    {
        /// <summary>
        /// Gets FirstName.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Gets LastName.
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// Gets Age.
        /// </summary>
        int Age { get; }

        /// <summary>
        /// Gets Gender.
        /// </summary>
        string Gender { get; }

        /// <summary>
        /// Gets State.
        /// </summary>
        string State { get; }
    }
}
