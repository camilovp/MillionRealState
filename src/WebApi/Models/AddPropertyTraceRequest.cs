using System.ComponentModel.DataAnnotations;

namespace RealState.Api.Models
{
    public class AddPropertyTraceRequest
    {
        [Required(ErrorMessage = "Property ID is required")]
        public string IdProperty { get; set; } = string.Empty;

        [Required(ErrorMessage = "Sale date is required")]
        [DataType(DataType.Date, ErrorMessage = "Sale date must be a valid date")]
        public DateTime DateSale { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Value is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Value must be greater than zero")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Tax is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Tax must be zero or greater")]
        public decimal Tax { get; set; }
    }
}
