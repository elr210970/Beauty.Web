using Beauty.Entity.Entities;
using Beauty.Repository.Contracts;
using Beauty.Shared.DTOs.Appointment;
using Beauty.Shared.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace Beauty.Web.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _service;

        public AppointmentsController(IAppointmentRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            try
            {
                var results = await _service.GetAppointmentsAsync();

                var resultsDto = results.Select(x => new AppointmentDto()
                {

                    Id = x.Id,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    EmployeeId = x.EmployeeId,
                    CustomerId = x.CustomerId,
                    RoomId = x.RoomId,
                    AppointmentTypeId = x.AppointmentTypeId,

                }).ToList();

                return Ok(resultsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{modelId:int}", Name = "GetAppointmentById")]
        public async Task<IActionResult> GetAppointment(int modelId)
        {
            try
            {
                var result = await _service.GetAppointmentAsync(modelId);

                if (result is not null)
                {
                    var resultDto = new AppointmentDto()
                    {

                        Id = result.Id,
                        StartTime = result.StartTime,
                        EndTime = result.EndTime,
                        EmployeeId = result.EmployeeId,
                        CustomerId = result.CustomerId,
                        RoomId = result.RoomId,
                        AppointmentTypeId = result.AppointmentTypeId,

                    };

                    return Ok(resultDto);
                }

                return NotFound("There is no data based on that id.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentCreationDto model)
        {
            try
            {
                if (model is not null)
                {
                    var entity = new Appointment()
                    {
                        StartTime = model.StartTime,
                        EndTime = model.EndTime,
                        EmployeeId = model.EmployeeId,
                        CustomerId = model.CustomerId,
                        RoomId = model.RoomId,
                        AppointmentTypeId = model.AppointmentTypeId,
                    };

                    await _service.CreateAppointmentAsync(entity);
                    await _service.SaveAsync();

                    return StatusCode(201);
                }

                return BadRequest("The sent model is null.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{modelId:int}")]
        public async Task<IActionResult> UpdateAppointment(int modelId, [FromBody] AppointmentEditionDto model)
        {
            try
            {
                var editingModel = await _service.GetAppointmentAsync(modelId);

                if (editingModel is not null)
                {
                    editingModel.StartTime = model.StartTime;
                    editingModel.EndTime = model.EndTime;
                    editingModel.EmployeeId = model.EmployeeId;
                    editingModel.CustomerId = model.CustomerId;
                    editingModel.RoomId = model.RoomId;
                    editingModel.AppointmentTypeId = model.AppointmentTypeId;

                    await _service.SaveAsync();

                    return Ok("Edition done.");
                }

                return BadRequest("The sent model is null.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{modelId:int}")]
        public async Task<IActionResult> DeleteAppointment(int modelId)
        {
            try
            {
                var deletingModel = await _service.GetAppointmentAsync(modelId);

                if (deletingModel is not null)
                {
                    _service.DeleteAppointment(deletingModel);
                    await _service.SaveAsync();

                    return Ok("Deletion done.");
                }

                return BadRequest("The sent model is null.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
