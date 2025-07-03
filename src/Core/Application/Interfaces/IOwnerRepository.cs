using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Interfaces
{
    public interface IOwnerRepository
    {
        Task<Owner?> CreateAsync(Owner owner);
        Task DeleteAsync(string id);
        Task<IEnumerable<Owner>> GetAllAsync();
        Task<Owner?> GetByIdAsync(string id);
        Task<Owner?> UpdateAsync(Owner owner);
    }
}
