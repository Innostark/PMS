using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using OSS.Implementation.Identity;
using OSS.Implementation.Services;
using OSS.Interfaces.IServices;
using OSS.Models.IdentityModels;

namespace OSS.Implementation
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            UnityConfig.UnityContainer = unityContainer;
            Repository.TypeRegistrations.RegisterType(unityContainer);
            unityContainer.RegisterType<IMenuRightsService, MenuRightsService>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<ICategoryService, CategoryService>();
            unityContainer.RegisterType<ILogger, LoggerService>();
            unityContainer.RegisterType<IDepartmentService, DepartmentService>();
            unityContainer.RegisterType<IBuildingService, BuildingService>();
            unityContainer.RegisterType<IDomainKeyService, DomainKeyService>();
            unityContainer.RegisterType<IServiceCompanyService, ServiceCompanyService>();
            unityContainer.RegisterType<IApartmentService, ApartmentService>();
            unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
 	    

        }
    }
}
