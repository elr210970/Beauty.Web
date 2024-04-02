using Beauty.Shared.DTOs.Appointment;
using Beauty.Shared.DTOs.Base;
using Beauty.Shared.DTOs.Discount;
using Beauty.Shared.DTOs.Product;
using Beauty.Shared.DTOs.Room;
using Beauty.Shared.DTOs.User;

namespace Beauty.Shared.DTOs.Booking
{
    public class BookingDto : BaseEntityDto
    {
        public int EmployeeId { get; set; }
        public UserDto? Employee { get; set; }

        public int CustomerId { get; set; }
        public UserDto? Customer { get; set; }

        public int AppointmentId { get; set; }
        public AppointmentDto? Appointment { get; set; }

        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }

        public int DiscountId { get; set; }
        public DiscountDto? Discount { get; set; }

        public int RoomId { get; set; }
        public RoomDto? Room { get; set; }
    }
}
