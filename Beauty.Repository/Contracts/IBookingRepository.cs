using Beauty.Entity.Entities;

namespace Beauty.Repository.Contracts
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();

        Task<Booking> GetBookingAsync(int bookingId);

        Task CreateBookingAsync(Booking booking);

        void DeleteBooking(Booking booking);

        Task SaveAsync();
    }
}
