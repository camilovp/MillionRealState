
namespace RealState.Application.Dtos
{
    public class UpdatePropertyDto
    {
        public string IdProperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public int Year { get; set; }
        public string IdOwner { get; set; }
    }
}
