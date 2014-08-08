using System.Web.Mvc;
using Microsoft.Practices.Unity;
using PMS.WebBase.Mvc;
using PMS.WebBase.UnityConfiguration;

namespace PMS.WebBase
{
    public static class TypeRegistrations
    {
        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType(typeof(IControllerActivator), typeof(UnityControllerActivator));
            unityContainer.RegisterType<IExceptionFilter, LogExceptionFilterAttribute>();
            unityContainer.RegisterType<System.Web.Http.Filters.IExceptionFilter, LogExceptionFilterAttribute>();
        }
    }
}
