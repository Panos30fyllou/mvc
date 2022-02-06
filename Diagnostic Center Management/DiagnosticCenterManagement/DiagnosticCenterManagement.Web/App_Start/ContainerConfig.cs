using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DiagnosticCenterManagement.Data.Models;
using DiagnosticCenterManagement.Data.Services;
using DiagnosticCenterManagement.Interfaces;
using System.Web.Http;
using System.Web.Mvc;

namespace DiagnosticCenterManagement.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<PatientsService>().As<IEntityService<Patient, string, int>>().InstancePerRequest();
            builder.RegisterType<DcmDbContext>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}