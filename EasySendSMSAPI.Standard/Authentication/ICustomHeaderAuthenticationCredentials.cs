// <copyright file="ICustomHeaderAuthenticationCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;

namespace EasySendSMSAPI.Standard.Authentication
{
    /// <summary>
    /// Authentication configuration interface for CustomHeaderAuthentication.
    /// </summary>
    public interface ICustomHeaderAuthenticationCredentials
    {
        /// <summary>
        /// Gets string value for apikey.
        /// </summary>
        string Apikey { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="apikey"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string apikey);
    }
}