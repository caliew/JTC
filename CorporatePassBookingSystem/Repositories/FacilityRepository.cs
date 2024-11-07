// FacilityRepository.cs
using CorporatePassBookingSystem.Data;
using CorporatePassBookingSystem.Models;
using CorporatePassBookingSystem.DataAccess;

namespace CorporatePassBookingSystem.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly JsonDataAccess _dataAccess;

        public FacilityRepository(JsonDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Facility> GetAll()
        {
            return _dataAccess.GetFacilities();
        }
        
        public Facility? GetFacility(int id)
        {
            return _dataAccess.GetFacility(id);
        }

        public IEnumerable<Facility> GetFacilities()
        {
            return _dataAccess.GetFacilities();
        }

        public void CreateFacility(Facility facility)
        {
            _dataAccess.CreateFacility(facility);
        }

        public void UpdateFacility(Facility facility)
        {
            _dataAccess.UpdateFacility(facility);
        }

        public void DeleteFacility(int id)
        {
            _dataAccess.DeleteFacility(id);
        }
    }
}