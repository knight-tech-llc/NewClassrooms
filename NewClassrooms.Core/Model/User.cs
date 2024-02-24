// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Core.Model
{
    using NewClassrooms.Core.Model.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="IUser"/>.
    /// </summary>
    public class User : IUser
    {
        /// <inheritdoc/>
        public string Gender { get; set; } = null!;

        /// <inheritdoc/>
        public Name Name { get; set; } = null!;

        /// <inheritdoc/>
        public Location Location { get; set; } = null!;

        /// <inheritdoc/>
        public string Email { get; set; } = null!;

        /// <inheritdoc/>
        public Login Login { get; set; } = null!;

        /// <inheritdoc/>
        public Dob Dob { get; set; } = null!;

        /// <inheritdoc/>
        public Registered Registered { get; set; } = null!;

        /// <inheritdoc/>
        public string Phone { get; set; } = null!;

        /// <inheritdoc/>
        public string Cell { get; set; } = null!;

        /// <inheritdoc/>
        public Id Id { get; set; } = null!;

        /// <inheritdoc/>
        public Picture Picture { get; set; } = null!;

        /// <inheritdoc/>
        public string Nat { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Name.
    /// </summary>
    public class Name
    {
        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Gets or sets First.
        /// </summary>
        public string First { get; set; } = null!;

        /// <summary>
        /// Gets or sets Last.
        /// </summary>
        public string Last { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets Street.
        /// </summary>
        public Street Street { get; set; } = null!;

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public string City { get; set; } = null!;

        /// <summary>
        /// Gets or sets Street.
        /// </summary>
        public string State { get; set; } = null!;

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Gets or sets Postcode.
        /// </summary>
        public int Postcode { get; set; }

        /// <summary>
        /// Gets or sets Coordinates.
        /// </summary>
        public Coordinates Coordinates { get; set; } = null!;

        /// <summary>
        /// Gets or sets Timezone.
        /// </summary>
        public Timezone Timezone { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Street.
    /// </summary>
    public class Street
    {
        /// <summary>
        /// Gets or sets Number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Coordinates.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Gets or sets Latitude.
        /// </summary>
        public string Latitude { get; set; } = null!;

        /// <summary>
        /// Gets or sets Longitude.
        /// </summary>
        public string Longitude { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Timezone.
    /// </summary>
    public class Timezone
    {

        /// <summary>
        /// Gets or sets Offset.
        /// </summary>
        public string Offset { get; set; } = null!;

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Login.
    /// </summary>
    public class Login
    {
        /// <summary>
        /// Gets or sets Uuid.
        /// </summary>
        public string Uuid { get; set; } = null!;

        /// <summary>
        /// Gets or sets Username.
        /// </summary>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets Salt.
        /// </summary>
        public string Salt { get; set; } = null!;

        /// <summary>
        /// Gets or sets Md5.
        /// </summary>
        public string Md5 { get; set; } = null!;

        /// <summary>
        /// Gets or sets Sha1.
        /// </summary>
        public string Sha1 { get; set; } = null!;

        /// <summary>
        /// Gets or sets Sha256.
        /// </summary>
        public string Sha256 { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Dob.
    /// </summary>
    public class Dob
    {
        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Age.
        /// </summary>
        public int Age { get; set; }
    }

    /// <summary>
    /// Provides a DTO for Registered.
    /// </summary>
    public class Registered
    {
        /// <summary>
        /// Gets or sets Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets Age.
        /// </summary>
        public int Age { get; set; }
    }

    /// <summary>
    /// Provides a DTO for Id.
    /// </summary>
    public class Id
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets Value.
        /// </summary>
        public string Value { get; set; } = null!;
    }

    /// <summary>
    /// Provides a DTO for Picture.
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// Gets or sets Large.
        /// </summary>
        public string Large { get; set; } = null!;

        /// <summary>
        /// Gets or sets Medium.
        /// </summary>
        public string Medium { get; set; } = null!;

        /// <summary>
        /// Gets or sets Thumbnail.
        /// </summary>
        public string Thumbnail { get; set; } = null!;
    }
}
