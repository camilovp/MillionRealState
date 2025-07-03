using RealState.Application.Interfaces;

namespace RealState.Application.UseCases.Properties
{
    public class DeletePropertyUseCase
    {
        private readonly IPropertyRepository _propertyRepository;

        public DeletePropertyUseCase(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task ExecuteAsync(string id)
        {
            await _propertyRepository.DeleteAsync(id);
        }
    }
}
