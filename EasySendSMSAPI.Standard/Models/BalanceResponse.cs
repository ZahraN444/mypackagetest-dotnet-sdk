// <copyright file="BalanceResponse.cs" company="APIMatic">
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
    /// BalanceResponse.
    /// </summary>
    public class BalanceResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse"/> class.
        /// </summary>
        public BalanceResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BalanceResponse"/> class.
        /// </summary>
        /// <param name="balance">balance.</param>
        public BalanceResponse(
            int? balance = null)
        {
            this.Balance = balance;
        }

        /// <summary>
        /// Gets or sets Balance.
        /// </summary>
        [JsonProperty("balance", NullValueHandling = NullValueHandling.Ignore)]
        public int? Balance { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"BalanceResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is BalanceResponse other &&                ((this.Balance == null && other.Balance == null) || (this.Balance?.Equals(other.Balance) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Balance = {(this.Balance == null ? "null" : this.Balance.ToString())}");
        }
    }
}