//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="WebApiConfig.cs" Company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Host
{
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Web.Http;

    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            //var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}