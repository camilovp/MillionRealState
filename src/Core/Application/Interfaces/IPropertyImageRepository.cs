using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Interfaces
{
    public interface IPropertyImageRepository
    {
        Task<PropertyImage?> AddAsync(PropertyImage propertyImage);
        Task<IEnumerable<PropertyImage>> GetByIdAsync(string id);
        Task<IEnumerable<PropertyImage>> GetByPropertyIdAsync(string propertyId);
        Task DeleteAsync(string id);
        Task<PropertyImage?> UpdateAsync(PropertyImage propertyImage);
    }
}
