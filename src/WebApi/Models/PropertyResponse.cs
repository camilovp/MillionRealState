namespace RealState.Api.Models
{
    public class PropertyResponse
    {
        public string IdProperty { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }
        public string IdOwner { get; set; } = string.Empty;
        public OwnerResponse Owner { get; set; }
        public List<PropertyImageResponse> Images { get; set; }
        public List<PropertyTraceResponse> Traces { get; set; }
    }
}
