using NUnit.Framework;
using ProjectReview.ExternalServices;

namespace ProjectReview.ExternalServices.Tests
{
    public class SentimentAnalysisServiceTests
    {
        [Test]
        public void GetSentiment_ShouldReturnSentiment()
        {
            // Arrange
            string text = "This is a positive review.";

            // Act
            string sentiment = SentimentAnalysisService.GetSentiment(text);

            // Assert
            Assert.That(sentiment, Is.EqualTo("Positive"));
        }
    }
}
