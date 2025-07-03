using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.Properties
{
    public class GetPropertyFilteredUseCase
    {
        private readonly IPropertyRepository _propertyRepository;
        public GetPropertyFilteredUseCase(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<IEnumerable<PropertyDto>?> ExecuteAsync(PropertyFilterDto f)
        {
            var properties = await _propertyRepository.GetFilteredAsync(f);
            if (properties == null || properties.Count() < 1)
                return null;
            return properties.Adapt<IEnumerable<PropertyDto>>();
        }
    }
}
