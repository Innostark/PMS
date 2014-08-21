using System;
using System.Collections.Generic;
using OSS.Models.DomainModels;
using OSS.Models.RequestModels;
using OSS.Models.ResponseModels;

namespace OSS.Interfaces.IServices
{
    public interface IApartmentService
    {
        void AddApartment(Apartment apartment);
        ApartmentResponse GetAllApartments(ApartmentSearchRequest apartmentSearchRequest);
        Apartment FindApartmentById(int? id);
        void UpdateApartment(Apartment apartment);
        void DeleteApartment(Apartment apartment);
        IList<Building> GetUserBuildings(Guid userId);
    }
}
