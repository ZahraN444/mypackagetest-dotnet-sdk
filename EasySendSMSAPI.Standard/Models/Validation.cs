// <copyright file="Validation.cs" company="APIMatic">
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
    /// Validation.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Validation"/> class.
        /// </summary>
        public Validation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Validation"/> class.
        /// </summary>
        /// <param name="msisdn">msisdn.</param>
        /// <param name="status">status.</param>
        /// <param name="country">country.</param>
        /// <param name="iso31662">iso3166_2.</param>
        /// <param name="cc">cc.</param>
        /// <param name="netName">netName.</param>
        /// <param name="mcc">mcc.</param>
        /// <param name="mnc">mnc.</param>
        /// <param name="mOperator">operator.</param>
        /// <param name="type">type.</param>
        /// <param name="netType">netType.</param>
        public Validation(
            string msisdn = null,
            string status = null,
            string country = null,
            string iso31662 = null,
            string cc = null,
            string netName = null,
            string mcc = null,
            string mnc = null,
            string mOperator = null,
            string type = null,
            string netType = null)
        {
            this.Msisdn = msisdn;
            this.Status = status;
            this.Country = country;
            this.Iso31662 = iso31662;
            this.Cc = cc;
            this.NetName = netName;
            this.Mcc = mcc;
            this.Mnc = mnc;
            this.MOperator = mOperator;
            this.Type = type;
            this.NetType = netType;
        }

        /// <summary>
        /// Gets or sets Msisdn.
        /// </summary>
        [JsonProperty("msisdn", NullValueHandling = NullValueHandling.Ignore)]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets Iso31662.
        /// </summary>
        [JsonProperty("iso3166_2", NullValueHandling = NullValueHandling.Ignore)]
        public string Iso31662 { get; set; }

        /// <summary>
        /// Gets or sets Cc.
        /// </summary>
        [JsonProperty("cc", NullValueHandling = NullValueHandling.Ignore)]
        public string Cc { get; set; }

        /// <summary>
        /// Gets or sets NetName.
        /// </summary>
        [JsonProperty("netName", NullValueHandling = NullValueHandling.Ignore)]
        public string NetName { get; set; }

        /// <summary>
        /// Gets or sets Mcc.
        /// </summary>
        [JsonProperty("mcc", NullValueHandling = NullValueHandling.Ignore)]
        public string Mcc { get; set; }

        /// <summary>
        /// Gets or sets Mnc.
        /// </summary>
        [JsonProperty("mnc", NullValueHandling = NullValueHandling.Ignore)]
        public string Mnc { get; set; }

        /// <summary>
        /// Gets or sets MOperator.
        /// </summary>
        [JsonProperty("operator", NullValueHandling = NullValueHandling.Ignore)]
        public string MOperator { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets NetType.
        /// </summary>
        [JsonProperty("netType", NullValueHandling = NullValueHandling.Ignore)]
        public string NetType { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Validation : ({string.Join(", ", toStringOutput)})";
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
            return obj is Validation other &&                ((this.Msisdn == null && other.Msisdn == null) || (this.Msisdn?.Equals(other.Msisdn) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.Iso31662 == null && other.Iso31662 == null) || (this.Iso31662?.Equals(other.Iso31662) == true)) &&
                ((this.Cc == null && other.Cc == null) || (this.Cc?.Equals(other.Cc) == true)) &&
                ((this.NetName == null && other.NetName == null) || (this.NetName?.Equals(other.NetName) == true)) &&
                ((this.Mcc == null && other.Mcc == null) || (this.Mcc?.Equals(other.Mcc) == true)) &&
                ((this.Mnc == null && other.Mnc == null) || (this.Mnc?.Equals(other.Mnc) == true)) &&
                ((this.MOperator == null && other.MOperator == null) || (this.MOperator?.Equals(other.MOperator) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.NetType == null && other.NetType == null) || (this.NetType?.Equals(other.NetType) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Msisdn = {(this.Msisdn == null ? "null" : this.Msisdn)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country)}");
            toStringOutput.Add($"this.Iso31662 = {(this.Iso31662 == null ? "null" : this.Iso31662)}");
            toStringOutput.Add($"this.Cc = {(this.Cc == null ? "null" : this.Cc)}");
            toStringOutput.Add($"this.NetName = {(this.NetName == null ? "null" : this.NetName)}");
            toStringOutput.Add($"this.Mcc = {(this.Mcc == null ? "null" : this.Mcc)}");
            toStringOutput.Add($"this.Mnc = {(this.Mnc == null ? "null" : this.Mnc)}");
            toStringOutput.Add($"this.MOperator = {(this.MOperator == null ? "null" : this.MOperator)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.NetType = {(this.NetType == null ? "null" : this.NetType)}");
        }
    }
}