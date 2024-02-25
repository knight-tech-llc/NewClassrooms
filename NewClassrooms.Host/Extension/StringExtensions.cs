// -----------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Extension
{
    using System.Globalization;

    /// <summary>
    /// Provides an extension class for strings.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Provides a method to change case of a string to proper e.g. first becomes First.
        /// </summary>
        /// <param name="value">A value that represents the string to change to proper case.</param>
        /// <returns>A <see cref="string"/> value that represents the converted string.</returns>
        public static string ToProper(this string value)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(value.ToLower());
        }
    }
}
