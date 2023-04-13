using Microsoft.AspNetCore.Http;

namespace Familia.Ead.Application.Utils
{
    public interface IUploadFileFactory
    {
        Task<string> UploadFileAsync(IFormFile file, string containerName, string blobName);
    }
}
