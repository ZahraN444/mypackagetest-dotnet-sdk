// <copyright file="HlrQueryRequest.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIMatic.Core.Utilities.Converters;
using EasySendSMSAPI.Standard;
using EasySendSMSAPI.Standard.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EasySendSMSAPI.Standard.Models
{
    /// <summary>
    /// HlrQueryRequest.
    /// </summary>
    public class HlrQueryRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HlrQueryRequest"/> class.
        /// </summary>
        public HlrQueryRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HlrQueryRequest"/> class.
        /// </summary>
        /// <param name="number">number.</param>
        public HlrQueryRequest(
            string number)
        {
            this.Number = number;
        }

        /// <summary>
        /// Subscriber's MSISDN to be checked. Multiple numbers can be queried using commas, max 30 per request.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"HlrQueryRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            return obj is HlrQueryRequest other &&                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number)}");
        }
    }
}