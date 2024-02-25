// -----------------------------------------------------------------------
// <copyright file="PercentageEntity.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Entity.DTO
{
    /// <summary>
    /// Provides a DTO for percentage entities.
    /// </summary>
    public class PercentageEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PercentageEntity"/> class.
        /// </summary>
        public PercentageEntity()
        {
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets Percentage.
        /// </summary>
        public string Percentage { get; set; } = null!;
    }
}
