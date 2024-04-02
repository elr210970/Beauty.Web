using Beauty.Entity.Entities;
using Beauty.Repository.Contracts;
using Beauty.Shared.DTOs.Booking;
using Beauty.Shared.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace Beauty.Web.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _service;

        public BookingsController(IBookingRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            try
            {
                var results = await _service.GetBookingsAsync();

                var resultsDto = results.Select(x => new BookingDto()
                {

                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    CustomerId = x.CustomerId,
                    AppointmentId = x.AppointmentId,
                    ProductId = x.ProductId,
                    DiscountId = x.DiscountId,
                    RoomId = x.RoomId,

                }).ToList();

                return Ok(resultsDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{modelId:int}", Name = "GetBookingById")]
        public async Task<IActionResult> GetBooking(int modelId)
        {
            try
            {
                var result = await _service.GetBookingAsync(modelId);

                if (result is not null)
                {
                    var resultDto = new BookingDto()
                    {

                        Id = result.Id,
                        EmployeeId= result.EmployeeId,
                        CustomerId = result.CustomerId,
                        AppointmentId = result.AppointmentId,
                        ProductId = result.ProductId,
                        DiscountId = result.DiscountId,
                        RoomId = result.RoomId,

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
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreationDto model)
        {
            try
            {
                if (model is not null)
                {
                    var entity = new Booking()
                    {
                        EmployeeId = model.EmployeeId,
                        CustomerId = model.CustomerId,
                        AppointmentId = model.AppointmentId,
                        ProductId = model.ProductId,
                        DiscountId = model.DiscountId,
                        RoomId = model.RoomId,
                    };

                    await _service.CreateBookingAsync(entity);
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
        public async Task<IActionResult> UpdateBooking(int modelId, [FromBody] BookingEditionDto model)
        {
            try
            {
                var editingModel = await _service.GetBookingAsync(modelId);

                if (editingModel is not null)
                {
                    editingModel.EmployeeId = model.EmployeeId;
                    editingModel.CustomerId = model.CustomerId;
                    editingModel.AppointmentId = model.AppointmentId;
                    editingModel.ProductId = model.ProductId;
                    editingModel.DiscountId = model.DiscountId;
                    editingModel.RoomId = model.RoomId;

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
        public async Task<IActionResult> DeleteBooking(int modelId)
        {
            try
            {
                var deletingModel = await _service.GetBookingAsync(modelId);

                if (deletingModel is not null)
                {
                    _service.DeleteBooking(deletingModel);
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
