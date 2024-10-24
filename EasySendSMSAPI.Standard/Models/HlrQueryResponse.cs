// <copyright file="HlrQueryResponse.cs" company="APIMatic">
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
    /// HlrQueryResponse.
    /// </summary>
    public class HlrQueryResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HlrQueryResponse"/> class.
        /// </summary>
        public HlrQueryResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HlrQueryResponse"/> class.
        /// </summary>
        /// <param name="responses">responses.</param>
        public HlrQueryResponse(
            Dictionary<string, Models.Responses> responses = null)
        {
            this.Responses = responses;
        }

        /// <summary>
        /// Gets or sets Responses.
        /// </summary>
        [JsonProperty("responses", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Models.Responses> Responses { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"HlrQueryResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is HlrQueryResponse other &&                ((this.Responses == null && other.Responses == null) || (this.Responses?.Equals(other.Responses) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"Responses = {(this.Responses == null ? "null" : this.Responses.ToString())}");
        }
    }
}