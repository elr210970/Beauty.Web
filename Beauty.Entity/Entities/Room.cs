using Beauty.Entity.Base;

namespace Beauty.Entity.Entities
{
    public class Room : BaseEntity
    {
        public string? Name { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
