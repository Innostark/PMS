using System.Data.Entity;
using Microsoft.Practices.Unity;
using PMS.Interfaces.Repository;
using PMS.Repository.BaseRepository;
using PMS.Repository.Repositories;

namespace PMS.Repository
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
            unityContainer.RegisterType<IDomainKeyRepository, DomainKeyRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new HierarchicalLifetimeManager());

            //unityContainer.RegisterType<IUser, ApplicationUser>();
        }
    }
}
