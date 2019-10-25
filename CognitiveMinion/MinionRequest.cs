using System;
using System.Collections.Generic;

namespace CognitiveMinion
{
    public class MinionRequest
    {
        /// <summary>
        /// Unique Id of the request
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The raw text of the request
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Identified intent name
        /// </summary>
        public string IntentName { get; set; }

        /// <summary>
        /// Detected parameters
        /// </summary>
        public Dictionary<string, object> IntentParameters { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Request status
        /// </summary>
        public RequestStatus Status { get; set; }

        /// <summary>
        /// Date the request was received
        /// </summary>
        public DateTime DateRequestedUtc { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Date the request expires
        /// </summary>
        public DateTime ExpirationUtc { get; set; } = DateTime.UtcNow.AddMonths(1);

        /// <summary>
        /// The unique secret key for confirming or cancelling the request
        /// </summary>
        public string Secret { get; set; }
    }
}
