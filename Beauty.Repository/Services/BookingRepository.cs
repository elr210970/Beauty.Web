using Beauty.Entity.Entities;
using Beauty.Repository.Contracts;
using Beauty.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Repository.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
        }

        public void DeleteBooking(Booking booking)
        {
            _context.Bookings.Remove(booking);
        }

        public async Task<Booking> GetBookingAsync(int bookingId)
        {
            return await _context.Bookings
                .SingleOrDefaultAsync(x => x.Id.Equals(bookingId));
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
