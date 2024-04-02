using Beauty.Entity.Base;

namespace Beauty.Entity.Entities
{
    public class Booking : BaseEntity
    {
        public int EmployeeId { get; set; }
        public User? Employee { get; set; }

        public int CustomerId { get; set; }
        public User? Customer { get; set; }

        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public int  RoomId { get; set; }
        public Room? Room { get; set; }
    }
}
