using CustomVisionLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomVisionLibrary
{
    public class CustomVisionClient : ICustomVisionClient, IDisposable
    {
        private const string DefaultCustomVisionEndPoint = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.0/";

        public string TrainingKey { get; set; }

        public string PredictionKey { get; set; }

        private HttpClient client;

        public CustomVisionClient(string predictionKey, string trainingKey = null, string customVisionEndpoint = DefaultCustomVisionEndPoint)
        {
            PredictionKey = predictionKey;
            TrainingKey = trainingKey;

            client = new HttpClient
            {
                BaseAddress = new Uri(customVisionEndpoint.EndsWith("/") ? customVisionEndpoint : customVisionEndpoint += "/")
            };
        }

        public async Task<ImagePredictionResult> PredictImageAsync(Guid projectId, Stream image, Guid? iterationId = null)
        {
            var request = CreatePredictRequest(projectId, iterationId);

            request.Content = new StreamContent(image);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var content = await SendRequestAsync<ImagePredictionResult>(request);
            return content;
        }

        public Task<ImagePredictionResult> PredictImageAsync(Guid projectId, Uri imageUrl, Guid? iterationId = null)
            => PredictImageAsync(projectId, imageUrl.ToString(), iterationId);

        public async Task<ImagePredictionResult> PredictImageAsync(Guid projectId, string imageUrl, Guid? iterationId = null)
        {
            var request = CreatePredictRequest(projectId, iterationId);

            request.Content = new StringContent(JsonConvert.SerializeObject(new
            {
                Url = imageUrl
            }));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var content = await SendRequestAsync<ImagePredictionResult>(request);
            return content;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            if (string.IsNullOrWhiteSpace(TrainingKey))
            {
                throw new ArgumentNullException(nameof(TrainingKey));
            }

            var resource = $"Training/projects";

            var request = new HttpRequestMessage(HttpMethod.Get, resource);
            request.Headers.Add("Training-Key", TrainingKey);

            var content = await SendRequestAsync<IEnumerable<Project>>(request);
            return content;
        }

        private HttpRequestMessage CreatePredictRequest(Guid projectId, Guid? iterationId)
        {
            if (string.IsNullOrWhiteSpace(PredictionKey))
            {
                throw new ArgumentNullException(nameof(PredictionKey));
            }

            var resource = $"Prediction/{projectId}/image?iterationId={iterationId}";

            var request = new HttpRequestMessage(HttpMethod.Post, resource);
            request.Headers.Add("Prediction-Key", PredictionKey);
            return request;
        }

        private async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseContentString = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<T>(responseContentString);

            return content;
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
