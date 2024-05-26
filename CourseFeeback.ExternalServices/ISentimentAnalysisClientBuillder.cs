using Azure.AI.TextAnalytics;

namespace ProjectReview.ExternalServices
{
    public interface ISentimentAnalysisClientBuillder
    {
        TextAnalyticsClient BuildClient();
    }
}