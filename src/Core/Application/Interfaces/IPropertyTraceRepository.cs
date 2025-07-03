using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Interfaces
{
    public interface IPropertyTraceRepository
    {
        Task<PropertyTrace?> AddAsync(PropertyTrace propertyTrace);
        Task<IEnumerable<PropertyTrace>> GetByIdAsync(string id);
        Task<IEnumerable<PropertyTrace>> GetByPropertyIdAsync(string propertyId);
        Task DeleteAsync(string id);
    }
}
