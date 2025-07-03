using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealState.Domain.Entities
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("idProperty")]
        public string IdProperty { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("codeInternal")]
        public string CodeInternal { get; set; }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("idOwner")]
        [BsonRepresentation(BsonType.String)]
        public string IdOwner { get; set; }

        [BsonIgnore]
        public Owner Owner { get; set; }

        [BsonElement("images")]
        public List<PropertyImage> Images { get; set; } = new();

        [BsonElement("traces")]
        public List<PropertyTrace> Traces { get; set; } = new();
    }
}
