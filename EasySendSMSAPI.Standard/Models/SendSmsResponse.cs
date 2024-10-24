// <copyright file="SendSmsResponse.cs" company="APIMatic">
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
    /// SendSmsResponse.
    /// </summary>
    public class SendSmsResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsResponse"/> class.
        /// </summary>
        public SendSmsResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsResponse"/> class.
        /// </summary>
        /// <param name="status">status.</param>
        /// <param name="scheduled">scheduled.</param>
        /// <param name="messageIds">messageIds.</param>
        public SendSmsResponse(
            string status = null,
            string scheduled = null,
            List<string> messageIds = null)
        {
            this.Status = status;
            this.Scheduled = scheduled;
            this.MessageIds = messageIds;
        }

        /// <summary>
        /// Gets or sets Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets Scheduled.
        /// </summary>
        [JsonProperty("scheduled", NullValueHandling = NullValueHandling.Ignore)]
        public string Scheduled { get; set; }

        /// <summary>
        /// Gets or sets MessageIds.
        /// </summary>
        [JsonProperty("messageIds", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MessageIds { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SendSmsResponse : ({string.Join(", ", toStringOutput)})";
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
            return obj is SendSmsResponse other &&                ((this.Status == null && other.Status == null) || (this.Status?.Equals(other.Status) == true)) &&
                ((this.Scheduled == null && other.Scheduled == null) || (this.Scheduled?.Equals(other.Scheduled) == true)) &&
                ((this.MessageIds == null && other.MessageIds == null) || (this.MessageIds?.Equals(other.MessageIds) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Status = {(this.Status == null ? "null" : this.Status)}");
            toStringOutput.Add($"this.Scheduled = {(this.Scheduled == null ? "null" : this.Scheduled)}");
            toStringOutput.Add($"this.MessageIds = {(this.MessageIds == null ? "null" : $"[{string.Join(", ", this.MessageIds)} ]")}");
        }
    }
}