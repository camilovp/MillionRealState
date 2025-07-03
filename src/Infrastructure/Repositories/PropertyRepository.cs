using MongoDB.Bson;
using MongoDB.Driver;
using RealState.Application.Dtos;
using RealState.Application.Interfaces;
using RealState.Domain.Entities;
using RealState.Infrastructure.Mongo;

namespace RealState.Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly MongoDbContext _context;
        public PropertyRepository(MongoDbContext context) => _context = context;

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            var props = await _context.Properties.Find(_ => true).ToListAsync();
            foreach (var p in props)
            {
                p.Images = await _context.PropertyImages
                                         .Find(i => i.IdProperty == p.IdProperty)
                                         .ToListAsync();

                p.Traces = await _context.PropertyTraces
                                         .Find(t => t.IdProperty == p.IdProperty)
                                         .ToListAsync();

                p.Owner = await _context.Owners
                                        .Find(o => o.IdOwner == p.IdOwner)
                                        .FirstOrDefaultAsync();
            }
            return props;
        }

        public async Task<IEnumerable<Property>> GetFilteredAsync(PropertyFilterDto f)
        {
            var filter = Builders<Property>.Filter.Empty;

            if (!string.IsNullOrWhiteSpace(f.IdOwner))
                filter &= Builders<Property>.Filter.Eq(p => p.IdOwner, f.IdOwner);

            if (!string.IsNullOrWhiteSpace(f.Name))
                filter &= Builders<Property>.Filter.Regex(p => p.Name, new BsonRegularExpression(f.Name, "i"));

            if (!string.IsNullOrWhiteSpace(f.Address))
                filter &= Builders<Property>.Filter.Regex(p => p.Address, new BsonRegularExpression(f.Address, "i"));

            if (f.MinPrice.HasValue)
                filter &= Builders<Property>.Filter.Gte(p => p.Price, f.MinPrice.Value);

            if (f.MaxPrice.HasValue)
                filter &= Builders<Property>.Filter.Lte(p => p.Price, f.MaxPrice.Value);

            // Slice to 1st image only (driver ≥ 2.12)
            var projection = Builders<Property>.Projection
                .Slice(p => p.Images, 0, 1);

            var list = await _context.Properties.Find(filter)
                                 .Project<Property>(projection)
                                 .ToListAsync();

            foreach (var p in list)
            {
                p.Images = await _context.PropertyImages
                                     .Find(i => i.IdProperty == p.IdProperty)
                                     .ToListAsync();
                p.Traces = await _context.PropertyTraces
                                         .Find(t => t.IdProperty == p.IdProperty)
                                         .ToListAsync();
                p.Owner = await _context.Owners
                                         .Find(o => o.IdOwner == p.IdOwner)
                                         .FirstOrDefaultAsync();
            }

            return list;
        }

        public async Task<Property?> GetByIdAsync(string id)
        {
            var p = await _context.Properties
                                  .Find(x => x.IdProperty == id)
                                  .FirstOrDefaultAsync();
            if (p == null) return null;

            p.Images = await _context.PropertyImages
                                     .Find(i => i.IdProperty == p.IdProperty)
                                     .ToListAsync();
            p.Traces = await _context.PropertyTraces
                                     .Find(t => t.IdProperty == p.IdProperty)
                                     .ToListAsync();
            p.Owner = await _context.Owners
                                     .Find(o => o.IdOwner == p.IdOwner)
                                     .FirstOrDefaultAsync();
            return p;
        }

        public async Task<Property> CreateAsync(Property entity)
        {
            await _context.Properties.InsertOneAsync(entity);
            return entity;
        }
            

        public async Task<Property> UpdateAsync(Property entity)
        {
            await _context.Properties.ReplaceOneAsync(p => p.IdProperty == entity.IdProperty, entity);
            return entity;
        }
           

        public async Task DeleteAsync(string id) =>
            await _context.Properties.DeleteOneAsync(p => p.IdProperty == id);
    }
}
