// <copyright file="CustomHeaderAuthenticationManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasySendSMSAPI.Standard.Http.Request;
using APIMatic.Core.Authentication;

namespace EasySendSMSAPI.Standard.Authentication
{
    /// <summary>
    /// CustomHeaderAuthenticationManager Class.
    /// </summary>
    internal class CustomHeaderAuthenticationManager : AuthManager, ICustomHeaderAuthenticationCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomHeaderAuthenticationManager"/> class.
        /// </summary>
        /// <param name="customHeaderAuthentication">CustomHeaderAuthentication.</param>
        public CustomHeaderAuthenticationManager(CustomHeaderAuthenticationModel customHeaderAuthenticationModel)
        {
            Apikey = customHeaderAuthenticationModel?.Apikey;
            Parameters(paramBuilder => paramBuilder
                .Header(header => header.Setup("apikey", Apikey).Required())
            );
        }

        /// <summary>
        /// Gets string value for apikey.
        /// </summary>
        public string Apikey { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="apikey"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string apikey)
        {
            return apikey.Equals(this.Apikey);
        }
    }

    public sealed class CustomHeaderAuthenticationModel
    {
        internal CustomHeaderAuthenticationModel()
        {
        }

        internal string Apikey { get; set; }

        /// <summary>
        /// Creates an object of the CustomHeaderAuthenticationModel using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            return new Builder(Apikey);
        }

        /// <summary>
        /// Builder class for CustomHeaderAuthenticationModel.
        /// </summary>
        public class Builder
        {
            private string apikey;

            public Builder(string apikey)
            {
                this.apikey = apikey ?? throw new ArgumentNullException(nameof(apikey));
            }

            /// <summary>
            /// Sets Apikey.
            /// </summary>
            /// <param name="apikey">Apikey.</param>
            /// <returns>Builder.</returns>
            public Builder Apikey(string apikey)
            {
                this.apikey = apikey ?? throw new ArgumentNullException(nameof(apikey));
                return this;
            }


            /// <summary>
            /// Creates an object of the CustomHeaderAuthenticationModel using the values provided for the builder.
            /// </summary>
            /// <returns>CustomHeaderAuthenticationModel.</returns>
            public CustomHeaderAuthenticationModel Build()
            {
                return new CustomHeaderAuthenticationModel()
                {
                    Apikey = this.apikey
                };
            }
        }
    }
    
}