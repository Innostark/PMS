﻿using OSS.Models.DomainModels;

namespace OSS.Web.ModelMappers
{
    public static class ServiceCompanyMapper
    {
        public static Models.ServiceCompany CreateFrom(this ServiceCompany serviceCompany)
        {
            return new Models.ServiceCompany
                   {
                       ServiceCompanyId = serviceCompany.ServiceCompanyId,
                       AccountNumber = serviceCompany.AccountNumber,
                       Address = serviceCompany.Address,
                       Comment = serviceCompany.Comment,
                       Email = serviceCompany.Email,
                       Name = serviceCompany.Name,
                       PhoneNumber = serviceCompany.PhoneNumber
                   };
        }

        public static ServiceCompany CreateFrom(this Models.ServiceCompany serviceCompany)
        {
            return new ServiceCompany
                   {
                       ServiceCompanyId = serviceCompany.ServiceCompanyId,
                       AccountNumber = serviceCompany.AccountNumber,
                       Address = serviceCompany.Address,
                       Comment = serviceCompany.Comment,
                       Email = serviceCompany.Email,
                       Name = serviceCompany.Name,
                       PhoneNumber = serviceCompany.PhoneNumber
                   };
        }
    }
}