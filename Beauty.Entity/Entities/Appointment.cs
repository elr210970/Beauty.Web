using Beauty.Entity.Base;

namespace Beauty.Entity.Entities
{
    public class Appointment : BaseEntity
    {
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public int EmployeeId { get; set; }
        public User? Employee { get; set; }

        public int CustomerId { get; set; }
        public User? Customer { get; set; }

        public int RoomId { get; set; }
        public Room? Room { get; set; }

        public int AppointmentTypeId { get; set; }
        public AppointmentType? AppointmentType { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
