using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.Properties
{
    public class GetPropertiesUseCase
    {
        private readonly IPropertyRepository _propertyRepository;
        public GetPropertiesUseCase(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<IEnumerable<PropertyDto?>> ExecuteAsync()
        {
            var properties = await _propertyRepository.GetAllAsync();
            if (properties == null || !properties.Any())
                return null;
            return properties.Adapt<IEnumerable<PropertyDto>>();
        }
    }
}
