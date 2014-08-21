using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.Repository
{
    public interface IApartmentRepository : IBaseRepository<Apartment, int>
    {
        ApartmentResponse GetAllApartments(ApartmentSearchRequest apartmentSearchRequest);
        Apartment FindApartmentById(int apartmentId);
    }
}
