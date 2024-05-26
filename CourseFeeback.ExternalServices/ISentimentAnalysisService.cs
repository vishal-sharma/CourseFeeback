namespace ProjectReview.ExternalServices
{
    public interface ISentimentAnalysisService
    {
        string GetSentiment(string text);
    }
}