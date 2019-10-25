using System;
using System.Collections.Generic;
using System.Text;

namespace CognitiveMinion.LanguageUnderstanding.LuisAI
{
    public class LuisAiSettings
    {
        /// <summary>
        /// Azure subscription key
        /// </summary>
        public string SubscriptionKey { get; set; }

        /// <summary>
        /// Azure region
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// App Id
        /// </summary>
        public Guid AppId { get; set; }

        /// <summary>
        /// Slot. Ex: Staging or Production
        /// </summary>
        public string Slot { get; set; }
    }
}
