// -----------------------------------------------------------------------
// <copyright file="PopulationPercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity
{
    using GuardAgainstLib;
    using NewClassrooms.Entity.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="IPopulationPercentageEntity"/>.
    /// </summary>
    public abstract class PopulationPercentageEntity : IPopulationPercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PopulationPercentageEntity"/> class.
        /// </summary>
        /// <param name="name">A value that represents the name of the state.</param>
        /// <param name="percentage">A value that represents the percentage of the state population.</param>
        public PopulationPercentageEntity(string name, double percentage)
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
