using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.Owners
{
    public class GetOwnerByIdUseCase
    {
        private readonly IOwnerRepository _ownerRepository;

        public GetOwnerByIdUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task<OwnerDto?> ExecuteAsync(string id)
        {
            var ownerEntity = await _ownerRepository.GetByIdAsync(id);
            if (ownerEntity == null)
                return null; // or throw an exception if preferred
            return ownerEntity?.Adapt<OwnerDto>();
        }
    }
}
