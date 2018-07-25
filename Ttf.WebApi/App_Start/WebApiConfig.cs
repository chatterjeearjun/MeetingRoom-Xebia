using Microsoft.Web.Http.Routing;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Http.WebHost;
using Ttf.WebApi.App_Start;
using Ttf.WebApi.DependencyInjection;
using Ttf.WebApi.Filters;
using Microsoft.Practices.Unity;
using Unity;
using DataAccess.Repositories;
using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using DataAccess.Services;
using Ttf.WebApi.Resolver;

namespace Ttf.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Dependency Injection for WebApi controllers via StructureMap
            //config.Services.Replace(typeof(IHttpControllerActivator), new ServiceActivator(config));
            var container = new UnityContainer();
            container.RegisterType<IConfirmBookingService, ConfirmBookingService>();
            container.RegisterType<IFeaturesService, FeaturesService>();
            container.RegisterType<IInitialResponseService,InitialResponseService>();
            container.RegisterType<IRoomsService, RoomsService>();
            container.RegisterType<IConnectionFactory, ConnectionFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IRoomsFeatureService, RoomsFeatureService>();
            config.DependencyResolver = new UnityResolver(container);


            // API Versioning (adding version to URL)
            config.AddApiVersioning();

            // make a constraint for API version
            var constraintResolver = new DefaultInlineConstraintResolver()
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof( ApiVersionRouteConstraint )
                }
            };

            // Web API routes
            config.MapHttpAttributeRoutes(constraintResolver);

            // Add a filter to handle common exceptions and convert them into
            // appropriate status codes.
            config.Filters.Add(new WebApiExceptionFilter());

            // Add converter to serialize enum types as their symbol name rather than their value
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            // Add JSON support for output (instead of XML) when text/html is requested
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            var httpControllerRouteHandler = typeof(HttpControllerRouteHandler).GetField("_instance",
        System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

            if (httpControllerRouteHandler != null)
            {
                httpControllerRouteHandler.SetValue(null,
                    new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));
            }
        }
    }
}
