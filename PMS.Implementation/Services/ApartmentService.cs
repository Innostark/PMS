﻿using System;
using System.Collections.Generic;
using System.Linq;
using PMS.Interfaces.IServices;
using PMS.Interfaces.Repository;
using PMS.Models.DomainModels;
using PMS.Models.RequestModels;
using PMS.Models.ResponseModels;

namespace PMS.Implementation.Services
{
    public sealed class ApartmentService: IApartmentService
    {
        private readonly IApartmentRepository apartmentRepository;
        private readonly IBuildingRepository buildingRepository;

        public ApartmentService(IApartmentRepository apartmentRepository, IBuildingRepository buildingRepository)
        {
            this.apartmentRepository = apartmentRepository;
            this.buildingRepository = buildingRepository;
        }

        public void AddApartment(Apartment apartment)
        {
            apartmentRepository.Add(apartment);
            apartmentRepository.SaveChanges();
        }
        public ApartmentResponse GetAllApartments(ApartmentSearchRequest apartmentSearchRequest)
        {
            return apartmentRepository.GetAllApartments(apartmentSearchRequest);
        }

        public Apartment FindApartmentById(int? id)
        {
            if (id != null) return apartmentRepository.FindApartmentById((int)id);
            return null;

        }

        public void UpdateApartment(Apartment apartment)
        {
            var apartmentToupdate = FindApartmentById(apartment.ApartmentId);
            if (apartmentToupdate != null)
            {
                apartmentRepository.Update(apartment);
                apartmentRepository.SaveChanges();
            }
        }
        public void DeleteApartment(Apartment apartment)
        {
            apartmentRepository.Delete(apartment);
            apartmentRepository.SaveChanges();
        }

        public IList<Building> GetUserBuildings(Guid userId)
        {
            BuildingSearchRequest buildingSearchRequest = new BuildingSearchRequest
                                                          {
                                                              UserId = userId
                                                          };
            return buildingRepository.GetAllBuildings(buildingSearchRequest).Buildings.ToList();
        }
    }
}
