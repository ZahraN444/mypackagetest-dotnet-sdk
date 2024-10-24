// <copyright file="Responses.cs" company="APIMatic">
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
    /// Responses.
    /// </summary>
    public class Responses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Responses"/> class.
        /// </summary>
        public Responses()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Responses"/> class.
        /// </summary>
        /// <param name="number">number.</param>
        /// <param name="country">country.</param>
        /// <param name="errDesc">err_desc.</param>
        /// <param name="operatorName">operatorName.</param>
        /// <param name="type">type.</param>
        /// <param name="mccmnc">mccmnc.</param>
        /// <param name="roaming">roaming.</param>
        /// <param name="errCode">err_code.</param>
        /// <param name="status">status.</param>
        /// <param name="ported">ported.</param>
        public Responses(
            string number = null,
            string country = null,
            string errDesc = null,
            string operatorName = null,
            string type = null,
            string mccmnc = null,
            string roaming = null,
            string errCode = null,
            string status = null,
            string ported = null)
        {
            this.Number = number;
            this.Country = country;
            this.ErrDesc = errDesc;
            this.OperatorName = operatorName;
            this.Type = type;
            this.Mccmnc = mccmnc;
            this.Roaming = roaming;
            this.ErrCode = errCode;
            this.Status = status;
            this.Ported = ported;
        }

        /// <summary>
        /// Gets or sets Number.
        /// </summary>
        [JsonProperty("number", NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        [JsonProperty("country", NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets ErrDesc.
        /// </summary>
        [JsonProperty("err_desc", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrDesc { get; set; }

        /// <summary>
        /// Gets or sets OperatorName.
        /// </summary>
        [JsonProperty("operatorName", NullValueHandling = NullValueHandling.Ignore)]
        public string OperatorName { get; set; }

        /// <summary>
        /// Gets or sets Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets Mccmnc.
        /// </summary>
        [JsonProperty("mccmnc", NullValueHandling = NullValueHandling.Ignore)]
        public string Mccmnc { get; set; }

        /// <summary>
        /// Gets or sets Roaming.
        /// </summary>
        [JsonProperty("roaming", NullValueHandling = NullValueHandling.Ignore)]
        public string Roaming { get; set; }

        /// <summary>
        /// Gets or sets ErrCode.
        /// </summary>
        [JsonProperty("err_code", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrCode { get; set; }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Ported.
        /// </summary>
        [JsonProperty("ported", NullValueHandling = NullValueHandling.Ignore)]
        public string Ported { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"Responses : ({string.Join(", ", toStringOutput)})";
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
            return obj is Responses other &&                ((this.Number == null && other.Number == null) || (this.Number?.Equals(other.Number) == true)) &&
                ((this.Country == null && other.Country == null) || (this.Country?.Equals(other.Country) == true)) &&
                ((this.ErrDesc == null && other.ErrDesc == null) || (this.ErrDesc?.Equals(other.ErrDesc) == true)) &&
                ((this.OperatorName == null && other.OperatorName == null) || (this.OperatorName?.Equals(other.OperatorName) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Mccmnc == null && other.Mccmnc == null) || (this.Mccmnc?.Equals(other.Mccmnc) == true)) &&
                ((this.Roaming == null && other.Roaming == null) || (this.Roaming?.Equals(other.Roaming) == true)) &&
                ((this.ErrCode == null && other.ErrCode == null) || (this.ErrCode?.Equals(other.ErrCode) == true)) &&
                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Ported == null && other.Ported == null) || (this.Ported?.Equals(other.Ported) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Number = {(this.Number == null ? "null" : this.Number)}");
            toStringOutput.Add($"this.Country = {(this.Country == null ? "null" : this.Country)}");
            toStringOutput.Add($"this.ErrDesc = {(this.ErrDesc == null ? "null" : this.ErrDesc)}");
            toStringOutput.Add($"this.OperatorName = {(this.OperatorName == null ? "null" : this.OperatorName)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.Mccmnc = {(this.Mccmnc == null ? "null" : this.Mccmnc)}");
            toStringOutput.Add($"this.Roaming = {(this.Roaming == null ? "null" : this.Roaming)}");
            toStringOutput.Add($"this.ErrCode = {(this.ErrCode == null ? "null" : this.ErrCode)}");
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
            toStringOutput.Add($"this.Ported = {(this.Ported == null ? "null" : this.Ported)}");
        }
    }
}