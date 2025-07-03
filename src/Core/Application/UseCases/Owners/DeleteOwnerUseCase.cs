using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.Owners
{
    public class DeleteOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;

        public DeleteOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public async Task ExecuteAsync(string id)
        {
            await _ownerRepository.DeleteAsync(id);
        }
    }
}
