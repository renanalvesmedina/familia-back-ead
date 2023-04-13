using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Familia.Ead.Application.Utils
{
    public class UploadFileFactory : IUploadFileFactory
    {
        private readonly IConfiguration _configuration;

        public UploadFileFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string containerName, string blobName)
        {
            var _connectionString = _configuration.GetConnectionString("AzureBlobStorage");
            try
            {
                BlobServiceClient blobServiceClient = new(_connectionString);
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                await containerClient.CreateIfNotExistsAsync();

                BlobUploadOptions uploadOptions = new()
                {
                    HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
                };

                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, uploadOptions);
                }

                return blobClient.Uri.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
