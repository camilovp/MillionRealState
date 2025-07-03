using RealState.Application.Dtos;
using RealState.Application.UseCases.Properties;

namespace RealState.Application.Services
{
    public class PropertyService
    {
        private readonly CreatePropertyUseCase _create;
        private readonly GetPropertyFilteredUseCase _getFiltered;
        private readonly GetPropertiesUseCase _getAll;
        private readonly GetPropertyByIdUseCase _getById;
        private readonly UpdatePropertyUseCase _update;
        private readonly DeletePropertyUseCase _delete;

        public PropertyService(
            CreatePropertyUseCase create,
            DeletePropertyUseCase delete,
            GetPropertyByIdUseCase getById,
            GetPropertiesUseCase getAll,
            UpdatePropertyUseCase update,
            GetPropertyFilteredUseCase getFiltered)
        {
            _create = create;
            _delete = delete;
            _getById = getById;
            _getAll = getAll;
            _update = update;
            _getFiltered = getFiltered;
        }

        public Task<PropertyDto?> CreateAsync(CreatePropertyDto dto) => _create.ExecuteAsync(dto);
        public Task DeleteAsync(string id) => _delete.ExecuteAsync(id);
        public Task<PropertyDto?> GetByIdAsync(string id) => _getById.ExecuteAsync(id);
        public Task<IEnumerable<PropertyDto>?> GetAllAsync() => _getAll.ExecuteAsync();
        public Task<PropertyDto?> UpdateAsync(UpdatePropertyDto dto) => _update.ExecuteAsync(dto);
        public Task<IEnumerable<PropertyDto>?> GetFiltered(PropertyFilterDto f) => _getFiltered.ExecuteAsync(f);
    }
}
