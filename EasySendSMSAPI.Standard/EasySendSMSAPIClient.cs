// <copyright file="EasySendSMSAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Linq;
using APIMatic.Core;
using APIMatic.Core.Authentication;
using EasySendSMSAPI.Standard.Authentication;
using EasySendSMSAPI.Standard.Controllers;
using EasySendSMSAPI.Standard.Http.Client;
using EasySendSMSAPI.Standard.Utilities;

namespace EasySendSMSAPI.Standard
{
    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class EasySendSMSAPIClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://restapi.easysendsms.app/v1" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly HttpCallback httpCallback;
        private readonly Lazy<APIController> client;

        private EasySendSMSAPIClient(
            Environment environment,
            CustomHeaderAuthenticationModel customHeaderAuthenticationModel,
            HttpCallback httpCallback,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallback = httpCallback;
            this.HttpClientConfiguration = httpClientConfiguration;
            CustomHeaderAuthenticationModel = customHeaderAuthenticationModel;
            var customHeaderAuthenticationManager = new CustomHeaderAuthenticationManager(customHeaderAuthenticationModel);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                    {"apiKeyAuth", customHeaderAuthenticationManager},
                })
                .ApiCallback(httpCallback)
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .UserAgent(userAgent)
                .Build();

            CustomHeaderAuthenticationCredentials = customHeaderAuthenticationManager;

            this.client = new Lazy<APIController>(
                () => new APIController(globalConfiguration));
        }

        /// <summary>
        /// Gets APIController controller.
        /// </summary>
        public APIController APIController => this.client.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets http callback.
        /// </summary>
        public HttpCallback HttpCallback => this.httpCallback;

        /// <summary>
        /// Gets the credentials to use with CustomHeaderAuthentication.
        /// </summary>
        public ICustomHeaderAuthenticationCredentials CustomHeaderAuthenticationCredentials { get; private set; }

        /// <summary>
        /// Gets the credentials model to use with CustomHeaderAuthentication.
        /// </summary>
        public CustomHeaderAuthenticationModel CustomHeaderAuthenticationModel { get; private set; }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the EasySendSMSAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .HttpCallback(httpCallback)
                .HttpClientConfig(config => config.Build());

            if (CustomHeaderAuthenticationModel != null)
            {
                builder.CustomHeaderAuthenticationCredentials(CustomHeaderAuthenticationModel.ToBuilder().Build());
            }

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> EasySendSMSAPIClient.</returns>
        internal static EasySendSMSAPIClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("EASY_SEND_SMSAPI_STANDARD_ENVIRONMENT");
            string apikey = System.Environment.GetEnvironmentVariable("EASY_SEND_SMSAPI_STANDARD_APIKEY");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (apikey != null)
            {
                builder.CustomHeaderAuthenticationCredentials(new CustomHeaderAuthenticationModel
                .Builder(apikey)
                .Build());
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = EasySendSMSAPI.Standard.Environment.Production;
            private CustomHeaderAuthenticationModel customHeaderAuthenticationModel = new CustomHeaderAuthenticationModel();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private HttpCallback httpCallback;

            /// <summary>
            /// Sets credentials for CustomHeaderAuthentication.
            /// </summary>
            /// <param name="apikey">Apikey.</param>
            /// <returns>Builder.</returns>
            [Obsolete("This method is deprecated. Use CustomHeaderAuthenticationCredentials(customHeaderAuthenticationModel) instead.")]
            public Builder CustomHeaderAuthenticationCredentials(string apikey)
            {
                customHeaderAuthenticationModel = customHeaderAuthenticationModel.ToBuilder()
                    .Apikey(apikey)
                    .Build();
                return this;
            }

            /// <summary>
            /// Sets credentials for CustomHeaderAuthentication.
            /// </summary>
            /// <param name="customHeaderAuthenticationModel">CustomHeaderAuthenticationModel.</param>
            /// <returns>Builder.</returns>
            public Builder CustomHeaderAuthenticationCredentials(CustomHeaderAuthenticationModel customHeaderAuthenticationModel)
            {
                if (customHeaderAuthenticationModel is null)
                {
                    throw new ArgumentNullException(nameof(customHeaderAuthenticationModel));
                }

                this.customHeaderAuthenticationModel = customHeaderAuthenticationModel;
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }



            /// <summary>
            /// Sets the HttpCallback for the Builder.
            /// </summary>
            /// <param name="httpCallback"> http callback. </param>
            /// <returns>Builder.</returns>
            public Builder HttpCallback(HttpCallback httpCallback)
            {
                this.httpCallback = httpCallback;
                return this;
            }

            /// <summary>
            /// Creates an object of the EasySendSMSAPIClient using the values provided for the builder.
            /// </summary>
            /// <returns>EasySendSMSAPIClient.</returns>
            public EasySendSMSAPIClient Build()
            {
                if (customHeaderAuthenticationModel.Apikey == null)
                {
                    customHeaderAuthenticationModel = null;
                }
                return new EasySendSMSAPIClient(
                    environment,
                    customHeaderAuthenticationModel,
                    httpCallback,
                    httpClientConfig.Build());
            }
        }
    }
}
