// -----------------------------------------------------------------------
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
    public class AgeRangePercentageEntity : IAgeRangePercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgeRangePercentageEntity"/> class.
        /// </summary>
        /// <param name="range">A value that represents the range.</param>
        /// <param name="percentage">A value that represents the percentage of the gender.</param>
        public AgeRangePercentageEntity(string range, double percentage)
        {
            this.Range = GuardAgainst.ArgumentBeingNullOrEmpty(range, nameof(range));
            this.Percentage = GuardAgainst.ArgumentBeingOutOfRange(percentage, 0, 100, nameof(percentage));
        }

        /// <inheritdoc/>
        public string Range { get; private set; }

        /// <inheritdoc/>
        public double Percentage { get; private set; }
    }
}
