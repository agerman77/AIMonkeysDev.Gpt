using AIMonkeysDev.Gpt.Models;
using AIMonkeysDev.Gpt.Models.Requests;
using AIMonkeysDev.Gpt.Models.Responses;
using RestSharp;

namespace AIMonkeysDev.Gpt.Domain
{
    public class ThreadRunRepository : BaseRepository
    {
        public ThreadRunRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/threads")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        /// <summary>
        /// Creates a run.
        /// POST https://api.openai.com/v1/threads/{thread_id}/runs
        /// </summary>
        /// <param name="createRunRequest"></param>
        /// <returns></returns>
        public async Task<ThreadRun> CreateRunAsync(ThreadRunRequest createRunRequest)
        {
            return await PrepareAndMakeRequest<ThreadRun>($"{BaseUrl}/{createRunRequest.ThreadId}/runs", Method.POST, bodyObject: createRunRequest);
        }

        /// <summary>
        /// Retrieves a run.
        /// GET https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="runId"></param>
        /// <returns></returns>
        public async Task<ThreadRun> GetRunAsync(string threadId, string runId)
        {
            return await PrepareAndMakeRequest<ThreadRun>($"{BaseUrl}/{threadId}/runs/{runId}");
        }

        /// <summary>
        /// Modifies a run.
        /// POST https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="runId"></param>
        /// <param name="metadata"></param>
        /// <returns></returns>
        public async Task<ThreadRun> UpdateRunAsync(string threadId, string runId, object metadata)
        {
            return await PrepareAndMakeRequest<ThreadRun>($"{BaseUrl}/{threadId}/runs/{runId}", Method.POST, bodyObject: metadata);
        }

        /// <summary>
        /// Returns a list of runs belonging to a thread.
        /// GET https://api.openai.com/v1/threads/{thread_id}/runs
        /// </summary>
        /// <param name="threadId"></param>
        /// <returns></returns>
        public async Task<PagedResponse<ThreadRun>> GetRunsAsync(string threadId, QueryParams queryParams = null)
        {
            return await PrepareAndMakeRequest<PagedResponse<ThreadRun>>($"{BaseUrl}/{threadId}/runs", queryParameters: queryParams);
        }

        /// <summary>
        /// When a run has the <code>status: "requires_action"</code> and <code>required_action.type</code> is <code>submit_tool_outputs</code>, this endpoint can be used to submit the outputs from the tool calls once they're all completed. All outputs must be submitted in a single request.
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="runId"></param>
        /// <param name="toolOutputs"></param>
        /// <returns></returns>
        public async Task<ThreadRun> SubmitToolOutputsToRunAsync(string threadId, string runId, List<ToolOutput> toolOutputs)
        {
            return await PrepareAndMakeRequest<ThreadRun>($"{BaseUrl}/{threadId}/runs/{runId}/submit_tool_outputs", Method.POST, bodyObject: toolOutputs);
        }

        /// <summary>
        /// Cancels a run that is in_progress.
        /// POST https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/cancel
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="runId"></param>
        /// <returns></returns>
        public async Task<ThreadRun> CancelRunAsync(string threadId, string runId)
        {
            return await PrepareAndMakeRequest<ThreadRun>($"{BaseUrl}/{threadId}/runs/{runId}/cancel", Method.POST);
        }

        /// <summary>
        /// Creates a thread and run it in one request.
        /// POST https://api.openai.com/v1/threads/runs
        /// </summary>
        /// <param name="createThreadAndRunRequest"></param>
        /// <returns></returns>
        public async Task<ThreadRun> CreateThreadAndRunAsync(ThreadAndRunRequest createThreadAndRunRequest)
        {
            return await PrepareAndMakeRequest<ThreadRun>($"{BaseUrl}/{createThreadAndRunRequest.AssitantId}/runs", Method.POST);
        }


        /// <summary>
        /// Retrieves a run step.
        /// GET https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps/{step_id}
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="runId"></param>
        /// <param name="stepId"></param>
        /// <returns></returns>
        public async Task<ThreadRunStep> GetRunStepAsync(string threadId, string runId, string stepId)
        {
            return await PrepareAndMakeRequest<ThreadRunStep>($"{BaseUrl}/{threadId}/runs/{runId}/steps/{stepId}");
        }

        /// <summary>
        /// Returns a list of run steps belonging to a run.
        /// GET https://api.openai.com/v1/threads/{thread_id}/runs/{run_id}/steps
        /// </summary>
        /// <param name="threadId"></param>
        /// <param name="runId"></param>
        /// <returns></returns>
        public async Task<ThreadRunStep> GetRunStepsAsync(string threadId, string runId)
        {
            return await PrepareAndMakeRequest<ThreadRunStep>($"{BaseUrl}/{threadId}/runs/{runId}");
        }

    }

}
