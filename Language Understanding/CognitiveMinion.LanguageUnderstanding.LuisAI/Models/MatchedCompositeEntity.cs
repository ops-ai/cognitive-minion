using System.Collections.Generic;

namespace CognitiveMinion.LanguageUnderstanding.LuisAI.Models
{
    public class MatchedCompositeEntity
    {
        public string ParentType { get; set; }

        public object Value { get; set; }

        public List<MatchedCompositeEntityResolution> Children { get; set; }
    }
}
