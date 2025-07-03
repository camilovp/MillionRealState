using RealState.Application.Interfaces;
namespace RealState.Application.UseCases.PropertyImages
{
    public class DeletePropertyImageUseCase
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        public DeletePropertyImageUseCase(IPropertyImageRepository propertyImageRepository)
        {
            _propertyImageRepository = propertyImageRepository;
        }
        public async Task ExecuteAsync(string id)
        {
            await _propertyImageRepository.DeleteAsync(id);
        }
    }
}
