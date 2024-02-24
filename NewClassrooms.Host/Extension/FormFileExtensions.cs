// -----------------------------------------------------------------------
// <copyright file="FormFileExtensions.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Host.Extension
{
    using System.Runtime.CompilerServices;
    using System.Text;
    using GuardAgainstLib;

    /// <summary>
    /// Provides extension methods to <see cref="IFormFile"/>.
    /// </summary>
    public static class FormFileExtensions
    {
        /// <summary>
        /// Provides an extension method to return the bytes from <see cref="IFormFile"/>.
        /// </summary>
        /// <param name="formFile">The class to be extended.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            GuardAgainst.ArgumentBeingNull(formFile, nameof(formFile));
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        /// <summary>
        /// Provides a method to retrieve the string contents from <see cref="IFormFile"/>.
        /// </summary>
        /// <param name="formFile">The class to be extended.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task<string> ReadAsStringAsync(this IFormFile formFile)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(formFile.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.AppendLine(await reader.ReadLineAsync());
                }
            }

            return result.ToString();
        }
    }
}
