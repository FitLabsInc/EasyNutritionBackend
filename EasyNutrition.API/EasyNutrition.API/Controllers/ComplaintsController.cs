
using AutoMapper;
using EasyNutrition.API.Domain.Models;
using EasyNutrition.API.Domain.Services;
using EasyNutrition.API.Extensions;
using EasyNutrition.API.Resources;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyNutrition.API.Controllers
{

    [ApiController]
    [Produces("application/json")]
    [EnableCors("AnotherPolicy")]
    [Route("api/[controller]")]
    public class ComplaintsController : ControllerBase
    {
        private readonly IComplaintService _complaintService;
        private readonly IMapper _mapper;

        public ComplaintsController(IComplaintService complaintService, IMapper mapper)
        {
            _complaintService = complaintService;
            _mapper = mapper;
        }


        [SwaggerOperation(
         Summary = "List all complaints",
         Description = "List of Complaints",
         OperationId = "ListAllComplaints",
         Tags = new[] { "Complaints" })]
        [SwaggerResponse(200, "List of Complaint", typeof(IEnumerable<ComplaintResource>))]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ComplaintResource>), 200)]
        public async Task<IEnumerable<ComplaintResource>> GetAllAsync()
        {
            var complaints = await _complaintService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Complaint>, IEnumerable<ComplaintResource>>(complaints);
            return resources;
        }

        [SwaggerOperation(
               Summary = "Add complaint",
               Description = "Add new complaint",
               OperationId = "AddComplaint",
               Tags = new[] { "Complaints" })]
        [SwaggerResponse(200, "Add Complaint", typeof(IEnumerable<ComplaintResource>))]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<ComplaintResource>), 200)]
        public async Task<IActionResult> PostAsync([FromBody] SaveComplaintResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetMessages());
            var complaint = _mapper.Map<SaveComplaintResource, Complaint>(resource);
            var result = await _complaintService.SaveAsync(complaint);

            if (!result.Success)
                return BadRequest(result.Message);

            var complaintResource = _mapper.Map<Complaint, ComplaintResource>(result.Resource);
            return Ok(complaintResource);
        }

        [SwaggerOperation(
            Summary = "Update Complaint",
            Description = "Update a complaint",
            OperationId = "UpdateComplaint",
            Tags = new[] { "Complaints" })]
        [SwaggerResponse(200, "Update Complaint", typeof(IEnumerable<ComplaintResource>))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ComplaintResource>), 200)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveComplaintResource resource)
        {
            var complaint = _mapper.Map<SaveComplaintResource, Complaint>(resource);
            var result = await _complaintService.UpdateAsync(id, complaint);

            if (!result.Success)
                return BadRequest(result.Message);
            var complaintResource = _mapper.Map<Complaint, ComplaintResource>(result.Resource);
            return Ok(complaintResource);
        }


        [SwaggerOperation(
        Summary = "Delete complaint",
        Description = "Delete a complaint",
        OperationId = "DeleteComplaint",
        Tags = new[] { "Complaints" })]
        [SwaggerResponse(200, "Delete Complaint", typeof(IEnumerable<ComplaintResource>))]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<ComplaintResource>), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _complaintService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var complaintResource = _mapper.Map<Complaint, ComplaintResource>(result.Resource);
            return Ok(complaintResource);
        }

    }

}
