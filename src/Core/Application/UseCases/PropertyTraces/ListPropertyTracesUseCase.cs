using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.PropertyTraces
{
    public class ListPropertyTracesUseCase
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;
        public ListPropertyTracesUseCase(IPropertyTraceRepository propertyTraceRepository)
        {
            _propertyTraceRepository = propertyTraceRepository;
        }
        public async Task<IEnumerable<PropertyTraceDto>> ExecuteAsync(string propertyId)
        {
            var propertyTraces = await _propertyTraceRepository.GetByPropertyIdAsync(propertyId);
            return propertyTraces.Adapt<IEnumerable<PropertyTraceDto>>();
        }
    }
}
