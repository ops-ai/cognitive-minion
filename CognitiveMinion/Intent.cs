namespace CognitiveMinion
{
    public class Intent
    {
        /// <summary>
        /// Unique Id of the intent
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Intent name
        /// </summary>
        public string IntentName { get; set; }

        /// <summary>
        /// Intent owner
        /// </summary>
        public string IntentOwner { get; set; }

        /// <summary>
        /// The unique secret key for confirming or cancelling the request
        /// </summary>
        public string Secret { get; set; }
    }
}
