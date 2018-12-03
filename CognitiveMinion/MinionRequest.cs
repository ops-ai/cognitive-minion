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
        /// Identified intent name
        /// </summary>
        public string IntentName { get; set; }

        /// <summary>
        /// Detected parameters
        /// </summary>
        public Dictionary<string, string> IntentParameters { get; set; }

        /// <summary>
        /// Request status
        /// </summary>
        public RequestStatus Status { get; set; }

        /// <summary>
        /// Date the request was received
        /// </summary>
        public DateTime DateRequestedUtc { get; set; }

        /// <summary>
        /// Date the request expires
        /// </summary>
        public DateTime ExpirationUtc { get; set; }

        /// <summary>
        /// The unique secret key for confirming or cancelling the request
        /// </summary>
        public string Secret { get; set; }
    }
}
