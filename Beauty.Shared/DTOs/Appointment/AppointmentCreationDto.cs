using System.ComponentModel.DataAnnotations;

namespace Beauty.Shared.DTOs.Appointment
{
    public class AppointmentCreationDto
    {
        [Required]
        public TimeOnly StartTime { get; set; }


        [Required]
        public TimeOnly EndTime { get; set; }


        [Required]
        public int EmployeeId { get; set; }


        [Required]
        public int CustomerId { get; set; }


        [Required]
        public int RoomId { get; set; }


        [Required]
        public int AppointmentTypeId { get; set; }
    }
}
