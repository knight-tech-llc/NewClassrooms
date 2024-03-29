﻿// -----------------------------------------------------------------------
// <copyright file="AgeRangePercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity
{
    using GuardAgainstLib;
    using NewClassrooms.Entity.Interface;

    /// <summary>
    /// Provides an implementation of <see cref="IAgeRangePercentageEntity"/>.
    /// </summary>
    public sealed class AgeRangePercentageEntity : IAgeRangePercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgeRangePercentageEntity"/> class.
        /// </summary>
        /// <param name="name">A value that represents the name of the age range.</param>
        /// <param name="percentage">A value that represents the percentage of the age.</param>
        public AgeRangePercentageEntity(string name, double percentage)
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
