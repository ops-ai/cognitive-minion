using System;
using System.Collections.Generic;

namespace CognitiveMinion
{
    public class PredictionResult
    {
        /// <summary>
        /// Intent name
        /// </summary>
        public string IntentName { get; set; }

        /// <summary>
        /// Detected parameters
        /// </summary>
        public IDictionary<string, object> IntentParameters { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Prediction score
        /// </summary>
        public double? Score { get; set; }
    }
}
