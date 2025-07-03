using System.ComponentModel.DataAnnotations;

namespace RealState.Api.Models
{
    public class UpdatePropertyRequest
    {
        [Required(ErrorMessage = "Property ID is required for update")]
        [StringLength(50, ErrorMessage = "Property ID cannot exceed 50 characters")]
        public string IdProperty { get; set; }

        [Required(ErrorMessage = "Property name is required")]
        [StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Property code is required")]
        [StringLength(10)]
        public string CodeInternal { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year of the property is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Owner must be associated")]
        public string IdOwner { get; set; } = string.Empty;
    }
}
