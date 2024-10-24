// <copyright file="SendSmsRequest.cs" company="APIMatic">
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
    /// SendSmsRequest.
    /// </summary>
    public class SendSmsRequest
    {
        private DateTime? scheduled;
        private Dictionary<string, bool> shouldSerialize = new Dictionary<string, bool>
        {
            { "scheduled", false },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsRequest"/> class.
        /// </summary>
        public SendSmsRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSmsRequest"/> class.
        /// </summary>
        /// <param name="from">from.</param>
        /// <param name="to">to.</param>
        /// <param name="text">text.</param>
        /// <param name="type">type.</param>
        /// <param name="scheduled">scheduled.</param>
        public SendSmsRequest(
            string from,
            string to,
            string text,
            string type,
            DateTime? scheduled = null)
        {
            this.From = from;
            this.To = to;
            this.Text = text;
            this.Type = type;
            if (scheduled != null)
            {
                this.Scheduled = scheduled;
            }

        }

        /// <summary>
        /// Sender Name that the message will appear from. Max Length of 15 if numeric, 11 if alphanumeric.
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }

        /// <summary>
        /// Mobile number of the recipient. Use a comma to send to multiple numbers, max 30 per request.
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }

        /// <summary>
        /// The message to be sent, either in plain text or Unicode. Max length 5 parts.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Indicates the type of message. `0` for Plain text, `1` for Unicode.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The scheduled date and time for sending the message, formatted in ISO 8601.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        [JsonProperty("scheduled")]
        public DateTime? Scheduled
        {
            get
            {
                return this.scheduled;
            }

            set
            {
                this.shouldSerialize["scheduled"] = true;
                this.scheduled = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SendSmsRequest : ({string.Join(", ", toStringOutput)})";
        }

        /// <summary>
        /// Marks the field to not be serailized.
        /// </summary>
        public void UnsetScheduled()
        {
            this.shouldSerialize["scheduled"] = false;
        }

        /// <summary>
        /// Checks if the field should be serialized or not.
        /// </summary>
        /// <returns>A boolean weather the field should be serialized or not.</returns>
        public bool ShouldSerializeScheduled()
        {
            return this.shouldSerialize["scheduled"];
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
            return obj is SendSmsRequest other &&                ((this.From == null && other.From == null) || (this.From?.Equals(other.From) == true)) &&
                ((this.To == null && other.To == null) || (this.To?.Equals(other.To) == true)) &&
                ((this.Text == null && other.Text == null) || (this.Text?.Equals(other.Text) == true)) &&
                ((this.Type == null && other.Type == null) || (this.Type?.Equals(other.Type) == true)) &&
                ((this.Scheduled == null && other.Scheduled == null) || (this.Scheduled?.Equals(other.Scheduled) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.From = {(this.From == null ? "null" : this.From)}");
            toStringOutput.Add($"this.To = {(this.To == null ? "null" : this.To)}");
            toStringOutput.Add($"this.Text = {(this.Text == null ? "null" : this.Text)}");
            toStringOutput.Add($"this.Type = {(this.Type == null ? "null" : this.Type)}");
            toStringOutput.Add($"this.Scheduled = {(this.Scheduled == null ? "null" : this.Scheduled.ToString())}");
        }
    }
}