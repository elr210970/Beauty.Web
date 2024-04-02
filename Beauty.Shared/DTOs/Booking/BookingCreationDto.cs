using System.ComponentModel.DataAnnotations;

namespace Beauty.Shared.DTOs.Booking
{
    public class BookingCreationDto
    {
        [Required]
        public int EmployeeId { get; set; }


        [Required]
        public int CustomerId { get; set; }


        [Required]
        public int AppointmentId { get; set; }


        [Required]
        public int ProductId { get; set; }


        [Required]
        public int DiscountId { get; set; }


        [Required]
        public int RoomId { get; set; }
    }
}
