using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.UseCases.PropertyImages
{
    public class UpdatePropertyImagesUseCases
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        public UpdatePropertyImagesUseCases(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }
        public async Task<PropertyImageDto?> ExecuteAsync(UpdatePropertyImageDto dto)
        {
            var entity = dto.Adapt<PropertyImage>();
            var result = await _propertyImageRepository.UpdateAsync(entity);
            if (result == null) return null;
            return entity.Adapt<PropertyImageDto>();
        }
    }
}
