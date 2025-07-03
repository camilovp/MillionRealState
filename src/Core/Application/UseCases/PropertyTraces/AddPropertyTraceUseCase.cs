using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Application.UseCases.PropertyTraces
{
    public class AddPropertyTraceUseCase
    {
        private readonly IPropertyTraceRepository _propertyTraceRepository;

        public AddPropertyTraceUseCase(IPropertyTraceRepository propertyTraceRepository)
        {
            _propertyTraceRepository = propertyTraceRepository;
        }

        public async Task<PropertyTraceDto> ExecuteAsync(AddPropertyTraceDto dto)
        {
            var propertyTraceEntity = dto.Adapt<PropertyTrace>();
            propertyTraceEntity.IdPropertyTrace = Guid.NewGuid().ToString();
            var result = await _propertyTraceRepository.AddAsync(propertyTraceEntity);
            if (result == null) return null;
            return propertyTraceEntity.Adapt<PropertyTraceDto>();
        }
    }
}
