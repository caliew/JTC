using CorporatePassBookingSystem.Data;
using CorporatePassBookingSystem.Models;
using System.Collections.Generic;
using System.Linq;
using CorporatePassBookingSystem.DataAccess;

namespace CorporatePassBookingSystem.Repositories
{
    public class BookingHistoryRepository : IBookingHistoryRepository
    {
        private readonly JsonDataAccess _dataAccess;

        public BookingHistoryRepository(JsonDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<BookingHistory> GetAllBookingHistories()
        {
            // implementation
            return _dataAccess.GetBookingHistories();
        }

        public BookingHistory GetBookingHistoryById(int id)
        {
            // implementation
            return _dataAccess.GetBookingHistory(id);
        }

        public void UpdateBookingHistory(BookingHistory bookingHistory)
        {
            // implementation
        }

        public void DeleteBookingHistory(int id)
        {
            // implementation
        }

        public IEnumerable<BookingHistory> GetBookingHistories()
        {
            // implementation
            return _dataAccess.GetBookingHistories();
        }

        public BookingHistory GetBookingHistory(int id)
        {
            // implementation
            return _dataAccess.GetBookingHistory(id);
        }

        public void AddBookingHistory(BookingHistory bookingHistory)
        {
            // implementation
        }
    }

}