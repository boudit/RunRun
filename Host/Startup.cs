//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Startup.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Host.Startup))]

namespace Host
{
    using System.Web.Http;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}