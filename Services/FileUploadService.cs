using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _environment;
        public FileUploadService(IWebHostEnvironment env)
        {
            this._environment = env;

        }


        public async Task UploadAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.WebRootPath, "Upload", fileEntry.Name); //wwwroot에 가야됨 Upload폴더에 쓰기권한 확인
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            
            using(FileStream file = new FileStream(path, FileMode.Create))
            {
                ms.WriteTo(file);
            }
        }
    }
}
