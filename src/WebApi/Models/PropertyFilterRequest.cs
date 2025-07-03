using System.ComponentModel.DataAnnotations;

namespace RealState.Api.Models
{
    public class PropertyFilterRequest
    {
        [StringLength(50, ErrorMessage = "OwnerId cannot exceed 50 characters")]
        public string? OwnerId { get; set; }

        [StringLength(120, ErrorMessage = "Name cannot exceed 120 characters")]
        public string? Name { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "MinPrice must be greater than zero")]
        public decimal? MinPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "MaxPrice must be greater than zero")]
        public decimal? MaxPrice { get; set; }
    }
}
