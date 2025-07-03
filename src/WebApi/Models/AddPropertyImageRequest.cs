using System.ComponentModel.DataAnnotations;

namespace RealState.Api.Models
{
    public class AddPropertyImageRequest
    {
        [Required(ErrorMessage = "Property ID is required")]
        public string IdProperty { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must attach an image file")]
        public IFormFile AttachedFile { get; set; }

        [Required(ErrorMessage = "Enabled field is required")]
        public bool Enabled { get; set; }
    }
}
