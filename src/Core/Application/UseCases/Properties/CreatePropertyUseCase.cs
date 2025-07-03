using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Application.UseCases.Properties
{
    public class CreatePropertyUseCase
    {
        private readonly IPropertyRepository _propertyRepository;

        public CreatePropertyUseCase(IPropertyRepository propertyRepository )
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<PropertyDto> ExecuteAsync(CreatePropertyDto dto)
        {
            var propertyEntity = dto.Adapt<Property>();
            propertyEntity.IdProperty = Guid.NewGuid().ToString();
            var created = await _propertyRepository.CreateAsync(propertyEntity);
            if (created == null) return null;
            return created.Adapt<PropertyDto>();
        }
    }
}
