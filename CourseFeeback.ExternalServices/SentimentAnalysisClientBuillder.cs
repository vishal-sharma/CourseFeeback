using Azure;
using Azure.AI.TextAnalytics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReview.ExternalServices
{
    public class SentimentAnalysisClientBuillder : ISentimentAnalysisClientBuillder
    {
        private readonly Uri endpoint;
        private readonly AzureKeyCredential credential;

        public SentimentAnalysisClientBuillder(IConfiguration config)
        {
            string languageEndpoint = Environment.GetEnvironmentVariable("LANGUAGE_ENDPOINT");
            endpoint = new(languageEndpoint);
            credential = new(config["languageKey"]);
        }

        public TextAnalyticsClient BuildClient() => new(endpoint, credential);
    }
}
