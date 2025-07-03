using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.PropertyImages
{
    public class ListPropertyImagesUseCase
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        public ListPropertyImagesUseCase(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }
        public async Task<IEnumerable<PropertyImageDto?>> ExecuteAsync(string propertyId)
        {
            var propertyImages = await _propertyImageRepository.GetByPropertyIdAsync(propertyId);
            if (propertyImages == null || !propertyImages.Any())
                return null;
            return propertyImages.Adapt<IEnumerable<PropertyImageDto>>();
        }
    }
}
