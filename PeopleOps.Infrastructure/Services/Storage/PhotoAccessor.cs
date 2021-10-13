using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Services.Storage
{
    public class PhotoAccessor : IPhotoAccessor
    {
        public Task<string> DeleteFileAsync(string publicId)
        {
            throw new System.NotImplementedException();
        }

        public Task<PhotoUploadResponseDto> UploadFileAsync(IFormFile file)
        {
            throw new System.NotImplementedException();
        }

        public Task<PhotoUploadResponseDto> UploadFilesAsync(List<IFormFile> file)
        {
            throw new System.NotImplementedException();
        }
    }
}
