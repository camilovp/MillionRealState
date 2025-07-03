using RealState.Application.Dtos;
using RealState.Application.UseCases.PropertyImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Services
{
    public class PropertyImageService
    {
        private readonly AddPropertyImageUseCase _add;
        private readonly DeletePropertyImageUseCase _delete;
        private readonly ListPropertyImagesUseCase _list;
        private readonly UpdatePropertyImagesUseCases _update;

        public PropertyImageService(
            AddPropertyImageUseCase add,
            DeletePropertyImageUseCase delete,
            ListPropertyImagesUseCase list,
            UpdatePropertyImagesUseCases update)
        {
            _add = add;
            _delete = delete;
            _list = list;
            _update = update;
        }

        public Task<PropertyImageDto?> AddAsync(AddPropertyImageDto dto) => _add.ExecuteAsync(dto);
        public Task DeleteAsync(string id) => _delete.ExecuteAsync(id);
        public Task<IEnumerable<PropertyImageDto>> ListAsync(string idProperty) => _list.ExecuteAsync(idProperty);
        public Task<PropertyImageDto?> UpdateAsync(UpdatePropertyImageDto dto) => _update.ExecuteAsync(dto);
    }
}