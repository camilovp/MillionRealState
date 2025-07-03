using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Application.UseCases.PropertyImages
{
    public class AddPropertyImageUseCase
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IFileStorageService _fileService;

        public AddPropertyImageUseCase(
            IPropertyImageRepository propertyImageRepository, 
            IFileStorageService fileService
            )
        {
            _propertyImageRepository = propertyImageRepository;
            _fileService = fileService;
        }
        public async Task<PropertyImageDto> ExecuteAsync(AddPropertyImageDto dto)
        {
            string container = "PropertyImages";
            string file = string.Empty;
            if (dto.AttachedFile != null)
            {
                file = await _fileService.SaveAsync(dto.AttachedFile, container);
            }
            var propertyImageEntity = dto.Adapt<PropertyImage>();
            propertyImageEntity.File = file;
            propertyImageEntity.IdPropertyImage = Guid.NewGuid().ToString();
            var result = await _propertyImageRepository.AddAsync(propertyImageEntity);
            if (result == null) return null;
            return propertyImageEntity.Adapt<PropertyImageDto>();
        }
    }
}
