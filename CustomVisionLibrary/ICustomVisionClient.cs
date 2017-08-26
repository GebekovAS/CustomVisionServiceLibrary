using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CustomVisionLibrary.Models;
using System.Threading;

namespace CustomVisionLibrary
{
    public interface ICustomVisionClient
    {
        string PredictionKey { get; set; }

        string TrainingKey { get; set; }

        Task<IEnumerable<Project>> GetProjectsAsync();

        Task<IEnumerable<Iteration>> GetIterationsAsync(Guid projectId);

        Task<IterationPerformance> GetIterationPerformanceAsync(Guid projectId, Guid iterationId, double threshold = 0.9);

        Task<ImagePredictionResult> PredictImageAsync(Guid projectId, Stream image, Guid? iterationId = null);

        Task<ImagePredictionResult> PredictImageAsync(Guid projectId, string imageUrl, Guid? iterationId = null);

        Task<ImagePredictionResult> PredictImageAsync(Guid projectId, Uri imageUrl, Guid? iterationId = null);
    }
}