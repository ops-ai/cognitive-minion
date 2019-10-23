using System;

namespace CognitiveMinion.Api.Models
{
    public class MinionRequestInfoModel
    {
        /// <summary>
        /// Unique Id of the request
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Request status
        /// </summary>
        public RequestStatus Status { get; set; }

        /// <summary>
        /// Date the request was received
        /// </summary>
        public DateTime DateRequestedUtc { get; set; }

        /// <summary>
        /// The raw text of the request
        /// </summary>
        public string Request { get; set; }
    }
}
