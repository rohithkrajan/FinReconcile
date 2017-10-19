using Autofac;
using Autofac.Integration.Mvc;
using FinReconcile.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinReconcile
{
    public class DIConfig
    {
        private static ContainerBuilder _builder;

        public static void RegisterDepedencyInjection()
        {
            _builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            _builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            _builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            _builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            _builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            _builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            _builder.RegisterFilterProvider();

            RegisterTypes();

            // Set the dependency resolver to be Autofac.
            var container = _builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }

        private static void RegisterTypes()
        {
            _builder.RegisterType<MarkOffFileProvider>().As<IMarkOffFileProvider>();
        }
    
    }
}