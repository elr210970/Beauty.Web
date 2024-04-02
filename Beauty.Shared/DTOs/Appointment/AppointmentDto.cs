using Beauty.Shared.DTOs.AppointmentType;
using Beauty.Shared.DTOs.Base;
using Beauty.Shared.DTOs.Room;
using Beauty.Shared.DTOs.User;

namespace Beauty.Shared.DTOs.Appointment
{
    public class AppointmentDto : BaseEntityDto
    {
        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public int EmployeeId { get; set; }
        public UserDto? Employee { get; set; }

        public int CustomerId { get; set; }
        public UserDto? Customer { get; set; }

        public int RoomId { get; set; }
        public RoomDto? Room { get; set; }

        public int AppointmentTypeId { get; set; }
        public AppointmentTypeDto? AppointmentType { get; set; }
    }
}
