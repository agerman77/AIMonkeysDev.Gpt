using AIMonkeysDev.Gpt.Models;
using AIMonkeysDev.Gpt.Models.Requests;
using AIMonkeysDev.Gpt.Models.Responses;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{
    public class FineTuningJobRepository : BaseRepository
    {
        public FineTuningJobRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/fine_tuning/jobs")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Creates a job that fine-tunes a specified model from a given dataset.
        /// POST https://api.openai.com/v1/fine_tuning/jobs
        ///Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
        /// </summary>
        /// <param name="fineTuningRequest"></param>
        /// <returns></returns>
        public async Task<FineTuningJob> CreateFineTuningJobAsync(FineTuningJobRequest fineTuningRequest)
        {
            return await PrepareAndMakeRequest<FineTuningJob>(BaseUrl, Method.POST, bodyObject: fineTuningRequest);
        }


        /// <summary>
        /// Lists your organization's fine-tuning jobs
        /// GET https://api.openai.com/v1/fine_tuning/jobs
        /// </summary>
        /// <param name="afterId">Identifier for the last job from the previous pagination request.</param>
        /// <param name="limit">Number of fine-tuning jobs to retrieve.</param>
        /// <returns></returns>
        public async Task<PagedResponse<FineTuningJob>> GetFineTuningJobsAsync(string afterId = null, int limit = 20)
        {
            return await PrepareAndMakeRequest<PagedResponse<FineTuningJob>>($"{BaseUrl}", queryParameters: new {after= afterId, limit = limit });
        }

        /// <summary>
        /// Gets info about a fine-tuning job.
        /// GET https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}
        /// </summary>
        /// <param name="fineTuningJobId"></param>
        /// <returns></returns>
        public async Task<FineTuningJob> GetFineTuningJobAsync(string fineTuningJobId)
        {
            return await PrepareAndMakeRequest<FineTuningJob>($"{BaseUrl}/{fineTuningJobId}");
        }

        /// <summary>
        /// Immediately cancels a fine-tune job.
        /// POST https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/cancel
        /// </summary>
        /// <param name="fineTuningJobId"></param>
        /// <returns></returns>
        public async Task<FineTuningJob> CancelFineTuningJobAsync(string fineTuningJobId)
        {
            return await PrepareAndMakeRequest<FineTuningJob>($"{BaseUrl}/{fineTuningJobId}/cancel", Method.POST);
        }

        /// <summary>
        /// Gets status updates for a fine-tuning job.
        /// GET https://api.openai.com/v1/fine_tuning/jobs/{fine_tuning_job_id}/events
        /// </summary>
        /// <param name="fineTuningJobId"></param>
        /// <returns></returns>
        public async Task<PagedResponse<FineTuningJobEvent>> GetFineTuningJobEventsAsync(string fineTuningJobId, string afterId = null, int limit = 20)
        {
            return await PrepareAndMakeRequest<PagedResponse<FineTuningJobEvent>>($"{BaseUrl}/{fineTuningJobId}/events", queryParameters: new { after = afterId, limit = limit });
        }

    }

}
