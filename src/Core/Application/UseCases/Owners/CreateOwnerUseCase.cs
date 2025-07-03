using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;

namespace RealState.Application.UseCases.Owners
{
    public class CreateOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;

        public CreateOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<OwnerDto?> ExecuteAsync(CreateOwnerDto dto)
        {
            var ownerEntity = dto.Adapt<Owner>();
            ownerEntity.IdOwner = Guid.NewGuid().ToString();
            var result = await _ownerRepository.CreateAsync(ownerEntity);
            if (result == null) return null;
            return result.Adapt<OwnerDto>();
        }
    }
}
