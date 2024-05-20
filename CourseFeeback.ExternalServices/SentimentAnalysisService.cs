namespace ProjectReview.ExternalServices
{
    public class SentimentAnalysisService
    {
        public static string GetSentiment(string text)
        {
            var client = SentimentAnalysisClientBuillder.BuildClient();
            var response = client.AnalyzeSentiment(text);
            return response.Value.Sentiment.ToString();
        }
    }
}
