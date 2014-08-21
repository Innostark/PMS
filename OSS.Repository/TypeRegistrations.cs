using Microsoft.Practices.Unity;
using OSS.Interfaces.Repository;
using OSS.Repository.BaseRepository;
using OSS.Repository.Repositories;

namespace OSS.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMenuRightRepository, MenuRightRepository>();
            unityContainer.RegisterType<IProductRepository, ProductRepository>();
            unityContainer.RegisterType<ICategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<IDepartmentRepository, DepartmentRepository>();
            unityContainer.RegisterType<IBuildingRepository, BuildingRepository>();
            unityContainer.RegisterType<IMenuRepository, MenuRepository>();
            unityContainer.RegisterType<IDomainKeyRepository, DomainKeyRepository>();
            unityContainer.RegisterType<IServiceCompanyRepository, ServiceCompanyRepository>();
            unityContainer.RegisterType<IApartmentRepository, ApartmentRepository>();
            unityContainer.RegisterType<BaseDbContext>(new PerRequestLifetimeManager());
        }
    }
}
