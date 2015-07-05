using Owin;
using Pasted.DataAccess;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Pasted.Web
{
    public partial class Startup
    {
        private static Assembly ServicesAssembly = Assembly.Load("Pasted.Services");

        public void ConfigureDependencyInjection(IAppBuilder app)
        {
            // Create a new Simple Injector container
            var container = new Container();

            // Configure the container (register dependencies)
            InitializeContainer(container);

            // Register all MVC controllers
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // Optionally verify the container's configuration.
            container.Verify();

            // Register the container as MVC DependencyResolver.
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // DbContext, UoW & Repository
            container.RegisterPerWebRequest<DbContext, PastedDbContext>();
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
            container.Register<IRepository, GenericRepository>();

            // Register all services as their implementing interfaces
            var registrations = ServicesAssembly.GetExportedTypes()
                .Where(t => t.Namespace == "Pasted.Services" && t.GetInterfaces().Any())
                .Select(t => new { Interface = t.GetInterfaces().Single(), Implementation = t });

            foreach (var registration in registrations)
            {
                container.Register(registration.Interface, registration.Implementation);
            }

            // TODO
        }
    }
}