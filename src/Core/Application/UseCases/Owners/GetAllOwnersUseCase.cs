using Mapster;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.Owners
{
    public class GetAllOwnersUseCase
    {
        private readonly IOwnerRepository _ownerRepository;
        public GetAllOwnersUseCase(IOwnerRepository repo) => _ownerRepository = repo;

        public async Task<IEnumerable<OwnerDto?>> ExecuteAsync()
        {
            var entities = await _ownerRepository.GetAllAsync();
            if (entities == null || !entities.Any())
                return null;
            return entities.Adapt<IEnumerable<OwnerDto>>();
        }
    }
}
