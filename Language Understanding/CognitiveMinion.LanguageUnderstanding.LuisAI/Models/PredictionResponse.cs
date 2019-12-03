using System.Collections.Generic;

namespace CognitiveMinion.LanguageUnderstanding.LuisAI.Models
{
    public class PredictionResponse
    {
        public string Query { get; set; }

        public IntentScore TopScoringIntent { get; set; }

        public List<MatchedEntity> Entities { get; set; }

        public List<MatchedCompositeEntity> CompositeEntities { get; set; }

        public SentimentScore SentimentAnalysis { get; set; }
    }
}
