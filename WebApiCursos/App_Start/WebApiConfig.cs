using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiCursos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;//aquí le he dicho que preserve las referencias de los objetos en el json
            config.Formatters.Remove(config.Formatters.XmlFormatter);//aquí elimino el serializador de xml, así siempre me devuelve los datos en json
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
