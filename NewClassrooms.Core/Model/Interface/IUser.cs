// -----------------------------------------------------------------------
// <copyright file="IUser.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Core.Model.Interface
{
    /// <summary>
    /// Provides an interface for User.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets or sets Gender.
        /// </summary>
        string Gender { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        Name Name { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets Login.
        /// </summary>
        Login Login { get; set; }

        /// <summary>
        /// Gets or sets Nat.
        /// </summary>
        string Nat { get; set; }

        /// <summary>
        /// Gets or sets Picture.
        /// </summary>
        Picture Picture { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        Id Id { get; set; }

        /// <summary>
        /// Gets or sets Dob.
        /// </summary>
        Dob Dob { get; set; }

        /// <summary>
        /// Gets or sets Registered.
        /// </summary>
        Registered Registered { get; set; }

        /// <summary>
        /// Gets or sets Phone.
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Gets or sets Cell.
        /// </summary>
        string Cell { get; set; }

        /// <summary>
        /// Gets or sets Location.
        /// </summary>
        Location Location { get; set; }
    }
}
