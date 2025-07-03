using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Mongo
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _db;
        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _db = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Property> Properties => _db.GetCollection<Property>("Property");
        public IMongoCollection<Owner> Owners => _db.GetCollection<Owner>("Owner");
        public IMongoCollection<PropertyImage> PropertyImages => _db.GetCollection<PropertyImage>("PropertyImage");
        public IMongoCollection<PropertyTrace> PropertyTraces => _db.GetCollection<PropertyTrace>("PropertyTrace");
    }
}
