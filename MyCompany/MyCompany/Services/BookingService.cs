using MyCompany.Models;

namespace MyCompany.Services
{
    public class BookingService
    {
        private readonly MyDbContext _context;
        public BookingService(MyDbContext context)
        {
            _context = context;
        }
        public List<Booking> GetAll()
        {
            _context.Database.EnsureCreated();
            return _context.Bookings.OrderBy(m => m.BookingId).ToList();
        }
        public Booking? GetSessionById(int id)
        {
            Booking? booking = _context.Bookings.FirstOrDefault(
            x => x.BookingId.Equals(id));
            return booking;
        }
        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
        public void UpdateBooking(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }
    }
}
