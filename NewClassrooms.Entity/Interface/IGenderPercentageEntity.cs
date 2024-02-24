// -----------------------------------------------------------------------
// <copyright file="IGenderPercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity.Interface
{
    /// <summary>
    /// Provides an interface for gender percentage.
    /// </summary>
    public interface IGenderPercentageEntity
    {
        /// <summary>
        /// Gets Gender.
        /// </summary>
        string Gender { get; }

        /// <summary>
        /// Gets Percentage.
        /// </summary>
        double Percentage { get; }
    }
}
