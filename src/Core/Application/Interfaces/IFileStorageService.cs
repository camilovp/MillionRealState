using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveAsync(IFormFile file, string container, CancellationToken ct = default);
    }
}
