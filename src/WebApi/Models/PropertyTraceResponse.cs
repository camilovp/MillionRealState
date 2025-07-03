namespace RealState.Api.Models
{
    public class PropertyTraceResponse
    {
        public string IdPropertyTrace { get; set; }
        public string IdProperty { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
    }
}
