namespace CognitiveMinion.LanguageUnderstanding.LuisAI.Models
{
    public class MatchedEntity
    {
        public string Entity { get; set; }

        public string Type { get; set; }

        public int StartIndex { get; set; }

        public int EndIndex { get; set; }

        public double Score { get; set; }

        public MatchedEntityResolution Resolution { get; set; }
    }
}
