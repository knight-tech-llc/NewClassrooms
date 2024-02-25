// -----------------------------------------------------------------------
// <copyright file="NamePercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity.Abstract
{
    using GuardAgainstLib;
    using NewClassrooms.Entity.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="INamePercentageEntity"/>.
    /// </summary>
    public abstract class NamePercentageEntity : INamePercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamePercentageEntity"/> class.
        /// </summary>
        /// <param name="name">A value that represents the first or last name.</param>
        /// <param name="percentage">A value that represents the percentage of the name.</param>
        public NamePercentageEntity(string name, double percentage)
        {
            this.Name = GuardAgainst.ArgumentBeingNullOrEmpty(name, nameof(name));
            this.Percentage = GuardAgainst.ArgumentBeingOutOfRange(percentage, 0, 100, nameof(percentage));
        }

        /// <inheritdoc/>
        public string Name { get; private set; }

        /// <inheritdoc/>
        public double Percentage { get; private set; }
    }
}
