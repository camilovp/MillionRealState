using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Application.UseCases.Owners
{
    public class UpdateOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;
        public UpdateOwnerUseCase(IOwnerRepository repo) => _ownerRepository = repo;

        public async Task<OwnerDto?> ExecuteAsync(UpdateOwnerDto dto)
        {
            var entity = dto.Adapt<Owner>();
            var result = await _ownerRepository.UpdateAsync(entity);
            if (result == null) return null;
            return entity.Adapt<OwnerDto>();
        }
    }
}
