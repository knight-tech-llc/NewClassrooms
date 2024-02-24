// -----------------------------------------------------------------------
// <copyright file="UserEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity
{
    using GuardAgainstLib;
    using NewClassrooms.Entity.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="IUserEntity"/>.
    /// </summary>
    public class UserEntity : IUserEntity
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UserEntity"/> class.
        /// </summary>
        /// <param name="firstName">A value that represents the first name of the <see cref="UserEntity"/>.</param>
        /// <param name="lastName">A value that represents the last name of the <see cref="UserEntity"/>.</param>
        /// <param name="age">A value that represents the age of the <see cref="UserEntity"/>.</param>
        /// <param name="gender">A value that represents the gender of the <see cref="UserEntity"/>.</param>
        /// <param name="state">A value that represents the state in which the <see cref="UserEntity"/> resides.</param>
        public UserEntity(string firstName, string lastName, int age, string gender, string state)
        {
            this.FirstName = GuardAgainst.ArgumentBeingNullOrEmpty(firstName, nameof(firstName));
            this.LastName = GuardAgainst.ArgumentBeingNullOrEmpty(lastName, nameof(lastName));
            this.Age = GuardAgainst.ArgumentBeingOutOfRange(age, 0, 100, nameof(age));
            this.Gender = GuardAgainst.ArgumentBeingNullOrEmpty(gender, nameof(gender));
            this.State = GuardAgainst.ArgumentBeingNullOrEmpty(state, nameof(state));
        }

        /// <inheritdoc/>
        public string FirstName { get; private set; }

        /// <inheritdoc/>
        public string LastName { get; private set; }

        /// <inheritdoc/>
        public int Age { get; private set; }

        /// <inheritdoc/>
        public string Gender { get; private set; }

        /// <inheritdoc/>
        public string State { get; private set; }
    }
}