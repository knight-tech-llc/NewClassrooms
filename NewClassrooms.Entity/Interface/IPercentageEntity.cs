// -----------------------------------------------------------------------
// <copyright file="IPercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity.Interface
{
    /// <summary>
    /// Provides an interface for percentage entities.
    /// </summary>
    public interface IPercentageEntity
    {
        /// <summary>
        /// Gets Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets Percentage.
        /// </summary>
        double Percentage { get; }
    }
}