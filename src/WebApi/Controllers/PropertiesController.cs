using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using Microsoft.VisualBasic;
using RealState.Api.Models;
using RealState.Application.Dtos;
using RealState.Application.Services;

namespace RealState.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertyService _property;
        private readonly PropertyImageService _images;
        private readonly PropertyTraceService _traces;

        public PropertiesController(PropertyService property, PropertyImageService images, PropertyTraceService traces)
        {
            _property = property;
            _images = images;
            _traces = traces;
        }

        /// <summary>
        /// Creates a new property.
        /// </summary>
        /// <param name="req">Required data to create the property.</param>
        /// <returns>Returns the created property details.</returns>
        /// <response code="200">Property created successfully.</response>
        /// <response code="400">Invalid input data.</response>
        [HttpPost]
        [Route("CreateProperty")]
        [ProducesResponseType(typeof(PropertyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PropertyResponse>> Create(CreatePropertyRequest req)
        {
            var dto = req.Adapt<CreatePropertyDto>();
            var result = await _property.CreateAsync(dto);
            return Ok(result.Adapt<PropertyResponse>());
        }

        /// <summary>
        /// Retrieves properties based on provided filters.
        /// </summary>
        /// <param name="req">Filtering criteria.</param>
        /// <returns>Returns a filtered list of properties.</returns>
        /// <response code="200">Properties retrieved successfully.</response>
        /// <response code="404">No properties match the filters.</response>
        [HttpGet]
        [Route("GetPropertyByFiltered")]
        [ProducesResponseType(typeof(IEnumerable<PropertyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> GetFiltered([FromQuery]PropertyFilterRequest req)
        {
            var dto = req.Adapt<PropertyFilterDto>();
            var properties = await _property.GetFiltered(dto);
            if (!properties.Any()) return NotFound("No properties found matching the criteria.");
            return Ok(properties.Adapt<IEnumerable<PropertyResponse>>());
        }

        /// <summary>
        /// Retrieves a property by its ID.
        /// </summary>
        /// <param name="id">Property ID.</param>
        /// <returns>Returns the property data.</returns>
        /// <response code="200">Property found.</response>
        /// <response code="404">Property not found.</response>
        [HttpGet]
        [Route("GetPropertyById/{id}")]
        [ProducesResponseType(typeof(PropertyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyResponse>> GetById(string id)
        {
            var dto = await _property.GetByIdAsync(id);
            if (dto == null) return NotFound("Property not found.");
            return Ok(dto.Adapt<PropertyResponse>());
        }

        /// <summary>
        /// Updates an existing property.
        /// </summary>
        /// <param name="req">Updated property data.</param>
        /// <returns>Returns the updated property details.</returns>
        /// <response code="200">Property updated successfully.</response>
        /// <response code="404">Property not found.</response>
        [HttpPut]
        [Route("UpdateProperty")]
        [ProducesResponseType(typeof(PropertyResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PropertyResponse>> Update(UpdatePropertyRequest req)
        {
            var dto = req.Adapt<UpdatePropertyDto>();
            var updated = await _property.UpdateAsync(dto);
            if (updated == null) return NotFound("Property not found.");
            return Ok(updated.Adapt<PropertyResponse>());
        }

        /// <summary>
        /// Deletes a property by ID.
        /// </summary>
        /// <param name="id">The ID of the property to delete.</param>
        /// <returns>No content on successful deletion.</returns>
        /// <response code="204">Property deleted successfully.</response>
        [HttpDelete]
        [Route("DeleteProperty/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(string id)
        {
            await _property.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Adds an image to a property.
        /// </summary>
        /// <param name="req">Image upload data.</param>
        /// <returns>Returns the uploaded image metadata.</returns>
        /// <response code="200">Image added successfully.</response>
        [HttpPost]
        [Route("AddPropertyImage")]
        [ProducesResponseType(typeof(PropertyImageResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PropertyImageResponse>> AddImage([FromForm] AddPropertyImageRequest req)
        {
            var dto = req.Adapt<AddPropertyImageDto>();
            dto.AttachedFile = req.AttachedFile;
            var result = await _images.AddAsync(dto);
            return Ok(result.Adapt<PropertyImageResponse>());
        }

        /// <summary>
        /// Adds a trace (transaction) to a property.
        /// </summary>
        /// <param name="req">Trace information.</param>
        /// <returns>Returns the added trace data.</returns>
        /// <response code="200">Trace added successfully.</response>
        [HttpPost]
        [Route("AddPropertyTrace")]
        [ProducesResponseType(typeof(PropertyTraceResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<PropertyTraceResponse>> AddTrace(AddPropertyTraceRequest req)
        {
            var dto = req.Adapt<AddPropertyTraceDto>();
            var result = await _traces.AddAsync(dto);
            return Ok(result.Adapt<PropertyTraceResponse>());
        }

        /// <summary>
        /// Retrieves all images for a property.
        /// </summary>
        /// <param name="propertyId">Property ID.</param>
        /// <returns>Returns a list of images.</returns>
        /// <response code="200">Images retrieved successfully.</response>
        /// <response code="404">No images found for the property.</response>
        [HttpGet]
        [Route("GetImage/{propertyId}")]
        [ProducesResponseType(typeof(IEnumerable<PropertyImageResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PropertyImageResponse>>> GetImages(string propertyId)
        {
            var images = await _images.ListAsync(propertyId);
            if (!images.Any()) return NotFound("No images found for the given property.");
            return Ok(images.Adapt<IEnumerable<PropertyImageResponse>>());
        }

        /// <summary>
        /// Retrieves all traces (transactions) for a property.
        /// </summary>
        /// <param name="propertyId">Property ID.</param>
        /// <returns>Returns a list of property traces.</returns>
        /// <response code="200">Traces retrieved successfully.</response>
        /// <response code="404">No traces found for the property.</response>
        [HttpGet]
        [Route("GetTrace/{propertyId}")]
        [ProducesResponseType(typeof(IEnumerable<PropertyTraceResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<PropertyTraceResponse>>> GetTraces(string propertyId)
        {
            var traces = await _traces.ListAsync(propertyId);
            if (!traces.Any()) return NotFound("No traces found for the given property.");
            return Ok(traces.Adapt<IEnumerable<PropertyTraceResponse>>());
        }
    }
}
