// <copyright file="APIController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using APIMatic.Core;
using APIMatic.Core.Types;
using APIMatic.Core.Utilities;
using APIMatic.Core.Utilities.Date.Xml;
using EasySendSMSAPI.Standard;
using EasySendSMSAPI.Standard.Exceptions;
using EasySendSMSAPI.Standard.Http.Client;
using EasySendSMSAPI.Standard.Utilities;
using Newtonsoft.Json.Converters;
using System.Net.Http;

namespace EasySendSMSAPI.Standard.Controllers
{
    /// <summary>
    /// APIController.
    /// </summary>
    public class APIController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIController"/> class.
        /// </summary>
        internal APIController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Send a single SMS message.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.SendSmsResponse response from the API call.</returns>
        public Models.SendSmsResponse SendSms(
                Models.SendSmsRequest body)
            => CoreHelper.RunTask(SendSmsAsync(body));

        /// <summary>
        /// Send a single SMS message.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SendSmsResponse response from the API call.</returns>
        public async Task<Models.SendSmsResponse> SendSmsAsync(
                Models.SendSmsRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SendSmsResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/rest/sms/send")
                  .WithAuth("apiKeyAuth")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad request", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("Too many requests", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal server error", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Retrieve the remaining balance for SMS messages.
        /// </summary>
        /// <returns>Returns the Models.BalanceResponse response from the API call.</returns>
        public Models.BalanceResponse GetSmsBalance()
            => CoreHelper.RunTask(GetSmsBalanceAsync());

        /// <summary>
        /// Retrieve the remaining balance for SMS messages.
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.BalanceResponse response from the API call.</returns>
        public async Task<Models.BalanceResponse> GetSmsBalanceAsync(CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.BalanceResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/rest/sms/balance")
                  .WithAuth("apiKeyAuth"))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad request", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("Too many requests", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal server error", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Perform an HLR (Home Location Register) query to check the status of a phone number.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.HlrQueryResponse response from the API call.</returns>
        public Models.HlrQueryResponse HlrQuery(
                Models.HlrQueryRequest body)
            => CoreHelper.RunTask(HlrQueryAsync(body));

        /// <summary>
        /// Perform an HLR (Home Location Register) query to check the status of a phone number.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.HlrQueryResponse response from the API call.</returns>
        public async Task<Models.HlrQueryResponse> HlrQueryAsync(
                Models.HlrQueryRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.HlrQueryResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/rest/hlr/query")
                  .WithAuth("apiKeyAuth")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad request", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("Too many requests", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal server error", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Perform a Number Validation (NV) query to validate a phone number.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <returns>Returns the Models.NvQueryResponse response from the API call.</returns>
        public Models.NvQueryResponse NvQuery(
                Models.NvQueryRequest body)
            => CoreHelper.RunTask(NvQueryAsync(body));

        /// <summary>
        /// Perform a Number Validation (NV) query to validate a phone number.
        /// </summary>
        /// <param name="body">Required parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.NvQueryResponse response from the API call.</returns>
        public async Task<Models.NvQueryResponse> NvQueryAsync(
                Models.NvQueryRequest body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.NvQueryResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/rest/nv/query")
                  .WithAuth("apiKeyAuth")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad request", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("401", CreateErrorCase("Unauthorized", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("429", CreateErrorCase("Too many requests", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("500", CreateErrorCase("Internal server error", (_reason, _context) => new ApiException(_reason, _context))))
              .ExecuteAsync(cancellationToken).ConfigureAwait(false);
    }
}