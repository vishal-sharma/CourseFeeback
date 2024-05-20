using Azure;
using Azure.AI.TextAnalytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReview.ExternalServices
{
    internal static class SentimentAnalysisClientBuillder
    {
        static readonly string languageKey = "b6ef0b7dcafb4d198998cba6d42ee256";
        static readonly string languageEndpoint = "https://productreviewv2.cognitiveservices.azure.com/";

        private static readonly AzureKeyCredential credentials = new(languageKey);
        private static readonly Uri endpoint = new(languageEndpoint);

        public static TextAnalyticsClient BuildClient() => new(endpoint, credentials);
    }
}
