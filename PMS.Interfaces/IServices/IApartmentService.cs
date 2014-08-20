using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Interfaces.IServices
{
    public interface IApartmentService
    {
        void AddApartment(Apartment apartment);
        ApartmentResponse GetAllApartments(ApartmentSearchRequest apartmentSearchRequest);
        Apartment FindApartmentById(int? id);
        void UpdateApartment(Apartment apartment);
        void DeleteApartment(Apartment apartment);
    }
}
