// <copyright file="NvQueryResponse.cs" company="APIMatic">
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
    /// NvQueryResponse.
    /// </summary>
    public class NvQueryResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NvQueryResponse"/> class.
        /// </summary>
        public NvQueryResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NvQueryResponse"/> class.
        /// </summary>
        /// <param name="validations">validations.</param>
        public NvQueryResponse(
            List<Models.Validation> validations = null)
        {
            this.Validations = validations;
        }

        /// <summary>
        /// Gets or sets Validations.
        /// </summary>
        [JsonProperty("validations", NullValueHandling = NullValueHandling.Ignore)]
        public List<Models.Validation> Validations { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"NvQueryResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is NvQueryResponse other &&                ((this.Validations == null && other.Validations == null) || (this.Validations?.Equals(other.Validations) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Validations = {(this.Validations == null ? "null" : $"[{string.Join(", ", this.Validations)} ]")}");
        }
    }
}