using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RealState.Api.Models;
using RealState.Application.Dtos;
using RealState.Application.Services;

namespace RealState.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly OwnerService _owners;

        public OwnersController(OwnerService owners)
        {
            _owners = owners;
        }

        /// <summary>
        /// Creates a new owner.
        /// </summary>
        /// <param name="request">Required data for the owner.</param>
        /// <returns>Returns the created owner's information.</returns>
        /// <response code="200">The owner was created successfully.</response>
        /// <response code="400">Invalid input data.</response>
        [HttpPost]
        [Route("CreateOwner")]
        [ProducesResponseType(typeof(OwnerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OwnerResponse>> Create([FromBody] CreateOwnerRequest request)
        {
            var createDto = request.Adapt<CreateOwnerDto>();
            var resultDto = await _owners.CreateAsync(createDto);
            var response = resultDto.Adapt<OwnerResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Deletes an existing owner by ID.
        /// </summary>
        /// <param name="id">The ID of the owner to delete.</param>
        /// <returns>No content if deletion was successful.</returns>
        /// <response code="204">Owner deleted successfully.</response>
        /// <response code="404">Owner not found.</response>
        /// <response code="400">Invalid input data.</response>
        [HttpDelete]
        [Route("DeleteOwner{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            await _owners.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Gets a specific owner by ID.
        /// </summary>
        /// <param name="id">The ID of the owner to retrieve.</param>
        /// <returns>Returns the owner's data if found.</returns>
        /// <response code="200">Owner retrieved successfully.</response>
        /// <response code="404">Owner not found.</response>
        /// <response code="400">Invalid input data.</response>
        [HttpGet]
        [Route("GeOwnerById/{id}")]
        [ProducesResponseType(typeof(OwnerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OwnerResponse>> GetById(string id)
        {
            var dto = await _owners.GetByIdAsync(id);
            if (dto == null) return NotFound("No owners found.");
            var response = dto.Adapt<OwnerResponse>();
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing owner.
        /// </summary>
        /// <param name="req">The updated owner data.</param>
        /// <returns>Returns the updated owner if successful.</returns>
        /// <response code="200">Owner updated successfully.</response>
        /// <response code="404">Owner not found.</response>
        /// <response code="400">Invalid input data.</response>
        [HttpPut]
        [Route("UpdateOwner")]
        [ProducesResponseType(typeof(OwnerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OwnerResponse>> Update(UpdateOwnerRequest req)
        {
            var dto = req.Adapt<UpdateOwnerDto>();
            var updated = await _owners.UpdateAsync(dto);
            if (updated == null) return NotFound("No owners found.");
            return Ok(updated.Adapt<OwnerResponse>());
        }

        /// <summary>
        /// Retrieves all owners in the system.
        /// </summary>
        /// <returns>Returns a list of all owners.</returns>
        /// <response code="200">List of owners retrieved successfully.</response>
        /// <response code="404">Owner not found.</response>
        [HttpGet]
        [Route("GetAllOwner")]
        [ProducesResponseType(typeof(IEnumerable<OwnerResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OwnerResponse>>> GetAll()
        {
            var dtos = await _owners.GetAllAsync();
            if (dtos == null || !dtos.Any()) return NotFound("No owners found.");
            return Ok(dtos.Adapt<IEnumerable<OwnerResponse>>());
        }
    }
}
