using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealState.Domain.Entities
{
    public class PropertyImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("idPropertyImage")]
        public string IdPropertyImage { get; set; }

        [BsonElement("idProperty")]
        [BsonRepresentation(BsonType.String)]
        public string IdProperty { get; set; }

        [BsonElement("file")]
        public string File { get; set; }

        [BsonElement("enabled")]
        public bool Enabled { get; set; }
    }
}
