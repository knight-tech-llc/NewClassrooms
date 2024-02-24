// -----------------------------------------------------------------------
// <copyright file="IUser.cs" company="Knight Technologies LLC">
// Author: Shawn W Knight
// Copyright (c) Knight Technologies LLC All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NewClassrooms.Core.Model.Interface
{
    /// <summary>
    /// Provides an interface for User.
    /// </summary>
    public interface IUser
    {
        string Gender { get; set; }
        Name Name { get; set; }
        string Email { get; set; }
        Login Login { get; set; }
        string Nat { get; set; }
        Picture Picture { get; set; }
        Id Id { get; set; }
        Dob Dob { get; set; }
        Registered Registered { get; set; }
        string Phone { get; set; }
        string Cell { get; set; }
        Location Location { get; set; }
    }
}
