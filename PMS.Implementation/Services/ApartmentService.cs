using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;

namespace PMS.Implementation.Services
{
    public sealed class ApartmentService: IApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
        }

        public void AddApartment(Apartment apartment)
        {
            apartmentRepository.Add(apartment);
            apartmentRepository.SaveChanges();
        }
    }
}
