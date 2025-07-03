using System.ComponentModel.DataAnnotations;

namespace RealState.Api.Models
{
    public class UpdateOwnerRequest
    {
        [Required(ErrorMessage = "IdOwner is required")]
        public string IdOwner { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(120, ErrorMessage = "Name cannot exceed 120 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; } = string.Empty;

        [Url(ErrorMessage = "Invalid photo URL")]
        public string Photo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Birthday is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime Birthday { get; set; }
    }
}
