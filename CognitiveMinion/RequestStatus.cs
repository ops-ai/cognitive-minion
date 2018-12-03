namespace CognitiveMinion
{
    public enum RequestStatus
    {
        /// <summary>
        /// Intent detected and waiting for approval
        /// </summary>
        Pending,

        /// <summary>
        /// Request was approved
        /// </summary>
        Approved,

        /// <summary>
        /// Failed to identify intent
        /// </summary>
        Failed,

        /// <summary>
        /// Request was denied
        /// </summary>
        Denied,

        /// <summary>
        /// Request was cancelled
        /// </summary>
        Cancelled,

        /// <summary>
        /// Request expired waiting for user answer
        /// </summary>
        Expired
    }
}
