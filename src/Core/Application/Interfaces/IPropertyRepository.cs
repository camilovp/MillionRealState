using RealState.Application.Dtos;
using RealState.Domain.Entities;

namespace RealState.Application.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllAsync();
        Task<Property?> GetByIdAsync(string id);
        Task<Property?> CreateAsync(Property entity);
        Task<Property?> UpdateAsync(Property entity);
        Task DeleteAsync(string id);
        Task<IEnumerable<Property>> GetFilteredAsync(PropertyFilterDto f);
    }
}
