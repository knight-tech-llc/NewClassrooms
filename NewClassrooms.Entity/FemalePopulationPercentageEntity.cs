// -----------------------------------------------------------------------
// <copyright file="FemalePopulationPercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity
{
    /// <summary>
    /// Provides an implementation of <see cref="PopulationPercentageEntity"/>.
    /// </summary>
    public sealed class FemalePopulationPercentageEntity : PopulationPercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FemalePopulationPercentageEntity"/> class.
        /// </summary>
        /// <param name="name">A value that represents the name of the state.</param>
        /// <param name="percentage">A value that represents the percentage of the female population.</param>
        public FemalePopulationPercentageEntity(string name, double percentage)
            : base(name, percentage)
        {
        }
    }
}
