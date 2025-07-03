using MongoDB.Driver;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;
using RealState.Infrastructure.Mongo;

namespace RealState.Infrastructure.Repositories
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly MongoDbContext _context;
        public PropertyTraceRepository(MongoDbContext context) => _context = context;
        public async Task<PropertyTrace?> AddAsync(PropertyTrace propertyTrace)
        {
            await _context.PropertyTraces.InsertOneAsync(propertyTrace);
            return propertyTrace;
        }
            
        public async Task<IEnumerable<PropertyTrace>> GetByIdAsync(string id) =>
            await _context.PropertyTraces.Find(t => t.IdPropertyTrace == id).ToListAsync();

        public async Task<IEnumerable<PropertyTrace>> GetByPropertyIdAsync(string propertyId) =>
            await _context.PropertyTraces.Find(t => t.IdProperty == propertyId).ToListAsync();
        public async Task DeleteAsync(string id) =>
            await _context.PropertyTraces.DeleteOneAsync(t => t.IdPropertyTrace == id);
    }
}
