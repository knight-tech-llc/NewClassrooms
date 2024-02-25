// -----------------------------------------------------------------------
// <copyright file="FirstNamePercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity
{
    using NewClassrooms.Entity.Abstract;

    /// <summary>
    /// Provides an implementation of <see cref="NamePercentageEntity"/>.
    /// </summary>
    public sealed class FirstNamePercentageEntity : NamePercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstNamePercentageEntity"/> class.
        /// </summary>
        /// <param name="name">A value that represents the first or last name.</param>
        /// <param name="percentage">A value that represents the percentage of the first name.</param>
        public FirstNamePercentageEntity(string name, double percentage)
            : base(name, percentage)
        {
        }
    }
}
