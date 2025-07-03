using RealState.Application.Dtos;
using RealState.Application.UseCases.PropertyTraces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Services
{
    public class PropertyTraceService
    {
        private readonly AddPropertyTraceUseCase _add;
        private readonly ListPropertyTracesUseCase _list;

        public PropertyTraceService(AddPropertyTraceUseCase add, ListPropertyTracesUseCase list)
        {
            _add = add;
            _list = list;
        }

        public Task<PropertyTraceDto?> AddAsync(AddPropertyTraceDto dto) => _add.ExecuteAsync(dto);
        public Task<IEnumerable<PropertyTraceDto>> ListAsync(string idProperty) => _list.ExecuteAsync(idProperty);
    }
}
