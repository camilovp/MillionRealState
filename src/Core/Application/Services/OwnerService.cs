using RealState.Application.Dtos;
using RealState.Application.UseCases.Owners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Services
{
    public class OwnerService
    {
        private readonly CreateOwnerUseCase _create;
        private readonly GetAllOwnersUseCase _getAll;
        private readonly GetOwnerByIdUseCase _getById;
        private readonly UpdateOwnerUseCase _update;
        private readonly DeleteOwnerUseCase _delete;

        public OwnerService(
            CreateOwnerUseCase create,
            DeleteOwnerUseCase delete,
            GetOwnerByIdUseCase getById,
            GetAllOwnersUseCase getAll,
            UpdateOwnerUseCase update)
        {
            _create = create;
            _delete = delete;
            _getById = getById;
            _getAll = getAll;
            _update = update;
        }

        public Task<OwnerDto> CreateAsync(CreateOwnerDto dto) => _create.ExecuteAsync(dto);
        public Task DeleteAsync(string id) => _delete.ExecuteAsync(id);
        public Task<OwnerDto?> GetByIdAsync(string id) => _getById.ExecuteAsync(id);
        public Task<IEnumerable<OwnerDto>?> GetAllAsync() => _getAll.ExecuteAsync();
        public Task<OwnerDto?> UpdateAsync(UpdateOwnerDto dto) => _update.ExecuteAsync(dto);
    }
}
