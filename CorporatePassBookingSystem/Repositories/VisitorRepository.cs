using CorporatePassBookingSystem.DataAccess;
using CorporatePassBookingSystem.Models;
using CorporatePassBookingSystem.Repositories;

namespace CorporatePassBookingSystem.Repositories
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly JsonDataAccess _dataAccess;

        public VisitorRepository(JsonDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Visitor? GetVisitor(int id)
        {
            var visitors = _dataAccess.GetVisitors();
            return visitors?.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Visitor> GetVisitors()
        {
            return _dataAccess.GetVisitors();
        }

        public void CreateVisitor(Visitor visitor)
        {
            _dataAccess.CreateVisitor(visitor);
        }

        public void UpdateVisitor(Visitor visitor)
        {
            _dataAccess.UpdateVisitor(visitor);
        }

        public void DeleteVisitor(int id)
        {
            _dataAccess.DeleteVisitor(id);
        }
    }
}