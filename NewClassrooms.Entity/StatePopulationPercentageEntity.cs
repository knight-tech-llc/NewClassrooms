﻿// -----------------------------------------------------------------------
// <copyright file="StatePopulationPercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity
{
    /// <summary>
    /// Provides an implementation of <see cref="PopulationPercentageEntity"/>.
    /// </summary>
    public sealed class StatePopulationPercentageEntity : PopulationPercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatePopulationPercentageEntity"/> class.
        /// </summary>
        /// <param name="name">A value that represents the name of the state.</param>
        /// <param name="percentage">A value that represents the percentage of the state population.</param>
        public StatePopulationPercentageEntity(string name, double percentage)
            : base(name, percentage)
        {
        }
    }
}
