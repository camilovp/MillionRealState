using RealState.Application.Interfaces;
using RealState.Domain.Entities;
using MongoDB.Driver;
using RealState.Infrastructure.Mongo;

namespace RealState.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly MongoDbContext _context;
        public OwnerRepository(MongoDbContext context) => _context = context;

        public async Task<Owner?> CreateAsync(Owner owner)
        { 
            await _context.Owners.InsertOneAsync(owner);
            return owner;
        }
        public async Task<IEnumerable<Owner>> GetAllAsync() =>
            (await _context.Owners.Find(Builders<Owner>.Filter.Empty).ToListAsync());
        public async Task<Owner?> GetByIdAsync(string id) =>
            await _context.Owners.Find(o => o.IdOwner == id).FirstOrDefaultAsync();
        public async Task<Owner?> UpdateAsync(Owner owner)
        {
            await _context.Owners.ReplaceOneAsync(o => o.IdOwner == owner.IdOwner, owner);
            return owner;
        }
        public async Task DeleteAsync(string id) =>
            await _context.Owners.DeleteOneAsync(o => o.IdOwner == id);
    }
}
