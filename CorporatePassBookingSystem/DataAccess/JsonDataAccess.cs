using CorporatePassBookingSystem.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace CorporatePassBookingSystem.DataAccess
{
    public class JsonDataAccess
    {
        private readonly string _jsonFilePath;

        public JsonDataAccess(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public List<Booking> GetBookings()
        {
            var json = File.ReadAllText(_jsonFilePath);
            var jsonData = JsonDocument.Parse(json);
            var bookings = jsonData.RootElement.GetProperty("bookings").EnumerateArray().Select(b =>
            {
                var bookingDate = b.GetProperty("bookingDate").GetString();
                var startTime = b.GetProperty("startTime").GetString();
                var endTime = b.GetProperty("endTime").GetString();

                if (bookingDate != null && startTime != null && endTime != null)
                {
                    return new Booking
                    {
                        Id = b.GetProperty("id").GetInt32(),
                        FacilityId = b.GetProperty("facilityId").GetInt32(),
                        BookingDate = DateTime.Parse(bookingDate),
                        StartTime = DateTime.Parse(startTime),
                        EndTime = DateTime.Parse(endTime),
                        VisitorId = b.GetProperty("visitorId").GetInt32()
                    };
                }
                else
                {
                    return null;
                }
            }).ToList();
            return bookings ?? new List<Booking>();
        }

        public Booking GetBooking(int id)
        {
            var bookings = GetBookings();
            return bookings?.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBooking(Booking booking)
        {
            var bookings = GetBookings();
            var existingBooking = bookings.FirstOrDefault(b => b.Id == booking.Id);
            if (existingBooking != null)
            {
                existingBooking.FacilityId = booking.FacilityId;
                existingBooking.VisitorId = booking.VisitorId;
                existingBooking.BookingDate = booking.BookingDate;
                existingBooking.StartTime = booking.StartTime;
                existingBooking.EndTime = booking.EndTime;
                existingBooking.Status = booking.Status;
            }
            var json = JsonSerializer.Serialize(bookings);
            File.WriteAllText(_jsonFilePath, json);
        }

        public void CreateBooking(Booking booking)
        {
            // Implement the logic to create a booking
        }

        public void DeleteBooking(int id)
        {
            var bookings = GetBookings();
            var bookingToDelete = bookings.FirstOrDefault(b => b.Id == id);
            if (bookingToDelete != null)
            {
                bookings.Remove(bookingToDelete);
            }
            var json = JsonSerializer.Serialize(bookings);
            File.WriteAllText(_jsonFilePath, json);
        }
        
        public Booking GetBookingByFacilityIdAndDate(int facilityId, DateTime date)
        {
            var bookings = GetBookings();
            return bookings?.FirstOrDefault(b => b.FacilityId == facilityId && b.BookingDate == date);
        }

        public List<Visitor> GetVisitors()
        {
            var json = File.ReadAllText(_jsonFilePath);
            var jsonData = JsonDocument.Parse(json);
            var visitors = jsonData.RootElement.GetProperty("visitors").EnumerateArray().Select(v => new Visitor
            {
                Id = v.GetProperty("id").GetInt32(),
                Name = v.GetProperty("name").GetString(),
                Email = v.GetProperty("email").GetString(),
                PhoneNumber = v.GetProperty("phoneNumber").GetString()
            }).ToList();
            return visitors ?? new List<Visitor>(); // Add null check
        }

        public Visitor GetVisitor(int id)
        {
            var visitors = GetVisitors();
            return visitors?.FirstOrDefault(v => v.Id == id);
        }

        public void CreateVisitor(Visitor visitor)
        {
            var visitors = GetVisitors();
            visitor.Id = visitors.Any() ? visitors.Max(v => v.Id) + 1 : 1;
            visitors.Add(visitor);
            var json = JsonSerializer.Serialize(visitors);
            File.WriteAllText(_jsonFilePath, json);
        }

        public void UpdateVisitor(Visitor visitor)
        {
            var visitors = GetVisitors();
            var existingVisitor = visitors.FirstOrDefault(v => v.Id == visitor.Id);
            if (existingVisitor != null)
            {
                existingVisitor.Name = visitor.Name;
                existingVisitor.Email = visitor.Email;
                existingVisitor.PhoneNumber = visitor.PhoneNumber;
            }
            var json = JsonSerializer.Serialize(visitors);
            File.WriteAllText(_jsonFilePath, json);
        }

        public void DeleteVisitor(int id)
        {
            var visitors = GetVisitors();
            var visitorToDelete = visitors.FirstOrDefault(v => v.Id == id);
            if (visitorToDelete != null)
            {
                visitors.Remove(visitorToDelete);
            }
            var json = JsonSerializer.Serialize(visitors);
            File.WriteAllText(_jsonFilePath, json);
        }

        public List<Facility> GetFacilities()
        {
            var json = File.ReadAllText(_jsonFilePath);
            var jsonData = JsonDocument.Parse(json);
            var facilities = jsonData.RootElement.GetProperty("facilities").EnumerateArray().Select(f => new Facility
            {
                Id = f.GetProperty("id").GetInt32(),
                Name = f.GetProperty("name").GetString(),
                Type = f.GetProperty("type").GetString(),
                Capacity = f.GetProperty("capacity").GetInt32(),
                Location = f.GetProperty("location").GetString(),
                Amenities = f.GetProperty("amenities").GetString()
            }).ToList();
            return facilities ?? new List<Facility>(); // Add null check
        }

        public Facility GetFacility(int id)
        {
            var facilities = GetFacilities();
            return facilities?.FirstOrDefault(f => f.Id == id);
        }

        public void CreateFacility(Facility facility)
        {
            // implementation
        }

        public void UpdateFacility(Facility facility)
        {
            // implementation
        }

        public void DeleteFacility(int id)
        {
            // implementation
        }

        public IEnumerable<BookingHistory> GetBookingHistories()
        {
            var json = File.ReadAllText(_jsonFilePath);
            var jsonData = JsonDocument.Parse(json);
            var bookingHistories = jsonData.RootElement.GetProperty("bookingHistories").EnumerateArray().Select(bh => new BookingHistory
            {
                Id = bh.GetProperty("id").GetInt32(),
                BookingId = bh.GetProperty("bookingId").GetInt32(),
                BookingDate = bh.GetProperty("bookingDate").GetDateTime(),
                CheckInDate = bh.GetProperty("checkInDate").GetDateTime(),
                CheckOutDate = bh.GetProperty("checkOutDate").GetDateTime(),
                Status = bh.GetProperty("status").GetString()
            }).ToList();
            return bookingHistories ?? new List<BookingHistory>();
        }

        public BookingHistory GetBookingHistory(int id)
        {
            var bookingHistories = GetBookingHistories();
            return bookingHistories.FirstOrDefault(bh => bh.Id == id);
        }

        public void AddBookingHistory(Booking booking)
        {
            // implementation
        }

        public void CreateBookingHistory(BookingHistory bookingHistory)
        {
            // implementation
        }

        public void UpdateBookingHistory(BookingHistory bookingHistory)
        {
            // implementation
        }

        public void DeleteBookingHistory(int id)
        {
            // implementation
        }        
    }
}