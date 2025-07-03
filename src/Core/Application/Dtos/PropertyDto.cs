using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RealState.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Application.Dtos
{
    public class PropertyDto
    {
        public string IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public string IdOwner { get; set; }
        public OwnerDto Owner { get; set; }
        public List<PropertyImageDto> Images { get; set; } = new();
        public List<PropertyTraceDto> Traces { get; set; } = new();
    }
}
