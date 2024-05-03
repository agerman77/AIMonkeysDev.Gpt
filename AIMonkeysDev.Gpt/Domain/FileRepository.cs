using AIMonkeysDev.Gpt.Enums;
using AIMonkeysDev.Gpt.Models.Responses;
using RestSharp;
using File = AIMonkeysDev.Gpt.Models.File;

namespace AIMonkeysDev.Gpt.Domain
{
    public class FileRepository: BaseRepository
    {
        public FileRepository(string apiKey, string baseUrl = "https://api.openai.com/v1/files")
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }

        public async Task<BaseResponse<List<File>>> GetFilesAsync()
        {
  
            return await PrepareAndMakeRequest<BaseResponse<List<File>>>(BaseUrl);

        }

        public async Task<File> UploadFileAsync(File file, FilePurpose _purpose )
        {

            return await PrepareAndMakeRequest<File>(BaseUrl, Method.POST, bodyObject: new { file = file.Id, purpose = _purpose });
        }

        public async Task<DeleteResponse> DeleteFileAsync(string fileId)
        {

            return await PrepareAndMakeRequest<DeleteResponse>($"{BaseUrl}/{fileId}", Method.DELETE);

        }

        public async Task<File> GetFileAsync(string fileId)
        {

            return await PrepareAndMakeRequest<File>($"{BaseUrl}/{fileId}");
        }

        public async Task<string> GetFileContentAsync(string fileId)
        {

            return await PrepareAndMakeRequest<string>($"{BaseUrl}/{fileId}/content");
        }

    }
}
