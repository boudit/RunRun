﻿//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Startup.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Host.Startup))]

namespace Host
{
    using System;
    using System.Web.Http;

    using Host.Providers;

    using Microsoft.Owin.Security.OAuth;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            this.ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            var authServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(authServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

        /*
         * To test the Token Generation :
POST http://localhost:4242/token HTTP/1.1
User-Agent: Fiddler
Host: localhost:4242
Content-Length: 55
Accept: application/json
Content-Type: application/x-www-form-urlencoded

grant_type=password&username=Taiseer&password=SuperPass
         * 
         */
    }
}