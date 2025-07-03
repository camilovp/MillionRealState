using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.Properties
{
    public class GetPropertyByIdUseCase
    {
        private readonly IPropertyRepository _propertyRepository;
        public GetPropertyByIdUseCase(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<PropertyDto?> ExecuteAsync(string id)
        {
            var propertyEntity = await _propertyRepository.GetByIdAsync(id);
            if (propertyEntity == null)
                return null; 
            return propertyEntity?.Adapt<PropertyDto>();
        }
    }
}
