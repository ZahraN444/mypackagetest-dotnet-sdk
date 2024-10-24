// <copyright file="NvQueryRequest.cs" company="APIMatic">
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
    /// NvQueryRequest.
    /// </summary>
    public class NvQueryRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NvQueryRequest"/> class.
        /// </summary>
        public NvQueryRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NvQueryRequest"/> class.
        /// </summary>
        /// <param name="number">number.</param>
        public NvQueryRequest(
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

            return $"NvQueryRequest : ({string.Join(", ", toStringOutput)})";
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
            return obj is NvQueryRequest other &&                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true));
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