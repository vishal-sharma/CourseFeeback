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
    public static class SentimentAnalysisClientBuillder
    {
        private static IConfiguration config;
        public static void Initialize(IConfiguration Configuration)
        {
            config = Configuration;
        }

        private static string languageEndpoint = Environment.GetEnvironmentVariable("LANGUAGE_ENDPOINT");
        private static readonly Uri endpoint = new(languageEndpoint);

        public static TextAnalyticsClient BuildClient() => new(endpoint, new AzureKeyCredential(config["languageKey"]));
    }
}
