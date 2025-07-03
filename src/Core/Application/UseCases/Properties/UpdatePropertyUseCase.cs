using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Application.UseCases.Properties
{
    public class UpdatePropertyUseCase
    {
        private readonly IPropertyRepository _propertyRepository;

        public UpdatePropertyUseCase(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        
        public async Task<PropertyDto?> ExecuteAsync(UpdatePropertyDto dto)
        {
            var entity = dto.Adapt<Property>();
            var update = await _propertyRepository.UpdateAsync(entity);
            if (update == null) return null;
            return entity.Adapt<PropertyDto>();
        }
    }
}
