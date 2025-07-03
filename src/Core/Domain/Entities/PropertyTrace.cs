using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealState.Domain.Entities
{
    public class PropertyTrace
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [BsonElement("idPropertyTrace")]
        public string IdPropertyTrace { get; set; }

        [BsonElement("idProperty")]
        [BsonRepresentation(BsonType.String)]
        public string IdProperty { get; set; }

        [BsonElement("dateSale")]
        public DateTime DateSale { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("value")]
        public decimal Value { get; set; }

        [BsonElement("tax")]
        public decimal Tax { get; set; }
    }
}
