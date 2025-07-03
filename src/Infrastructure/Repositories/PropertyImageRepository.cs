using MongoDB.Driver;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;
using RealState.Infrastructure.Mongo;

namespace RealState.Infrastructure.Repositories
{
    public class PropertyImageRepository : IPropertyImageRepository
    {
        private readonly MongoDbContext _context;
        public PropertyImageRepository(MongoDbContext context) => _context = context;

        public async Task<PropertyImage?> AddAsync(PropertyImage propertyImage)
        {
            await _context.PropertyImages.InsertOneAsync(propertyImage);
            return propertyImage;
        }
            
        public async Task<IEnumerable<PropertyImage>> GetByIdAsync(string id) =>
            await _context.PropertyImages.Find(i => i.IdPropertyImage == id).ToListAsync();

        public async Task<IEnumerable<PropertyImage>> GetByPropertyIdAsync(string propertyId) =>
            await _context.PropertyImages.Find(i => i.IdProperty == propertyId).ToListAsync();
        public async Task DeleteAsync(string id) =>
            await _context.PropertyImages.DeleteOneAsync(i => i.IdPropertyImage == id);
        public async Task<PropertyImage?> UpdateAsync(PropertyImage propertyImage)
        {
            await _context.PropertyImages.ReplaceOneAsync(i => i.IdPropertyImage == propertyImage.IdPropertyImage, propertyImage);
            return propertyImage;
        }
            
    }
}
