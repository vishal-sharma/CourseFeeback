namespace ProjectReview.ExternalServices
{
    public class SentimentAnalysisService : ISentimentAnalysisService
    {
        private readonly ISentimentAnalysisClientBuillder sentimentAnalysisClientBuillder;

        public SentimentAnalysisService(ISentimentAnalysisClientBuillder sentimentAnalysisClientBuillder)
        {
            this.sentimentAnalysisClientBuillder = sentimentAnalysisClientBuillder;
        }
        public string GetSentiment(string text)
        {
            var client = sentimentAnalysisClientBuillder.BuildClient();
            var response = client.AnalyzeSentiment(text);
            return response.Value.Sentiment.ToString();
        }
    }
}
