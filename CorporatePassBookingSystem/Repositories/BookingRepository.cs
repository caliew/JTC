using CorporatePassBookingSystem.DataAccess;
using CorporatePassBookingSystem.Models;
using CorporatePassBookingSystem.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly JsonDataAccess _dataAccess;

    public BookingRepository(JsonDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public IEnumerable<Booking?> GetBookings()
    {
        return _dataAccess.GetBookings();
    }

    public Booking? GetBooking(int id)
    {
        var bookings = _dataAccess.GetBookings();
        return bookings?.FirstOrDefault(b => b.Id == id);
    }

    public void CreateBooking(Booking booking)
    {
        _dataAccess.CreateBooking(booking);
    }

    public void UpdateBooking(Booking booking)
    {
        _dataAccess.UpdateBooking(booking);
    }

    public void DeleteBooking(int id)
    {
        _dataAccess.DeleteBooking(id);
    }

    public Booking GetBookingByFacilityIdAndDate(int facilityId, DateTime date)
    {
        // Implement the logic to retrieve a booking by facility ID and date
        // ...
        return null; // Add a default return value
    }

}