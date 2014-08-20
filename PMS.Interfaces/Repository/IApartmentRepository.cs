using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.Repository
{
    public interface IApartmentRepository : IBaseRepository<Apartment, int>
    {
        ApartmentResponse GetAllApartments(ApartmentSearchRequest apartmentSearchRequest);
        Apartment FindApartmentById(int apartmentId);
    }
}
