using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using RealState.Application.Interfaces;

namespace RealState.Infrastructure.FileStorage
{
    public class FileStorage : IFileStorageService
    {
        private readonly IHostEnvironment _env;
        private readonly IHttpContextAccessor _http;

        public FileStorage(IHostEnvironment env, IHttpContextAccessor http)
        {
            _env = env;
            _http = http;
        }

        public async Task<string> SaveAsync(IFormFile file,
                                            string container,
                                            CancellationToken ct = default)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is empty.", nameof(file));

            var root = _env.ContentRootPath ?? Path.Combine("wwwroot");

            var dateSegment = DateTime.UtcNow.ToString("yyyyMMdd");
            var folder = Path.Combine(root, container, dateSegment);
            Directory.CreateDirectory(folder);

            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid():N}{ext}";
            var fullPath = Path.Combine(folder, fileName);

            await using (var stream = File.Create(fullPath))
            {
                await file.CopyToAsync(stream, ct);
            }

            var req = _http.HttpContext!.Request;
            var url = $"{req.Scheme}://{req.Host}/{container}/{dateSegment}/{fileName}";

            return url;
        }
    }
}
